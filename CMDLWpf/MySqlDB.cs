using System;
using System.Data;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Windows.Forms;

namespace CMDLWpf
{
    public class MySqlDB
    {
        private string _server;
        private string _database;
        private string _userID;
        private string _port;
        private string _password;
        private string _connectionString;
        private string _errorMessage;


        private MySqlConnection _connection;
        private Dictionary<string, Database> _databaseList = new Dictionary<string, Database>();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="server">the name or network address of the instance of MySQL to which to connect.</param>
        /// <param name="database">the name of the database to used.</param>
        /// <param name="userID">the MySQL login account being used.</param>
        /// <param name="port">the port MySQL is using to listen for connections. This value is ignored if UNIX socket is used.</param>
        /// <param name="password">the password for the MySQL account being used.</param>
        public MySqlDB(string server, string database, string userID, string port, string password)
        {
            _server = server;
            _database = database;
            _userID = userID;
            _port = port;
            _password = password;

            _connectionString = "SERVER=" + server + ";" +
                                "DATABASE=" + database + ";" +
                                "UID=" + userID + ";" +
                                "PASSWORD=" + password + ";" +
                                "PORT=" + port + ";";

            _connection = new MySqlConnection(_connectionString);

        }

        public bool OpenConnection()
        {
            try
            {
                _connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0: _errorMessage = "Cannot connect to server!";
                        break;
                    case 1045: _errorMessage = "Invalid username and/or password!";
                        break;
                    default: _errorMessage = string.Format("{0}:{1}", ex.Number, ex.Message);
                        break;
                }
                return false;
            }
            catch (Exception)
            {
                _errorMessage = "There was an error in opening the connection. Please check the connectionString if the parameters are correct.";
                return false;
            }
        }
        public bool CloseConnection()
        {
            try
            {
                _connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                _errorMessage = string.Format("{0}:{1}", ex.Number, ex.Message);
                return false;
            }
            catch (Exception)
            {
                _errorMessage = "There was an error in closing the connection.";
                return false;
            }
        }
        public void Search(string query, string table)
        {
            try
            {
                if (this.OpenConnection())
                {
                    var db = new Database();
                    db.Select(query, table, this);

                    if (_databaseList.ContainsKey(table))
                    {
                        _databaseList.Remove(table);
                        _databaseList.Add(table, db);
                    }
                    else
                        _databaseList.Add(table, db);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                this.CloseConnection();
            }
        }
        public void SearchWithParametrizedQuery(string query, string table, Dictionary<string, object> parameter)
        {
            try
            {
                if (this.OpenConnection())
                {
                    var db = new Database();
                    db.SelectWithParametrizedQuery(query, table, this, parameter);

                    if (_databaseList.ContainsKey(table))
                    {
                        _databaseList.Remove(table);
                        _databaseList.Add(table, db);
                    }
                    else
                        _databaseList.Add(table, db);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                this.CloseConnection();
            }
        }
        public bool CRUD(string query, string table, Dictionary<string, object> parameter)
        {
            try
            {
                if (this.OpenConnection())
                {
                    var db = new Database();
                    return db.CRUD(query, table, this, parameter);
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return false;
            }
            finally
            {
                this.CloseConnection();
            }
        }
        public void StoredProcedure(string procedureName, List<StoredProcedureParameter> parameters)
        {
            try
            {
                if (this.OpenConnection())
                {
                    MySqlCommand command = new MySqlCommand(procedureName, _connection);
                    command.CommandType = CommandType.StoredProcedure;

                    foreach (var param in parameters)
                        command.Parameters.Add(param.Parameter);

                    command.ExecuteNonQuery();

                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(string.Format("{0}:{1}", ex.Number, ex.Message));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                this.CloseConnection();
            }
        }


        public string Server
        {
            get { return _server; }
            set { _server = value; }
        }
        public string Database
        {
            get { return _database; }
            set { _database = value; }
        }
        public string UserID
        {
            get { return _userID; }
            set { _userID = value; }
        }
        public string Port
        {
            get { return _port; }
            set { _port = value; }
        }
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }
        public string ConnectionString
        {
            get { return _connectionString; }
            set { _connectionString = value; }
        }
        public string ErrorMessage
        {
            get { return _errorMessage; }
            set { _errorMessage = value; }
        }
        public MySqlConnection Connection
        {
            get { return _connection; }
            set { _connection = value; }
        }


        /// <summary>
        /// gets the value of the defined dictionary database
        /// </summary>
        /// <param name="table">the key of the dictionary to search for</param>
        /// <returns></returns>
        public Database this[string table]
        {
            get
            {
                foreach (var kvp in _databaseList)
                    if (kvp.Key == table)
                        return kvp.Value;

                return null;
            }
        }
    }

    public class StoredProcedureParameter
    {
        public StoredProcedureParameter()
        {
            this.Parameter = new MySqlParameter();
        }

        public StoredProcedureParameter(MySqlDbType dbType,
                                        ParameterDirection direction,
                                        string parameterName,
                                        object value)
        {
            this.Parameter = new MySqlParameter();
            this.ParameterName = parameterName;
            this.DBType = dbType;
            this.Direction = direction;
            this.Value = value;
        }

        private MySqlParameter _parameter;
        public MySqlParameter Parameter
        {
            get { return _parameter; }
            set { _parameter = value; }
        }

        public MySqlDbType DBType
        {
            get { return _parameter.MySqlDbType; }
            set { _parameter.MySqlDbType = value; }
        }

        public ParameterDirection Direction
        {
            get { return _parameter.Direction; }
            set { _parameter.Direction = value; }
        }

        public string ParameterName
        {
            get { return _parameter.ParameterName; }
            set { _parameter.ParameterName = value; }
        }

        public object Value
        {
            get { return _parameter.Value; }
            set { _parameter.Value = value; }

        }

    }
}
