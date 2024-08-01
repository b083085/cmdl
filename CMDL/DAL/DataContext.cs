using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMDL
{
    public class DataContext : IDisposable
    {
        MySqlConnection con;

        public DataContext() : this(Global.GetConnectionString())
        {
            
        }

        public DataContext(string connectionString)
        {
            con = new MySqlConnection(connectionString);
        }

        public bool Save(string query, params MySqlParam[] parameters)
        {
            var res = false;
            MySqlTransaction tr = null;

            try
            {
                con.Open();

                tr = con.BeginTransaction();

                var cmd = new MySqlCommand(query, con);

                foreach (var parameter in parameters)
                {
                    cmd.Parameters.AddWithValue(parameter.Key, parameter.Value);
                }

                cmd.Transaction = tr;

                res = cmd.ExecuteNonQuery() > 0;

                if (res)
                    tr.Commit();
            }
            catch (Exception)
            {
                if (tr != null)
                    tr.Rollback();

                throw;
            }
            finally
            {
                con.Close();
            }

            return res;
        }
        public DataSet Get(string query,params MySqlParam[] parameters)
        {
            var ds = new DataSet();

            try
            {
                con.Open();

                var cmd = new MySqlCommand(query, con);

                foreach (var parameter in parameters)
                {
                    cmd.Parameters.AddWithValue(parameter.Key, parameter.Value);
                }

                var da = new MySqlDataAdapter(cmd);

                da.Fill(ds);

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                con.Close();
            }

            return ds;
        }
        public DataSet ExecuteStoredProcedureData(string procedureName, params MySqlParam[] parameters)
        {
            var ds = new DataSet();

            try
            {
                con.Open();

                var cmd = new MySqlCommand(procedureName, con)
                {
                    CommandType = CommandType.StoredProcedure
                };

                foreach (var parameter in parameters)
                {
                    var newParameter = cmd.Parameters.Add(parameter.Key, parameter.Type);
                    newParameter.Value = newParameter.Value;
                }

                var da = new MySqlDataAdapter(cmd);

                da.Fill(ds);

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                con.Close();
            }

            return ds;
        }
        public bool ExecuteStoredProcedure(string procedureName, params MySqlParam[] pdc)
        {
            var res = false;

            try
            {
                con.Open();

                var cmd = new MySqlCommand(procedureName, con)
                {
                    CommandType = CommandType.StoredProcedure
                };

                foreach (var p in pdc)
                {
                    var parameter = cmd.Parameters.Add(p.Key, p.Type);
                    parameter.Value = p.Value;
                }

                res = cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                con.Close();
            }

            return res;
        }
        public bool HasRecords(DataSet ds, string tableName = "Table")
        {
            if (ds == null)
                return false;

            return ds.Tables[tableName].Rows.Count > 0;
        }
        public DataRowCollection GetRecords(DataSet ds, string tableName = "Table")
        {
            return ds.Tables[tableName].Rows;
        }
        public DataRow First(DataSet ds, string tableName = "Table")
        {
            return ds.Tables[tableName].Rows[0];
        }
        public void Dispose()
        {
            con.Dispose();
        }

    }
    public class MySqlParam
    {
        public string Key
        {
            get;
            set;
        }
        public object Value
        {
            get;
            set;
        }
        public MySqlDbType Type
        {
            get;
            set;
        }

    }
}
