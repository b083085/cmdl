using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace CMDL.Data
{
    public class DataContext
    {
        private readonly string _connectionString;

        public DataContext()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["CMDL"].ConnectionString;
        }

        public async Task<IEnumerable<DataRow>> GetAsync(DataQuery query)
        {
            try
            {
                using (var conn = new MySqlConnection(_connectionString))
                {
                    await conn.OpenAsync();

                    var cmd = new MySqlCommand(query.Query, conn);
                    
                    SetParameters(query, cmd);

                    var ds = new DataSet();
                    var da = new MySqlDataAdapter(cmd);
                    await da.FillAsync(ds);

                    return ds.Tables["Table"].Rows.Cast<DataRow>();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> SaveAsync(DataQuery query)
        {
            try
            {
                using (var conn = new MySqlConnection(_connectionString))
                {
                    var transaction = await conn.BeginTransactionAsync();

                    try
                    {
                        var cmd = new MySqlCommand(query.Query, conn, transaction);

                        SetParameters(query, cmd);

                        var result = await cmd.ExecuteNonQueryAsync();
                        var success = result > 0;

                        if (success)
                            transaction.Commit();

                        return success;
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<object> ExecuteScalarAsync(DataQuery query)
        {
            try
            {
                using (var conn = new MySqlConnection(_connectionString))
                {
                    var cmd = new MySqlCommand(query.Query, conn);

                    SetParameters(query, cmd);

                    var result = await cmd.ExecuteScalarAsync();
                    return result;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        #region Private methods

        private void SetParameters(DataQuery query, MySqlCommand cmd)
        {
            if (query.HasParameters)
            {
                foreach (var parameter in query.Parameters)
                {
                    cmd.Parameters.AddWithValue(parameter.Key, parameter.Value);
                }
            }
        }

        #endregion

    }
}
