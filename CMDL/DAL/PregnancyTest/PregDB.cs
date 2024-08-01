using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CMDL
{
    class PregDB : MySqlDB
    {
        public string ControlNo { set; get; }

        public PregDB(string database)
            : base(database)
        {
            //get database
        }

        public PregDB(string server, string database, string uid, string port, string password)
            : base(server, database, uid, port, password)
        {
            //get server,database,uid,port and password
        }

        public PregnancyTest_Data Data
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
                dr[0] = ControlNo;
                dr[1] = Data.ReqPhysician;
                dr[2] = Data.Results;
                dr[3] = Data.Remarks;
                dr[4] = Data.Pathologist;
                dr[5] = Data.MedTech;
                dr[6] = Data.PrintedBy;

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
                dr[0] = ControlNo;
                dr[1] = Data.ReqPhysician;
                dr[2] = Data.Results;
                dr[3] = Data.Remarks;
                dr[4] = Data.Pathologist;
                dr[5] = Data.MedTech;
                dr[6] = Data.PrintedBy;

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
