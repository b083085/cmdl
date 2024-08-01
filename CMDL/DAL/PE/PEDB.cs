using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CMDL
{
    class PEDB : MySqlDB
    {
        public string ControlNo { set; get; }

        public PEDB(string database)
            : base(database)
        {
            //get database
        }

        public PEDB(string server, string database, string uid, string port, string password)
            : base(server, database, uid, port, password)
        {
            //get server,database,uid,port and password
        }

        public PE_Data Data
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
                dr[1] = Data.Nature_Of_Work;
                dr[2] = Data.Growth_Development;
                dr[3] = Data.BP;
                dr[4] = Data.HR;
                dr[5] = Data.PR;
                dr[6] = Data.Height;
                dr[7] = Data.Weight;
                dr[8] = Data.Eyes;
                dr[9] = Data.OD;
                dr[10] = Data.OS;
                dr[11] = Data.Ishi_OD;
                dr[12] = Data.Ishi_OS;
                dr[13] = Data.Ears;
                dr[14] = Data.Nose_Throat;
                dr[15] = Data.Dentals;
                dr[16] = Data.Breast;
                dr[17] = Data.Extremities;
                dr[18] = Data.NeuroLog;
                dr[19] = Data.Heart;
                dr[20] = Data.Lungs;
                dr[21] = Data.Abdomen;
                dr[22] = Data.Genitalia;
                dr[23] = Data.Ano_Rectal;
                dr[24] = Data.Skin;
                dr[25] = Data.Other_Body_Parts;
                dr[26] = Data.Past_Med_History;
                dr[27] = Data.CXR_Date;
                dr[28] = Data.Film_No;
                dr[29] = Data.CXR_Negative;
                dr[30] = Data.CXR_Findings;
                dr[31] = Data.CBC;
                dr[32] = Data.Urine;
                dr[33] = Data.Stool;
                dr[34] = Data.Blood_Chemistry;
                dr[35] = Data.Pregnancy_Test;
                dr[36] = Data.VDRL;
                dr[37] = Data.HepA;
                dr[38] = Data.HepB;
                dr[39] = Data.HIV;
                dr[40] = Data.Drug_Test;
                dr[41] = Data.Blood_Typing;
                dr[42] = Data.Other_Test;
                dr[43] = Data.Neuro_Psychological;
                dr[44] = Data.Neuro_Psychiatric;
                dr[45] = Edit.SetEscSeq(Data.Remarks);
                dr[46] = Data.Recommendation;
                dr[47] = Edit.SetEscSeq(Data.Rec_Note);
                dr[48] = Data.Ref_By;
                dr[49] = Data.Physician;
                dr[50] = Data.PrintedBy;


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
                dr[1] = Data.Nature_Of_Work;
                dr[2] = Data.Growth_Development;
                dr[3] = Data.BP;
                dr[4] = Data.HR;
                dr[5] = Data.PR;
                dr[6] = Data.Height;
                dr[7] = Data.Weight;
                dr[8] = Data.Eyes;
                dr[9] = Data.OD;
                dr[10] = Data.OS;
                dr[11] = Data.Ishi_OD;
                dr[12] = Data.Ishi_OS;
                dr[13] = Data.Ears;
                dr[14] = Data.Nose_Throat;
                dr[15] = Data.Dentals;
                dr[16] = Data.Breast;
                dr[17] = Data.Extremities;
                dr[18] = Data.NeuroLog;
                dr[19] = Data.Heart;
                dr[20] = Data.Lungs;
                dr[21] = Data.Abdomen;
                dr[22] = Data.Genitalia;
                dr[23] = Data.Ano_Rectal;
                dr[24] = Data.Skin;
                dr[25] = Data.Other_Body_Parts;
                dr[26] = Data.Past_Med_History;
                dr[27] = Data.CXR_Date;
                dr[28] = Data.Film_No;
                dr[29] = Data.CXR_Negative;
                dr[30] = Data.CXR_Findings;
                dr[31] = Data.CBC;
                dr[32] = Data.Urine;
                dr[33] = Data.Stool;
                dr[34] = Data.Blood_Chemistry;
                dr[35] = Data.Pregnancy_Test;
                dr[36] = Data.VDRL;
                dr[37] = Data.HepA;
                dr[38] = Data.HepB;
                dr[39] = Data.HIV;
                dr[40] = Data.Drug_Test;
                dr[41] = Data.Blood_Typing;
                dr[42] = Data.Other_Test;
                dr[43] = Data.Neuro_Psychological;
                dr[44] = Data.Neuro_Psychiatric;
                dr[45] = Edit.SetEscSeq(Data.Remarks);
                dr[46] = Data.Recommendation;
                dr[47] = Edit.SetEscSeq(Data.Rec_Note);
                dr[48] = Data.Ref_By;
                dr[49] = Data.Physician;
                dr[50] = Data.PrintedBy;

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
