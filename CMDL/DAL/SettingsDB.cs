using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CMDL
{
    class SettingsDB : MySQLMethodImplementer
    {
        public SettingsDB(string database)
            : base(database)
        {
            //get database
        }

        public SettingsDB(string server, string database, string uid, string port, string password)
            : base(server, database, uid, port, password)
        {
            //get server,database,uid,port and password
        }

        public bool Insert(params string[] data)
        {
            if (base.NewRow())
            {
                //---insert data here----
                for (int i = 0; i < data.Length; i++)
                    base.dr[i] = data[i];
                

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

        public bool Update(int index, params string[] data)
        {
            if (base.IndexRow(index))
            {
                //----insert data here----
                for (int i = 0; i < data.Length; i++)
                {
                    base.dr[i] = data[i];
                }
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
