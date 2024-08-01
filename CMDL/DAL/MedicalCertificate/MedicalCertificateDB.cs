using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CMDL
{
    class MedicalCertifiateDB : MySqlDB
    {
        public string ControlNo { set; get; }

        public MedicalCertifiateDB(string database)
            : base(database)
        {
            //get database
        }

        public MedicalCertifiateDB(string server, string database, string uid, string port, string password)
            : base(server, database, uid, port, password)
        {
            //get server,database,uid,port and password
        }

        public MedicalCertificate_Data Data
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
                dr[1] = string.Format("{0:yyyy-MM-dd hh:mm:ss tt}",DateTime.Parse(Data.Date_approved));
                dr[2] = Data.Remarks;
                dr[3] = Data.Physician;
                dr[4] = Data.License_No;
                dr[5] = Data.PrintedBy;


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
                dr[1] = Data.Date_approved;
                dr[2] = Data.Remarks;
                dr[3] = Data.Physician;
                dr[4] = Data.License_No;
                dr[5] = Data.PrintedBy;

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
