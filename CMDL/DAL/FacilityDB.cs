using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CMDL
{
    public class FacilityDB : MySQLMethodImplementer, IPageImplementer
    {

        public FacilityDB(string server, string database, string uid, string port, string password)
            : base(server, database, uid, port, password)
        {
            Data = new FacilityData();
            
        }

        public FacilityData Data
        {
            set;
            get;
        }

        public bool Insert()
        {
            if (base.NewRow())
            {
                //---insert data here----

                base.dr[0] = Data.facilityNo;
                base.dr[1] = Data.facilityName;
                base.dr[2] = Data.Profile;
                base.dr[3] = Data.Address;
                base.dr[4] = Data.ContactNo;
                base.dr[5] = Data.IsDefault;

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

                base.dr[0] = Data.facilityNo;
                base.dr[1] = Data.facilityName;
                base.dr[2] = Data.Profile;
                base.dr[3] = Data.Address;
                base.dr[4] = Data.ContactNo;
                base.dr[5] = Data.IsDefault;

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

    public class FacilityData
    {
        public string facilityNo { set; get; }
        public string facilityName { set; get; }
        public string Profile { set; get; }
        public string Address { set; get; }
        public string ContactNo { set; get; }
        public string IsDefault { set; get; }
    }
}
