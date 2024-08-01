using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CMDL
{
    public class Test
    {
        public static List<string> Parse(DataTable tbsingle, string exam, string type)
        {
            List<string> test = new List<string>();
            string getc = "";

            foreach (DataRow d in tbsingle.Rows)
            {
                if (d["type"].ToString().Contains(type))
                {
                    foreach (char c in exam)
                    {
                        if (c.ToString() != ",")
                            getc += c.ToString();
                        else
                        {
                            if (getc == d["test"].ToString())
                                test.Add(d["test"].ToString());

                            getc = "";
                        }
                    }
                }
            }

            return test;
        }

        public static string TableName(DataTable tbsingle, string test)
        {
            foreach (DataRow d in tbsingle.Rows)
            {
                if (d["test"].ToString() == test)
                {
                    return d["tablename"].ToString();
                }
            }

            return "";
        }

        public static string Marker(DataTable tbsingle, string test, string type)
        {
            foreach (DataRow d in tbsingle.Rows)
            {
                if (d["type"].ToString().Contains(type))
                {
                    if (test == d["test"].ToString())
                        return d["marker"].ToString();
                }
            }

            return "";
        }
    }
}
