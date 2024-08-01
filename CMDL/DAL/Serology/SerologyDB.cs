using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CMDL
{
    class SerologyDB:MySqlDB
    {
        public string ControlNo { set; get; }

        public SerologyDB(string database)
            : base(database)
        {
            //get database
        }

        public SerologyDB(string server, string database, string uid, string port, string password): base(server, database, uid, port, password)
        {
            //get server,database,uid,port and password
        }

        public Serology_Data Data
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
                dr[1] = Data.Type;
                dr[2] = Data.AntiHIV_results;
                dr[3] = Data.HBsAg_results;
                dr[4] = Data.AntiTP_results;
                dr[5] = Data.AntiHIV_Kit;
                dr[6] = Data.HBsAg_Kit;
                dr[7] = Data.AntiTP_Kit;
                dr[8] = Data.AntiHIV_LotNo;
                dr[9] = Data.HBsAg_LotNo;
                dr[10] = Data.AntiTP_LotNo;
                dr[11] = Data.AntiHIV_Exp;
                dr[12] = Data.HBsAg_Exp;
                dr[13] = Data.AntiTP_Exp;
                dr[14] = Data.AntiHIV_Remarks;
                dr[15] = Data.HBsAg_Remarks;
                dr[16] = Data.AntiTP_Remarks;

                dr[17] = Data.AntiHCV_results;
                dr[18] = Data.AntiHCV_Kit;
                dr[19] = Data.AntiHCV_LotNo;
                dr[20] = Data.AntiHCV_Exp;
                dr[21] = Data.AntiHCV_Remarks;

                dr[22] = Data.Pathologist;
                dr[23] = Data.MedTech_1;
                dr[24] = Data.MedTech_2;
                dr[25] = Data.PrintedBy;
                dr[26] = Data.Up_Controlno;

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
                dr[1] = Data.Type;
                dr[2] = Data.AntiHIV_results;
                dr[3] = Data.HBsAg_results;
                dr[4] = Data.AntiTP_results;
                dr[5] = Data.AntiHIV_Kit;
                dr[6] = Data.HBsAg_Kit;
                dr[7] = Data.AntiTP_Kit;
                dr[8] = Data.AntiHIV_LotNo;
                dr[9] = Data.HBsAg_LotNo;
                dr[10] = Data.AntiTP_LotNo;
                dr[11] = Data.AntiHIV_Exp;
                dr[12] = Data.HBsAg_Exp;
                dr[13] = Data.AntiTP_Exp;
                dr[14] = Data.AntiHIV_Remarks;
                dr[15] = Data.HBsAg_Remarks;
                dr[16] = Data.AntiTP_Remarks;

                dr[17] = Data.AntiHCV_results;
                dr[18] = Data.AntiHCV_Kit;
                dr[19] = Data.AntiHCV_LotNo;
                dr[20] = Data.AntiHCV_Exp;
                dr[21] = Data.AntiHCV_Remarks;

                dr[22] = Data.Pathologist;
                dr[23] = Data.MedTech_1;
                dr[24] = Data.MedTech_2;
                dr[25] = Data.PrintedBy;
                dr[26] = Data.Up_Controlno;

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
