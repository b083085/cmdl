using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CMDL
{
    class UrineDB : MySqlDB
    {
        public string ControlNo { set; get; }

        public UrineDB(string database)
            : base(database)
        {
            //get database
        }

        public UrineDB(string server, string database, string uid, string port, string password)
            : base(server, database, uid, port, password)
        {
            //get server,database,uid,port and password
        }

        public Urinalysis_Data Data
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
                dr[1] = Data.Collection;
                dr[2] = Data.Color;
                dr[3] = Data.Transparency;
                dr[4] = Data.Specific_Gravity;
                dr[5] = Data.PH;
                dr[6] = Data.Glucose;
                dr[7] = Data.Protein;
                dr[8] = Data.Blood;
                dr[9] = Data.Leukocytes;
                dr[10] = Data.Nitrite;
                dr[11] = Data.Ketone;
                dr[12] = Data.Urobilinogen;
                dr[13] = Data.Ascorbic_Acid;
                dr[14] = Data.RBC;
                dr[15] = Data.WBC;
                dr[16] = Data.Epithelial_Cells;
                dr[17] = Data.Bacteria;
                dr[18] = Data.Mucus_Thread;
                dr[19] = Data.A_Urates;
                dr[20] = Data.Uric_Acid;
                dr[21] = Data.Calcium_Oxalate;
                dr[22] = Data.Fine_Granular_Cast;
                dr[23] = Data.Coarse_Granular_Cast;
                dr[24] = Data.WBC_Cast;
                dr[25] = Data.RBC_Cast;
                dr[26] = Data.Others;
                dr[27] = Data.Note;
                dr[28] = Data.Remarks;
                dr[29] = Data.Pathologist;
                dr[30] = Data.MedTech;
                dr[31] = Data.PrintedBy;
            

                

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
                dr[1] = Data.Collection;
                dr[2] = Data.Color;
                dr[3] = Data.Transparency;
                dr[4] = Data.Specific_Gravity;
                dr[5] = Data.PH;
                dr[6] = Data.Glucose;
                dr[7] = Data.Protein;
                dr[8] = Data.Blood;
                dr[9] = Data.Leukocytes;
                dr[10] = Data.Nitrite;
                dr[11] = Data.Ketone;
                dr[12] = Data.Urobilinogen;
                dr[13] = Data.Ascorbic_Acid;
                dr[14] = Data.RBC;
                dr[15] = Data.WBC;
                dr[16] = Data.Epithelial_Cells;
                dr[17] = Data.Bacteria;
                dr[18] = Data.Mucus_Thread;
                dr[19] = Data.A_Urates;
                dr[20] = Data.Uric_Acid;
                dr[21] = Data.Calcium_Oxalate;
                dr[22] = Data.Fine_Granular_Cast;
                dr[23] = Data.Coarse_Granular_Cast;
                dr[24] = Data.WBC_Cast;
                dr[25] = Data.RBC_Cast;
                dr[26] = Data.Others;
                dr[27] = Data.Note;
                dr[28] = Data.Remarks;
                dr[29] = Data.Pathologist;
                dr[30] = Data.MedTech;
                dr[31] = Data.PrintedBy;

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
