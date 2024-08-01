using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CMDL
{
    public class BloodChemistryDB : MySqlDB
    {
        public string ControlNo { set; get; }

        public BloodChemistryDB(string database)
            : base(database)
        {
            //get database
        }

        public BloodChemistryDB(string server, string database, string uid, string port, string password)
            : base(server, database, uid, port, password)
        {
            //get server,database,uid,port and password
        }

        public BloodChemistry_Data Data
        {
            set;
            get;
        }

        public bool Save_BC()
        {

            try
            {
                cb = new MySql.Data.MySqlClient.MySqlCommandBuilder(da);
                dr = ds.Tables[tablename].NewRow();
                dr[0] = Data.BCId;
                dr[1] = Data.MedTech;
                dr[2] = Data.Pathologist;
                dr[3] = Data.PrintedBy;
                dr[4] = Data.Note;



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

        public bool Save_BC_Item()
        {

            try
            {
                int noToBeSave = 0;

                foreach (var item in Data.ItemList)
                {

                    cb = new MySql.Data.MySqlClient.MySqlCommandBuilder(da);
                    dr = ds.Tables[tablename].NewRow();
                    dr[0] = 0;
                    dr[1] = item.BcID;
                    dr[2] = item.Category;
                    dr[3] = item.Chemistry;
                    dr[4] = item.CUHL;
                    dr[5] = item.CURes;
                    dr[6] = item.CUUnit;
                    dr[7] = item.CUValue;
                    dr[8] = item.SIHL;
                    dr[9] = item.SIRes;
                    dr[10] = item.SIUnit;
                    dr[11] = item.SIValue;


                    try
                    {
                        ds.Tables[tablename].Rows.Add(dr);
                        da.Update(ds, tablename);
                    }
                    catch (Exception)
                    {
                        continue;
                    }

                    noToBeSave += 1;
                }

                if (noToBeSave == Data.ItemList.Count)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Save Message");
                return false;
            }

        }

    }
}
