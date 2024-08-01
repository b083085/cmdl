using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using CMDL.Models;

namespace CMDL.WPF
{
    /// <summary>
    /// Interaction logic for SerologyForm.xaml
    /// </summary>
    public partial class SerologyForm : Window
    {
        reg reg;
        string userName;
        bool allowPrint;
        
        public SerologyForm(reg reg,string userName,bool allowPrint)
        {
            InitializeComponent();

            this.reg = reg;
            this.userName= userName;
            this.allowPrint = allowPrint;

            GetSerologyData(reg, userName);
        }

        private void GetSerologyData(reg reg, string userName)
        {
            using (var db = new CyberContext())
            {
                db.CommandTimeout = 600;

                test_serology serology = db.test_serology
                    .Include("test_serology_item")
                    .Where(p => p.controlno == reg.controlno)
                    .FirstOrDefault();

                if (serology == null)
                {
                    serology = new test_serology();
                    serology.controlno = reg.controlno;
                    serology.createdBy = userName;
                    serology.dateCreated = DateTime.Now;
                    serology.updatedBy = userName;
                    serology.dateUpdated = DateTime.Now;
                    GetSignatories(userName, db, serology);
                    SetSerologyItems(reg, db, serology);
                }
                else
                {
                    //disabled controls here
                }

                this.DataContext = serology;
                dgSerologyList.Items.Refresh();
            }
        }

        private static void SetSerologyItems(reg reg, CyberContext db, test_serology serology)
        {
            var exams = reg.exam.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var exam in exams)
            {
                var seroItem = db.exams
                    .Where(p => p.test == exam && p.tablename.ToUpper() == "SEROLOGY")
                    .FirstOrDefault();

                if (seroItem != null)
                {
                    var newItem = new test_serology_item();
                    newItem.test = exam;
                    newItem.result = "NONREACTIVE";
                    newItem.recommendation = string.Empty;
                    newItem.note = string.Empty;

                    var dt = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                    var tk = db.cmdl_testkit
                        .Where(p => p.designatedTest == exam
                            && p.exp.Value >= dt)
                            .FirstOrDefault();

                    newItem.testkit = tk == null ? 96 : tk.tkID;
                    newItem.cmdl_testkit = tk == null ? null : new cmdl_testkit() 
                    { 
                        kitName = tk.kitName, 
                        lotNo = tk.lotNo, 
                        exp = tk.exp, 
                        designatedTest = tk.designatedTest 
                    };

                    serology.test_serology_item.Add(newItem);
                }
            }
        }

        private void GetSignatories(string userName, CyberContext db, test_serology serology)
        {
            var pathologist = db.pathologists
                .Where(p => p.@default == "1")
                .FirstOrDefault();

            if (pathologist != null)
                serology.pathologist = pathologist.name;

            var medtech = db.medteches
                .Where(p => p.user_name == userName)
                .FirstOrDefault();

            if (medtech != null)
                serology.medtech = medtech.name;
        }
    }
}
