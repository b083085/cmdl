using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CMDL
{
    public class XRayDB : MySQLMethodImplementer, IPageImplementer
    {

        public XRayDB(string database)
            : base(database)
        {
            //initialize the dataset
            base.Select("select * from xray where xray_controlno='000000000000'", "xray");
        }

        public XRayDB(string server, string database, string uid, string port, string password): base(server, database, uid, port, password)
        {
            //initialize the dataset
            base.Select("select * from xray where xray_controlno='000000000000'", "xray");
        }

        public XRayClientInfo Data
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
                base.dr[1] = Data.Marker;
                base.dr[2] = Data.RadioReport;
                base.dr[3] = Data.Conclusion;
                base.dr[4] = Data.Radiologist;
                base.dr[5] = Data.PrintedBy;
                base.dr[6] = Data.UpControlNo;

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
                base.dr[1] = Data.Marker;
                base.dr[2] = Data.RadioReport;
                base.dr[3] = Data.Conclusion;
                base.dr[4] = Data.Radiologist;
                base.dr[5] = Data.PrintedBy;
                base.dr[6] = Data.UpControlNo;

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
