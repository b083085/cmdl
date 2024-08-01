using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CMDL
{
    class CBCDB : MySqlDB
    {
        public string ControlNo { set; get; }

        public CBCDB(string database)
            : base(database)
        {
            //get database
        }

        public CBCDB(string server, string database, string uid, string port, string password)
            : base(server, database, uid, port, password)
        {
            //get server,database,uid,port and password
        }

        public CBC_Data Data
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
                dr[1] = Data.Erythrocyte_Count;
                dr[2] = Data.Hemoglobin;
                dr[3] = Data.Hematocrit;
                dr[4] = Data.Leukocyte_Count;
                dr[5] = Data.Segmenters;
                dr[6] = Data.Lymphocytes;
                dr[7] = Data.Monocytes;
                dr[8] = Data.Platelet;
                dr[9] = Data.Remarks;
                dr[10] = Data.Pathologist;
                dr[11] = Data.MedTech;
                dr[12] = Data.PrintedBy;
                dr[13] = Data.Eosinophils;
                dr[14] = Data.Basophils;
                dr[15] = Data.Stabs;
            

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
                dr[1] = Data.Erythrocyte_Count;
                dr[2] = Data.Hemoglobin;
                dr[3] = Data.Hematocrit;
                dr[4] = Data.Leukocyte_Count;
                dr[5] = Data.Segmenters;
                dr[6] = Data.Lymphocytes;
                dr[7] = Data.Monocytes;
                dr[8] = Data.Platelet;
                dr[9] = Data.Remarks;
                dr[10] = Data.Pathologist;
                dr[11] = Data.MedTech;
                dr[12] = Data.PrintedBy;
                dr[13] = Data.Eosinophils;
                dr[14] = Data.Basophils;
                dr[15] = Data.Stabs;

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
