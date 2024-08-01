using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CMDL
{
    class StoolDB : MySqlDB
    {
        public string ControlNo { set; get; }

        public StoolDB(string database)
            : base(database)
        {
            //get database
        }

        public StoolDB(string server, string database, string uid, string port, string password)
            : base(server, database, uid, port, password)
        {
            //get server,database,uid,port and password
        }

        public Stool_Data Data
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
                dr[1] = Data.Consistency;
                dr[2] = Data.Color;
                dr[3] = Data.Leukocytes;
                dr[4] = Data.Erythrocytes;
                dr[5] = Data.Fat_Globules;
                dr[6] = Data.Yeast_Cells;
                dr[7] = Data.Ova_Of_Parasite;
                dr[8] = Data.Protozoan;
                dr[9] = Data.Occult_Blood;
                dr[10] = Data.Remarks;
                dr[11] = Data.Pathologist;
                dr[12] = Data.MedTech;
                dr[13] = Data.PrintedBy;



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
                dr[1] = Data.Consistency;
                dr[2] = Data.Color;
                dr[3] = Data.Leukocytes;
                dr[4] = Data.Erythrocytes;
                dr[5] = Data.Fat_Globules;
                dr[6] = Data.Yeast_Cells;
                dr[7] = Data.Ova_Of_Parasite;
                dr[8] = Data.Protozoan;
                dr[9] = Data.Occult_Blood;
                dr[10] = Data.Remarks;
                dr[11] = Data.Pathologist;
                dr[12] = Data.MedTech;
                dr[13] = Data.PrintedBy;

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
