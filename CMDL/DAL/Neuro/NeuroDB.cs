using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CMDL
{
    public class NeuroDB : MySQLMethodImplementer, IPageImplementer
    {

        public string controlno;
        public string subject;
        public string occupation;
        public string placeofwork;
        public string education;
        public string religion;
        public int a;
        public int b1;
        public int b2;
        public int c1;
        public int c2;
        public int c3;
        public int c4;
        public int d1;
        public int d2;
        public int d3;
        public int d4;
        public string jobexp;
        public string eligibility;
        public string remarks;
        public string recommendation;
        public int genapp;
        public int attitude;
        public int memory;
        public int speech;
        public int affectandmood;
        public int thoughtcontent;
        public int suicidality;
        public int preoccupations;
        public int cognitionthinking;
        public int halucination;
        public string psychometrician;
        public string printedby;
        public string psychiatrist;

        public NeuroDB(string database)
            : base(database)
        {
            //get database
            base.Select("select * from neuro where neuro_controlno='000000000000'", "neuro");
        }

        public NeuroDB(string server, string database, string uid, string port, string password): base(server, database, uid, port, password)
        {
            //get server,database,uid,port and password
            base.Select("select * from neuro where neuro_controlno='000000000000'", "neuro");
        }

        public NeuroClientInfo Data
        {
            set;
            get;
        }

        public bool Insert()
        {
            if (base.NewRow())
            {
                //---insert data here----

                base.dr[0] = Data.ControlNo;
                base.dr[1] = Data.Subject;
                base.dr[2] = Data.Occupation;
                base.dr[3] = Data.PlaceOfWork;
                base.dr[4] = Data.Education;
                base.dr[5] = Data.Religion;
                base.dr[6] = Data.A;
                base.dr[7] = Data.B1;
                base.dr[8] = Data.B2;
                base.dr[9] = Data.C1;
                base.dr[10] = Data.C2;
                base.dr[11] = Data.C3;
                base.dr[12] = Data.C4;
                base.dr[13] = Data.D1;
                base.dr[14] = Data.D2;
                base.dr[15] = Data.D3;
                base.dr[16] = Data.D4;
                base.dr[17] = Data.JobExperience;
                base.dr[18] = Data.Eligibility;
                base.dr[19] = Data.Remarks;
                base.dr[20] = Data.Recommendation;
                base.dr[21] = Data.GenApp;
                base.dr[22] = Data.Attitude;
                base.dr[23] = Data.Memory;
                base.dr[24] = Data.Speech;
                base.dr[25] = Data.AffectAndMood;
                base.dr[26] = Data.ThoughtContent;
                base.dr[27] = Data.Suicidality;
                base.dr[28] = Data.Preoccupations;
                base.dr[29] = Data.CognitionThinking;
                base.dr[30] = Data.Halucination;
                base.dr[31] = Data.Psychometrician;
                base.dr[32] = Data.PrintedBy;
                base.dr[33] = Data.Psychiatrist;

                //-------------------------

                if (base.AddRow())
                {
                    return base.UpdateRow();
                }
                else
                {
                    MessageBox.Show("Cannot Add a New Row!", "Insert Error Message");
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Cannot Create a New Row!", "Insert Error Message");
                return false;
            }
        }

        public bool Update(int index)
        {
            if (base.IndexRow(index))
            {
                //----insert data here----

                base.dr[0] = Data.ControlNo;
                base.dr[1] = Data.Subject;
                base.dr[2] = Data.Occupation;
                base.dr[3] = Data.PlaceOfWork;
                base.dr[4] = Data.Education;
                base.dr[5] = Data.Religion;
                base.dr[6] = Data.A;
                base.dr[7] = Data.B1;
                base.dr[8] = Data.B2;
                base.dr[9] = Data.C1;
                base.dr[10] = Data.C2;
                base.dr[11] = Data.C3;
                base.dr[12] = Data.C4;
                base.dr[13] = Data.D1;
                base.dr[14] = Data.D2;
                base.dr[15] = Data.D3;
                base.dr[16] = Data.D4;
                base.dr[17] = Data.JobExperience;
                base.dr[18] = Data.Eligibility;
                base.dr[19] = Data.Remarks;
                base.dr[20] = Data.Recommendation;
                base.dr[21] = Data.GenApp;
                base.dr[22] = Data.Attitude;
                base.dr[23] = Data.Memory;
                base.dr[24] = Data.Speech;
                base.dr[25] = Data.AffectAndMood;
                base.dr[26] = Data.ThoughtContent;
                base.dr[27] = Data.Suicidality;
                base.dr[28] = Data.Preoccupations;
                base.dr[29] = Data.CognitionThinking;
                base.dr[30] = Data.Halucination;
                base.dr[31] = Data.Psychometrician;
                base.dr[32] = Data.PrintedBy;
                base.dr[33] = Data.Psychiatrist;

                //-------------------------

                return base.UpdateRow();
            }
            else
            {
                MessageBox.Show("This Row doesn't Exist!", "Update Error Message");
                return false;
            }
        }

        public bool Delete(int index)
        {
            if (base.IndexRow(index))
            {
                if (base.RemoveRow())
                {
                    return base.UpdateRow();
                }
                else
                {
                    MessageBox.Show("Cannot Remove this Row!", "Delete Error Message");
                    return false;
                }
            }
            else
            {
                MessageBox.Show("This Row doesn't Exist!", "Delete Error Message");
                return false;
            }
        }
    }

}
