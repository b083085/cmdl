using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.ComponentModel;
using System.Windows.Media;
using CMDL.DAL;

namespace CMDL
{


    class ClientDB : MySQLMethodImplementer, IPageImplementer
    {
        public string controlno;
        public DateTime date;
        public string lastname;
        public string firstname;
        public string mi;
        public string suffix;
        public string address;
        public string age;
        public string sex;
        public string civilstatus;
        public DateTime bdate;
        public string bplace;
        public string reqparty;
        public string purpose;
        public string telno;
        public string celno;
        public string branch;
        public byte[] photo;
        public List<Examination> exams = new List<Examination>();
        public double total;
        public double paid;
        public double bal;
        public double change;
             
        public ClientModel client
        {
            set;
            get;
        }

        public cmdldbDataSet Cmdl
        {
            set;
            get;
        }

        public ClientDB(string database)
            : base(database)
        {
            //initialize the dataset
            base.Select("select * from reg where controlno='000000000000'", "reg");
        }

        public ClientDB(string server, string database, string uid, string port, string password)
            : base(server, database, uid, port, password)
        {
            //initialize the dataset
            base.Select("select * from reg where controlno='000000000000'", "reg");
        }

        public bool Insert()
        {
            if (base.NewRow())
            {
                //---insert data here----

                base.dr[0] = controlno;
                base.dr[1] = string.Format("{0:yyyy-MM-dd}", date);
                base.dr[2] = photo;
                base.dr[3] = lastname;
                base.dr[4] = firstname;
                base.dr[5] = mi;
                base.dr[6] = suffix;
                base.dr[7] = address;
                base.dr[8] = age;
                base.dr[9] = sex;
                base.dr[10] = civilstatus;
                base.dr[11] = string.Format("{0:yyyy-MM-dd}", bdate);
                base.dr[12] = bplace;
                base.dr[13] = reqparty;
                base.dr[14] = purpose;
                base.dr[15] = telno;
                base.dr[16] = celno;
                base.dr[17] = branch;
                base.dr[18] = ClientMethod.ParseTest(exams);
                base.dr[19] = ClientMethod.ParsePrice(exams);
                base.dr[20] = Convert.ToDouble(total);
                base.dr[21] = Convert.ToDouble(paid);
                base.dr[22] = Convert.ToDouble(bal);
                base.dr[23] = Convert.ToDouble(change);
                base.dr[24] = string.Format("{0:yyyy-MM-dd hh:mm:ss tt}", DateTime.Now);
                base.dr[26] = ClientMethod.TestType(exams, Cmdl);

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

                base.dr[0] = controlno;
                base.dr[1] = string.Format("{0:yyyy-MM-dd}", date);
                base.dr[2] = photo;
                base.dr[3] = lastname;
                base.dr[4] = firstname;
                base.dr[5] = mi;
                base.dr[6] = suffix;
                base.dr[7] = address;
                base.dr[8] = age;
                base.dr[9] = sex;
                base.dr[10] = civilstatus;
                base.dr[11] = string.Format("{0:yyyy-MM-dd}", bdate);
                base.dr[12] = bplace;
                base.dr[13] = reqparty;
                base.dr[14] = purpose;
                base.dr[15] = telno;
                base.dr[16] = celno;
                base.dr[17] = branch;
                base.dr[18] = ClientMethod.ParseTest(exams);
                base.dr[19] = ClientMethod.ParsePrice(exams);
                base.dr[20] = Convert.ToDouble(total);
                base.dr[21] = Convert.ToDouble(paid);
                base.dr[22] = Convert.ToDouble(bal);
                base.dr[23] = Convert.ToDouble(change);
                base.dr[26] = ClientMethod.TestType(exams, Cmdl);

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

        private bool isNumber(string text)
        {
            foreach (char c in text)
            {
                if (!Char.IsNumber(c))
                    return false;
            }
            return true;
        }

        public bool ValidateEntries()
        {

            if (!String.IsNullOrWhiteSpace(controlno))
            {
                if (date.ToShortDateString() == DateTime.Now.ToShortDateString())
                {
                    if (!String.IsNullOrWhiteSpace(lastname))
                    {
                        if (!String.IsNullOrWhiteSpace(firstname))
                        {
                            if (!String.IsNullOrWhiteSpace(address))
                            {
                                if (isNumber(age))
                                {
                                    if (!String.IsNullOrWhiteSpace(sex))
                                    {
                                        if (!String.IsNullOrWhiteSpace(civilstatus))
                                        {
                                            if (bdate.ToShortDateString() != DateTime.Now.ToShortDateString())
                                            {
                                                if (!String.IsNullOrWhiteSpace(bplace))
                                                {
                                                    if (!String.IsNullOrWhiteSpace(reqparty))
                                                    {
                                                        if (!String.IsNullOrWhiteSpace(purpose))
                                                        {
                                                            if (!String.IsNullOrWhiteSpace(branch))
                                                            {
                                                                if (photo != null)
                                                                {
                                                                    if (exams.Count > 0)
                                                                    {
                                                                        return true;
                                                                    }
                                                                    else
                                                                    {
                                                                        MessageBox.Show("Test not specified!", "Client Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                                        return false;
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    MessageBox.Show("Photo not specified!", "Client Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                                    return false;
                                                                }
                                                            }
                                                            else
                                                            {
                                                                MessageBox.Show("District/Branch not specified!", "Client Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                                return false;
                                                            }
                                                        }
                                                        else
                                                        {
                                                            MessageBox.Show("Purpose Not Specified!", "Client Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                            return false;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        MessageBox.Show("Requesting Party not specified!", "Client Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                        return false;
                                                    }
                                                }
                                                else
                                                {
                                                    MessageBox.Show("Birth Place not specified!", "Client Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                    return false;
                                                }
                                            }
                                            else
                                            {
                                                MessageBox.Show("Invalid Birth Date!", "Client Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                return false;
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show("Civil Status not specified!", "Client Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            return false;
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Sex not specified!", "Client Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        return false;
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Invalid Age!", "Client Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return false;
                                }
                            }
                            else
                            {
                                MessageBox.Show("Invalid Address!", "Client Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return false;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Invalid FirstName!", "Client Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid LastName!", "Client Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("Invalid Date!", "Client Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            else 
            {
                MessageBox.Show("Invalid Control No!","Client Error Message",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return false;
            }


        }

    }

    public class ClientModel : INotifyPropertyChanged
    {
        #region Inotifypropertychanged Implementation
        public event PropertyChangedEventHandler PropertyChanged;

        protected void Notify(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion

        public delegate void ExamEventHandler();
        public event ExamEventHandler ExamEvent;
        //public event EventHandler PhotoEvent;

        private string _controlno;
        private string _date;
        private string _lastname;
        private string _firstname;
        private string _mi;
        private string _suffix;
        private string _address;
        private string _age;
        private string _sex;
        private string _civilstatus;
        private string _bdate;
        private string _bplace;
        private string _reqparty;
        private string _purpose;
        private string _contactno;
        private string _telno;
        private string _celno;
        private string _branch;
        private ImageSource _photo;

        private double _total = 0;
        private double _paid = 0;
        private double _bal = 0;
        private double _change = 0;

        private string _timein;
        private string _exam_type;

        private List<Examination> _exam = new List<Examination>();

        public ClientModel()
        {
            //none
        }

        public string ControlNo
        {
            set
            {
                if (_controlno != value)
                {
                    _controlno = value;
                    Notify("ControlNo");
                }

            }
            get
            {
                return _controlno;
            }
        }

        public string Date
        {
            set
            {
                if (_date != value)
                {
                    _date = value;
                    Notify("Date");
                }

            }
            get
            {
                return _date;
            }
        }

        public string LastName
        {
            set
            {
                if (_lastname != value)
                {
                    _lastname = value;
                    Notify("LastName");
                }

            }
            get
            {
                return _lastname;
            }
        }

        public string FirstName
        {
            set
            {
                if (_firstname != value)
                {
                    _firstname = value;
                    Notify("FirstName");
                }

            }
            get
            {
                return _firstname;
            }
        }

        public string MI
        {
            set
            {
                if (_mi != value)
                {
                    _mi = value;
                    Notify("MI");
                }

            }
            get
            {
                return _mi;
            }
        }

        public string Suffix
        {
            set
            {
                if (_suffix != value)
                {
                    _suffix = value;
                    Notify("Suffix");
                }

            }
            get
            {
                return _suffix;
            }
        }

        public string Address
        {
            set
            {
                if (_address != value)
                {
                    _address = value;
                    Notify("Address");
                }
            }
            get
            {
                return _address;
            }
        }

        public string Age
        {
            set
            {
                if (_age != value)
                {
                    _age = value;
                    Notify("Age");
                }
            }
            get
            {
                return _age;
            }
        }

        public string Sex
        {
            set
            {
                if (_sex != value)
                {
                    _sex = value;
                    Notify("Sex");
                }
            }
            get
            {
                return _sex;
            }
        }

        public string CivilStatus
        {
            set
            {
                if (_civilstatus != value)
                {
                    _civilstatus = value;
                    Notify("CivilStatus");
                }
            }
            get
            {
                return _civilstatus;
            }
        }

        public string BDate
        {
            set
            {
                if (_bdate != value)
                {
                    _bdate = value;
                    Notify("BDate");
                }
            }
            get
            {
                return _bdate;
            }
        }

        public string BPlace
        {
            set
            {
                if (_bplace != value)
                {
                    _bplace = value;
                    Notify("BPlace");
                }
            }
            get
            {
                return _bplace;
            }
        }

        public string ReqParty
        {
            set
            {
                if (_reqparty != value)
                {
                    _reqparty = value;
                    Notify("ReqParty");
                }
            }
            get
            {
                return _reqparty;
            }
        }

        public string Purpose
        {
            set
            {
                if (_purpose != value)
                {
                    _purpose = value;
                    Notify("Purpose");
                }
            }
            get
            {
                return _purpose;
            }
        }

        public string ContactNo
        {
            set
            {
                if (_contactno != value)
                {
                    _contactno = value;
                    Notify("ContactNo");
                }
            }
            get
            {
                return _contactno;
            }
        }

        public string TelNo
        {
            set
            {
                if (_telno != value)
                {
                    _telno = value;
                    Notify("TelNo");
                }
            }
            get
            {
                return _telno;
            }
        }

        public string CelNo
        {
            set
            {
                if (_celno != value)
                {
                    _celno = value;
                    Notify("CelNo");
                }
            }
            get
            {
                return _celno;
            }
        }

        public string Branch
        {
            set
            {
                if (_branch != value)
                {
                    _branch = value;
                    Notify("Branch");
                }
            }
            get
            {
                return _branch;
            }

        }

        public List<Examination> Exam
        {
            get
            {
                return _exam;
            }
        }

        public void ListViewItemRefresh()
        {
            if (this.ExamEvent != null)
                this.ExamEvent();
        }

        public ImageSource Photo
        {
            set
            {
                if (_photo != value)
                {
                    _photo = value;
                    Notify("Photo");
                }
            }
            get
            {
                return _photo;
            }
        }

        public double Total
        {
            set
            {
                if (_total != value)
                {
                    _total = value;
                    Notify("Total");
                }
            }
            get
            {
                return _total;
            }
        }

        public double Paid
        {
            set
            {
                if (_paid != value)
                {
                    _paid = value;
                    Notify("Paid");
                }
            }
            get
            {
                return _paid;
            }
        }

        public double Balance
        {
            set
            {
                if (_bal != value)
                {
                    _bal = value;
                    Notify("Balance");
                }
            }
            get
            {
                return _bal;
            }
        }

        public double Change
        {
            set
            {
                if (_change != value)
                {
                    _change = value;
                    Notify("Change");
                }
            }
            get
            {
                return _change;
            }
        }

        public string TimeIn
        {
            set
            {
                if (_timein != value)
                {
                    _timein = value;
                    Notify("TimeIn");
                }
            }
            get
            {
                return _timein;
            }
        }

        public string ExamType
        {
            set
            {
                if (_exam_type != value)
                {
                    _exam_type = value;
                    Notify("ExamType");
                }
            }
            get
            {
                return _exam_type;
            }
        }

        public void Clear()
        {
            _lastname = string.Empty;
            _firstname = string.Empty;
            _mi = string.Empty;
            _suffix = string.Empty;
            _address = string.Empty;
            _age = string.Empty;
            _sex = string.Empty;
            _civilstatus = string.Empty;
            _bdate = string.Empty;
            _bplace = string.Empty;
            _reqparty = string.Empty;
            _purpose = string.Empty;
            _contactno = string.Empty;
            _branch = string.Empty;
            _photo = null;

            Exam.Clear();
            ListViewItemRefresh();

            Total = 0;
            Paid = 0;
            Balance = 0;
            Change = 0;
        }
    }

    public class Examination
    {
        private string _test;
        private string _price;

        public string Test
        {
            set
            {
                if (_test != value)
                {
                    _test = value;
                }
            }
            get
            {
                return _test;
            }

        }

        public string Price
        {
            set
            {
                if (_price != value)
                {
                    _price = value;
                }
            }
            get
            {
                return _price;
            }

        }
    }

    public class ClientMethod
    {
        public static string ParseTest(List<Examination> exams)
        {
            string test = "";
            foreach (Examination e in exams)
            {
                test += e.Test + ",";
            }

            return test;
        }

        public static string ParsePrice(List<Examination> exams)
        {
            string price = "";
            foreach (Examination e in exams)
            {
                price += e.Price + ",";
            }

            return price;
        }

        public static string TestType(List<Examination> exams, cmdldbDataSet cmdl)
        {
            string type = "";
            foreach (Examination e in exams)
            {
                foreach (DataRow d in cmdl.Tables["exam"].Rows)
                {
                    if (e.Test == Convert.ToString(d["test"]))
                    {
                        if (!type.Contains(Convert.ToString(d["type"])))
                        {
                            type += Convert.ToString(d["type"]) + ",";
                        }
                    }
                }
            }

            return type;
        }

        public static string ParseRequestingParty(ListBox.ObjectCollection items)
        {
            string reqparty = "";

            if (items.Count > 0)
            {
                foreach (object o in items)
                {
                    reqparty += Convert.ToString(o) + "-";
                }

                reqparty = reqparty.Substring(0, reqparty.Length - 1);
            }

            return reqparty;
        }

        public static void SetTest(List<Examination> exams,string test)
        {
            string exam = "";
            foreach (char c in test)
            {
                if (c.ToString() != ",")
                    exam += c.ToString();
                else
                {
                    exams.Add(new Examination() { Test = exam });
                    exam = "";
                }
            }
        }

        public static void SetPrice(List<Examination> exams, string prices)
        {
            string price = "";
            int i = 0;
            foreach (char c in prices)
            {
                if (c.ToString() != ",")
                    price += c.ToString();
                else
                {
                    exams[i].Price = price;
                    price = "";
                    i += 1;
                }
            }
        }

        public static string ConvertTableName(string name)
        {
            switch (name)
            {
                case "CONTROL NO.": return "controlno";
                case "DATE": return "date_reg";
                case "LAST NAME": return "lastname";
                case "FIRST NAME": return "firstname";
                case "MIDDLE INITIAL": return "mi";
                case "SUFFIX": return "suffix";
                case "ADDRESS": return "address";
                case "AGE": return "age";
                case "SEX": return "sex";
                case "CIVIL STATUS": return "civil_status";
                case "BIRTH DATE": return "bdate";
                case "BIRTH PLACE": return "bplace";
                case "REQUESTING PARTY": return "reqparty";
                case "PURPOSE": return "purpose";
                case "TELEPHONE NO.": return "telno";
                case "MOBILE NO.": return "celno";
                case "DISTRICT/BRANCH": return "district_branch";
                case "EXAM": return "exam";
                default: return "";
            }


        }
    }

}
