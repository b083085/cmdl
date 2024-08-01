using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CMDL
{
    public class MySQLMethodImplementer:MySqlDB
    {
        public MySQLMethodImplementer(string database):base(database)
        {

        }

        public MySQLMethodImplementer(string server,string database,string uid,string port,string password):base(server,database,uid,port,password)
        {

        }
        
        public bool NewRow()
        {
            try
            {
                cb = new MySql.Data.MySqlClient.MySqlCommandBuilder(da);
                dr = ds.Tables[tablename].NewRow();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool IndexRow(int index)
        {
            try
            {
                cb = new MySql.Data.MySqlClient.MySqlCommandBuilder(da);
                dr = returnrow[index];
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool AddRow()
        {
            try
            {
                ds.Tables[tablename].Rows.Add(dr);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool RemoveRow()
        {
            try
            {
                dr.Delete();
                return true;
            }
            catch (Exception)
            {
                return false;
            } 
        }

        public bool UpdateRow()
        {
            try
            {
                da.Update(ds, tablename);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
