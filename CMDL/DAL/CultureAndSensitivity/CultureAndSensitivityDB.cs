using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CMDL
{
    public class CultureAndSensitivityDB:MySqlDB
    {

        public CultureAndSensitivityDB(string database)
            : base(database)
        {
            //get database
        }

        public CultureAndSensitivityDB(string server, string database, string uid, string port, string password)
            : base(server, database, uid, port, password)
        {
            //get server,database,uid,port and password
        }

        public CultureAndSensitivity_Data Data
        {
            set;
            get;
        }

        public bool Save_CS()
        {

            try
            {
                cb = new MySql.Data.MySqlClient.MySqlCommandBuilder(da);
                dr = ds.Tables[tablename].NewRow();
                dr[0] = Data.CSNo;
                dr[1] = Data.Note;
                dr[2] = Data.Sample;
                dr[3] = Data.Pathologist;
                dr[4] = Data.MedTech;
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

        public bool Save_CS_GramStain()
        {

            try
            {
                int noToBeSave = 0;

                foreach (var csGS in Data.GramStainResult)
                {
                    cb = new MySql.Data.MySqlClient.MySqlCommandBuilder(da);
                    dr = ds.Tables[tablename].NewRow();
                    dr[0] = Data.CSNo + noToBeSave;
                    dr[1] = Data.CSNo;
                    dr[2] = csGS.Result;

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

                if (noToBeSave == Data.GramStainResult.Count)
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

        public bool Save_CS_IDO()
        {

            try
            {
                int noToBeSave = 0;

                foreach (var ido in Data.IDOResult)
                {
                    cb = new MySql.Data.MySqlClient.MySqlCommandBuilder(da);
                    dr = ds.Tables[tablename].NewRow();
                    dr[0] = Data.CSNo + noToBeSave;
                    dr[1] = Data.CSNo;
                    dr[2] = ido.Organism;
                    dr[3] = ido.Count;

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

                if (noToBeSave == Data.IDOResult.Count)
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

        public bool Save_CS_Sensitivity()
        {

            try
            {
                int noToBeSave = 0;

                foreach (var sen in Data.SensitivityResult)
                {
                    cb = new MySql.Data.MySqlClient.MySqlCommandBuilder(da);
                    dr = ds.Tables[tablename].NewRow();
                    dr[0] = Data.CSNo + noToBeSave;
                    dr[1] = Data.CSNo;
                    dr[2] = sen.Sensitivities;
                    dr[3] = sen.Count;
                    dr[4] = sen.Count2;

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

                if (noToBeSave == Data.SensitivityResult.Count)
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
