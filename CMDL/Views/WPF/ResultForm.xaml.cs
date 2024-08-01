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
using CMDLWpf;

namespace CMDL
{
    /// <summary>
    /// Interaction logic for ResultForm.xaml
    /// </summary>
    public partial class ResultForm : Window
    {
        CMDLWpf.MySqlDB host = new CMDLWpf.MySqlDB(Properties.Settings.Default.Server,
                                                   Properties.Settings.Default.Database,
                                                   Properties.Settings.Default.UserID,
                                                   Properties.Settings.Default.Port,
                                                   Properties.Settings.Default.Password);
        
        SearchClientInfo sc;
        List<string> radTechList = new List<string>();
        List<Radiologist> radiologistList = new List<Radiologist>();
        List<MedicalTechnologist> medtechList = new List<MedicalTechnologist>();
        List<Pathologist> pathoList = new List<Pathologist>();
        List<Physician> physicianList = new List<Physician>();
        List<Dentist> dentistList = new List<Dentist>();
        List<Psychologist> psychologistList = new List<Psychologist>();
        List<CMDLWpf.Psychiatrist> psychiatristList = new List<CMDLWpf.Psychiatrist>();

        public ResultForm(SearchClientInfo sc)
        {
            InitializeComponent();
            this.sc = sc;
            this.DataContext = this.sc;

            GetRadTech();
            GetRadiologist();
            GetMedicalTechnologist();
            GetPathologist();
            GetPhysician();
            GetPsychologist();
            GetPsychiatrist();
            SetTabPages(this.sc);
        }

        void SetTabPages(SearchClientInfo sc)
        {

            if (sc.Xray != null)
            {
                foreach (var xr in sc.Xray)
                    tabControl1.Items.Add(new TabItem() { Header = xr.Marker, Content = new UC_XRay(xr) { RadTechList = radTechList, RadiologistList = radiologistList } });
            }
            if (sc.Serology != null)
            {
                tabControl1.Items.Add(new TabItem() { Header = "SEROLOGY", Content = new CMDLWpf.UC_Serology(sc.Serology) { MedTechList = medtechList, PathologistList = pathoList } });
            }
            if (sc.BloodChemistry != null)
            {
                tabControl1.Items.Add(new TabItem() { Header = "BLOOD CHEMISTRY", Content = new CMDLWpf.UC_BloodChemistry(sc.BloodChemistry) { MedTechList = medtechList, PathologistList = pathoList } });
            }
            if (sc.BloodTyping != null)
            {
                tabControl1.Items.Add(new TabItem() { Header = "BLOOD TYPING", Content = new CMDLWpf.UC_BloodTyping(sc.BloodTyping) { MedTechList = medtechList, PathologistList = pathoList } });
            }
            if (sc.PhysicalExamination != null)
            {
                tabControl1.Items.Add(new TabItem() { Header = "PHYSICAL EXAMINATION", Content = new UC_PhysicalExamination(sc.PhysicalExamination) { PhysicianList = physicianList } });
            }
            if (sc.Hematology != null)
            {
                tabControl1.Items.Add(new TabItem() { Header = "CBC", Content = new UC_Hematology(sc.Hematology) { MedTechList = medtechList, PathologistList = pathoList } });
            }
            if (sc.DentalCertificate != null)
            {
                tabControl1.Items.Add(new TabItem() { Header = "DENTAL CERTIFICATE", Content = new UC_DentalCertificate(sc.DentalCertificate) { DentistList = dentistList } });
            }
            if (sc.GramStaining != null)
            {
                tabControl1.Items.Add(new TabItem() { Header = "GRAM STAINING", Content = new UC_GramStaining(sc.GramStaining) { MedTechList = medtechList, PathologistList = pathoList } });
            }
            if (sc.MedicalCertificate != null)
            {
                tabControl1.Items.Add(new TabItem() { Header = "MEDICAL CERTIFICATE", Content = new CMDLWpf.UC_MedicalCertificate(sc.MedicalCertificate) { PhysicianList = physicianList } });
            }
            if (sc.Neuro != null)
            {
                tabControl1.Items.Add(new TabItem() { Header = "NEURO PSYCHOLOGICAL", Content = new UC_Neuro(sc.Neuro) { PsychologistList = psychologistList, PsychiatristList = psychiatristList } });
            }
            if (sc.PregnancyTest != null)
            {
                tabControl1.Items.Add(new TabItem() { Header = "PREGNANCY TEST", Content = new UC_PregnancyTest(sc.PregnancyTest) { MedTechList = medtechList, PathologistList = pathoList } });
            }
            if (sc.Fecalysis != null)
            {
                tabControl1.Items.Add(new TabItem() { Header = "STOOL", Content = new UC_Fecalysis(sc.Fecalysis) { MedTechList = medtechList, PathologistList = pathoList } });
            }
            if (sc.Urinalysis != null)
            {
                tabControl1.Items.Add(new TabItem() { Header = "URINALYSIS", Content = new CMDLWpf.UC_Urinalysis(sc.Urinalysis) { MedTechList = medtechList, PathologistList = pathoList } });
            }
            if (sc.CultureAndSensitivity != null)
            {
                //none
            }
        }

        void GetRadTech()
        {
            host.Search("select * from cmdl_radtech", "cmdl_radtech");
            Database db = host["cmdl_radtech"];

            if (db.Length > 0)
            {
                foreach (var dr in db.ReturnRow)
                {
                    radTechList.Add(Convert.ToString(dr["radtech"]));
                }
            }

            
        }
        void GetRadiologist()
        {
            host.Search("select * from cmdl_radiologist", "cmdl_radiologist");
            Database db = host["cmdl_radiologist"];

            if (db.Length > 0)
            {
                foreach (var dr in db.ReturnRow)
                {
                    if (Convert.ToChar(dr["isAvailable"]) == '1')
                        radiologistList.Add(new Radiologist()
                        {
                            Name = Convert.ToString(dr["name"]),
                            Title = Convert.ToString(dr["title"]),
                            IsAvailable = true
                        });

                }
            }
        }
        void GetMedicalTechnologist()
        {
            host.Search("select * from cmdl_medicalTechnologist", "cmdl_medicalTechnologist");
            Database db = host["cmdl_medicalTechnologist"];

            if (db.Length > 0)
            {
                foreach (var dr in db.ReturnRow)
                {
                    if (Convert.ToChar(dr["isAvailable"]) == '1')
                        medtechList.Add(new MedicalTechnologist()
                        {
                            Name = Convert.ToString(dr["name"]),
                            Title = Convert.ToString(dr["title"]),
                            Username = Convert.ToString(dr["username"]),
                            IsAvailable = true
                        });

                }
            }
        }
        void GetPathologist()
        {
            host.Search("select * from cmdl_pathologist", "cmdl_pathologist");
            Database db = host["cmdl_pathologist"];

            if (db.Length > 0)
            {
                foreach (var dr in db.ReturnRow)
                {
                    if (Convert.ToChar(dr["isAvailable"]) == '1')
                        pathoList.Add(new Pathologist()
                        {
                            Name = Convert.ToString(dr["name"]),
                            Title = Convert.ToString(dr["title"]),
                            IsAvailable = true
                        });

                }
            }
        }
        void GetPhysician()
        {
            host.Search("select * from cmdl_physician", "cmdl_physician");
            Database db = host["cmdl_physician"];

            if (db.Length > 0)
            {
                foreach (var dr in db.ReturnRow)
                {
                    if (Convert.ToChar(dr["isAvailable"]) == '1')
                        physicianList.Add(new Physician()
                        {
                            Name = Convert.ToString(dr["name"]),
                            Title = Convert.ToString(dr["title"]),
                            IsAvailable = true,
                            LicenseNo = Convert.ToString(dr["licenseNo"])
                        });

                }
            }
        }
        void GetDentist()
        {
            host.Search("select * from cmdl_dentist", "cmdl_dentist");
            Database db = host["cmdl_dentist"];

            if (db.Length > 0)
            {
                foreach (var dr in db.ReturnRow)
                {
                    if (Convert.ToChar(dr["isAvailable"]) == '1')
                        dentistList.Add(new Dentist()
                        {
                            Name = Convert.ToString(dr["name"]),
                            Title = Convert.ToString(dr["title"]),
                            IsAvailable = true,
                            LicenseNo = Convert.ToString(dr["licenseNo"])
                        });
                }
            }
        }
        void GetPsychologist()
        {
            host.Search("select * from cmdl_psychologist", "cmdl_psychologist");
            Database db = host["cmdl_psychologist"];

            if (db.Length > 0)
            {
                foreach (var dr in db.ReturnRow)
                {
                    if (Convert.ToChar(dr["isAvailable"]) == '1')
                        psychologistList.Add(new Psychologist()
                        {
                            Name = Convert.ToString(dr["name"]),
                            Title = Convert.ToString(dr["title"]),
                            IsAvailable = true,
                        });
                }
            }
        }
        void GetPsychiatrist()
        {
            host.Search("select * from cmdl_psychiatrist", "cmdl_psychiatrist");
            Database db = host["cmdl_psychiatrist"];

            if (db.Length > 0)
            {
                foreach (var dr in db.ReturnRow)
                {
                    if (Convert.ToChar(dr["isAvailable"]) == '1')
                        psychiatristList.Add(new CMDLWpf.Psychiatrist()
                        {
                            Name = Convert.ToString(dr["name"]),
                            Title = Convert.ToString(dr["title"]),
                            IsAvailable = true
                        });
                }
            }
        }


    }
}
