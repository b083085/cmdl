using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CMDL
{
    public class Blood_Chemistry_ItemDB : MySqlDB
    {
        public string ControlNo { set; get; }

        public Blood_Chemistry_ItemDB(string database)
            : base(database)
        {
            //get database
        }

        public Blood_Chemistry_ItemDB(string server, string database, string uid, string port, string password)
            : base(server, database, uid, port, password)
        {
            //get server,database,uid,port and password
        }

        public Blood_Chemistry_Items_Data Data
        {
            set;
            get;
        }

        public bool Save()
        {

            try
            {
                cb = new MySql.Data.MySqlClient.MySqlCommandBuilder(da);
                dr = ds.Tables[tablename].NewRow();
                dr[0] = 0;
                dr[1] = Data.BcID;
                dr[2] = Data.Category;
                dr[3] = Data.Chemistry;
                dr[4] = Data.CUHL;
                dr[5] = Data.CURes;
                dr[6] = Data.CUUnit;
                dr[7] = Data.CUValue;
                dr[8] = Data.SIHL;
                dr[9] = Data.SIRes;
                dr[10] = Data.SIUnit;
                dr[11] = Data.SIValue;


                ds.Tables[tablename].Rows.Add(dr);
                da.Update(ds, tablename);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Save Message");
                return false;
            }

        }

        public bool Update(int index)
        {
            try
            {
                cb = new MySql.Data.MySqlClient.MySqlCommandBuilder(da);
                dr = returnrow[index];
                dr[0] = Data.ItemID;
                dr[1] = Data.BcID;
                dr[2] = Data.Category;
                dr[3] = Data.Chemistry;
                dr[4] = Data.CUHL;
                dr[5] = Data.CURes;
                dr[6] = Data.CUUnit;
                dr[7] = Data.CUValue;
                dr[8] = Data.SIHL;
                dr[9] = Data.SIRes;
                dr[10] = Data.SIUnit;
                dr[11] = Data.SIValue;

                da.Update(ds, tablename);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Update Message");
                return false;
            }


        }
    }
}
