using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;
using System.Windows.Media.Imaging;


namespace CMDL
{
    public class MySqlDB
    {
        //fields:
        public MySqlConnection connection;
        private int count;

        public DataSet ds;
        public DataSet ds1;
        public MySqlDataAdapter da;
        public MySqlDataAdapter da1;
        public DataRow dr;
        public MySqlCommandBuilder cb;
        public MySqlCommandBuilder cb1;
        public DataRow[] returnrow;
        public DataRow[] returnrow1;
        public BindingSource bs;
        public DataViewManager viewmanager;
        public string server;
        public string database;
        public string uid;
        public string port;
        public string password;
        public string connectionstring;
        public string tablename;
        public string tablename1;
        public int length;
        public int length1;




        //constructors:
        public MySqlDB(string database)
        {
            this.server = "localhost";
            this.database = database;
            this.uid = "root";
            this.port = "3306";
            this.password = "Cyber001";

            this.connectionstring = "SERVER=" + server + ";" +
                                      "DATABASE=" + database + ";" +
                                      "UID=" + uid + ";" +
                                      "PASSWORD=" + password + ";" +
                                      "PORT=" + port + ";";

            connection = new MySqlConnection(connectionstring);
        }

        public MySqlDB(string server, string database, string uid, string port, string password)
        {
            this.server = server;
            this.database = database;
            this.uid = uid;
            this.port = port;
            this.password = password;

            this.connectionstring = "SERVER=" + server + ";" +
                                      "DATABASE=" + database + ";" +
                                      "UID=" + uid + ";" +
                                      "PASSWORD=" + password + ";" +
                                      "PORT=" + port + ";";

            connection = new MySqlConnection(connectionstring);
        }

        //methods:
        public bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                //When handling errors, you can your application's response based 
                //on the error number.
                //The two most common error numbers when connecting are as follows:
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.
                switch (ex.Number)
                {
                    case 0:
                        throw new Exception("Cannot connect to server. Contact administrator");
                    case 1045:
                        throw new Exception("Invalid username/password! Please try again");
                }

                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool ExecuteNonQuery(string query, string title)
        {
            try
            {
                //open connection
                if (this.OpenConnection() == true)
                {
                    //create command and assign the query and connection from the constructor
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    //Execute command
                    cmd.ExecuteNonQuery();
                    //close connection
                    this.CloseConnection();
                }

                return true;
            }
            catch (Exception)
            {
                this.CloseConnection(); 
                return false;
            }
        }

        public bool MySqlCommand(string query)
        {
            return ExecuteNonQuery(query, "MySql Command Message");
        }

        public DataRow[] Select(string query, string tablename)
        {
            try
            {
                this.tablename = tablename;
                //Open connection
                if (this.OpenConnection() == true)
                {
                    ds = new DataSet();
                    da = new MySqlDataAdapter(query, connection);
                    da.Fill(ds, tablename);
                    returnrow = ds.Tables[tablename].Select();
                    length = returnrow.Length;
                    //close Connection
                    this.CloseConnection();
                }
                return returnrow;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "MySql Select Message");
                this.CloseConnection();
                return null;
            }
        }

        public DataRow[] Select1(string query, string tablename)
        {
            try
            {
                this.tablename1 = tablename;
                //Open connection
                if (this.OpenConnection() == true)
                {
                    ds1 = new DataSet();
                    da1 = new MySqlDataAdapter(query, connection);
                    da1.Fill(ds1, tablename1);
                    returnrow1 = ds1.Tables[tablename1].Select();
                    length1 = returnrow1.Length;
                    //close Connection
                    this.CloseConnection();
                }
                return returnrow1;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "MySql Select Message");
                this.CloseConnection();
                return null;
            }
        }

        public void BackUp(string DBName)
        {
            try
            {

                //Save file to C:\ with the current date as a filename
                if (!Directory.Exists(@"C:\CMDL\Back-Up"))
                    Directory.CreateDirectory(@"C:\CMDL\Back-Up");

                string path = @"C:\CMDL\Back-Up\" + DBName + ".sql";

                StreamWriter file = new StreamWriter(path);

                ProcessStartInfo psi = new ProcessStartInfo();
                psi.FileName = "mysqldump";
                psi.RedirectStandardInput = false;
                psi.RedirectStandardOutput = true;
                psi.Arguments = string.Format(@"-u{0} -p{1} -h{2} {3}", uid, password, server, database);
                psi.UseShellExecute = false;

                Process process = Process.Start(psi);

                string output = process.StandardOutput.ReadToEnd();
                file.WriteLine(output);
                process.WaitForExit();
                file.Close();
                process.Close();
                MessageBox.Show("Back-Up Completed!");
            }
            catch (IOException ex)
            {
                MessageBox.Show("Error: Unable To Back-Up...!" + ex.Message, "MySql Backup Message");
            }
        }

        public void Restore(string DBName)
        {
            try
            {
                //Read file from C:\
                if (!Directory.Exists(@"C:\CMDL\Restore"))
                    Directory.CreateDirectory(@"C:\CMDL\Restore");


                string path = @"C:\CMDL\Restore\" + DBName + ".sql";
                StreamReader file = new StreamReader(path);
                string input = file.ReadToEnd();
                file.Close();

                ProcessStartInfo psi = new ProcessStartInfo();
                psi.FileName = "mysql";
                psi.RedirectStandardInput = true;
                psi.RedirectStandardOutput = false;
                psi.Arguments = string.Format(@"-u{0} -p{1} -h{2} {3}", uid, password, server, database);
                psi.UseShellExecute = false;


                Process process = Process.Start(psi);
                process.StandardInput.WriteLine(input);
                process.StandardInput.Close();
                process.WaitForExit();
                process.Close();
            }
            catch (IOException ex)
            {
                MessageBox.Show("Error: Unable To Restore...!" + ex.Message, "MySql Restore Message");
            }
        }

        public int Count(string query)
        {
            count = -1;

            //Open Connection
            if (this.OpenConnection() == true)
            {
                //Create Mysql Command
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //ExecuteScalar will return one valued
                count = int.Parse(cmd.ExecuteScalar() + "");

                //close Connection
                this.CloseConnection();

                return count;
            }
            else
            {
                return count;
            }
        }

        public void BindTwoTable(string datasetName,
                                          string query1,
                                          string query2,
                                          string tableName1,
                                          string tableName2,
                                          string colName1,
                                          string colName2,
                                          string relationName)
        {

            DataRelation relation;
            DataSet ds1;
            DataColumn col1, col2;
            MySqlDataAdapter da1, da2;

            bs = new BindingSource();

            if (this.OpenConnection() == true)
            {

                ds1 = new DataSet(datasetName);
                da1 = new MySqlDataAdapter(query1, connection);
                MySqlCommandBuilder cb = new MySqlCommandBuilder(da1);
                da1.TableMappings.Add("Table", tableName1);
                da1.Fill(ds1);

                da2 = new MySqlDataAdapter(query2, connection);
                MySqlCommandBuilder cb1 = new MySqlCommandBuilder(da2);
                da2.TableMappings.Add("Table", tableName2);
                da2.Fill(ds1);


                col1 = ds1.Tables[tableName1].Columns[colName1];
                col2 = ds1.Tables[tableName2].Columns[colName2];
                relation = new DataRelation(relationName, col1, col2);
                ds1.Relations.Add(relation);

                bs.DataSource = ds1;

                viewmanager = ds1.DefaultViewManager;


                this.CloseConnection();
            }
            else
            {
                this.CloseConnection();
            }
        }

        public void StoredProcedure(string procedureName, List<StoredProcedureParameter> parameters)
        {
            try
            {
                //Open connection
                if (this.OpenConnection())
                {
                    MySqlCommand cmd = new MySqlCommand(procedureName, connection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    foreach (var spp in parameters)
                        cmd.Parameters.Add(spp.Parameter);

                    cmd.ExecuteNonQuery();
                }

            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.CloseConnection();
            }
        }

    }
}




