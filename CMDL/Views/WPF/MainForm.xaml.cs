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
using System.Data;
using CMDL.WPF;
using CMDL.Models;
using CMDL.DAL;
using CMDL.Common;
using CMDL.Views.WPF;
using CMDL.Views.WPF.ReportFilters;

namespace CMDL
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainForm : Window
    {
        cmdldbDataSet cmdl;
        ClientModel model = new ClientModel();

        public MainForm()
        {
            InitializeComponent();

            Closed += MainForm_Closed;

            NewClientMenu.Click += NewClientMenu_Click;
            ClientVerificationMenu.Click += ClientVerificationMenu_Click;
            DisplayClientInfoMenu.Click += DisplayClientInfoMenu_Click;
            UpdateClientRecordsMenu.Click += UpdateClientRecordsMenu_Click;
            PrintStubMenu.Click += PrintStubMenu_Click;
            GrossSalesMenu.Click += GrossSalesMenu_Click;

            XRayMenu.Click += XRayMenu_Click;
            NeuroMenu.Click += NeuroMenu_Click;
            LaboratoryMenu.Click += LaboratoryMenu_Click;

            Loaded += MainForm_Loaded;

            Title = $"CMDL {Global.AppVersion()}";
        }


        #region EVENTS
        private void MainForm_Loaded(object sender, RoutedEventArgs e)
        {
            salesSummaryMenu.Click += SalesSummaryMenu_Click;

            if (!GlobalInstance.Instance.User.UseXRay)
            {
                ReportsMenu.Items.Remove(xrayHeaderReportMenu);
                ReportsMenu.Items.Remove(xraySummaryMenu);
            }
            else
            {
                xraySummaryMenu.Click += XraySummaryMenu_Click;
            }

            if (!GlobalInstance.Instance.User.UseNeuro)
            {
                ReportsMenu.Items.Remove(neuroReportSeparatorMenu);
                ReportsMenu.Items.Remove(neuroHeaderReportMenu);
                ReportsMenu.Items.Remove(psychologicalTestSummaryMenu);
            }
            else
            {
                if (!GlobalInstance.Instance.User.UseXRay)
                {
                    ReportsMenu.Items.Remove(neuroReportSeparatorMenu);
                }
                psychologicalTestSummaryMenu.Click += PsychologicalTestSummaryMenu_Click;
            }

            if (!GlobalInstance.Instance.User.UseLaboratory)
            {
                ReportsMenu.Items.Remove(laboratoryReportSeparatorMenu);
                ReportsMenu.Items.Remove(laboratoryHeaderReportMenu);
                ReportsMenu.Items.Remove(bloodTestReportMenu);
                ReportsMenu.Items.Remove(bloodTypingReportMenu);
                ReportsMenu.Items.Remove(cbcReportMenu);
                ReportsMenu.Items.Remove(HepAReportMenu);
                ReportsMenu.Items.Remove(HepBReportMenu);
                ReportsMenu.Items.Remove(HepCReportMenu);
                ReportsMenu.Items.Remove(HIVReportMenu);
                ReportsMenu.Items.Remove(pregnancyTestReportMenu);
                ReportsMenu.Items.Remove(stoolReportMenu);
                ReportsMenu.Items.Remove(urinalysisReportMenu);
                ReportsMenu.Items.Remove(physicalReportSeparatorMenu);
                ReportsMenu.Items.Remove(physicalReportHeaderMenu);
                ReportsMenu.Items.Remove(medicalCertificateReportMenu);
                ReportsMenu.Items.Remove(peReportMenu);
            }
            else
            {
                if (!GlobalInstance.Instance.User.UseXRay && !GlobalInstance.Instance.User.UseNeuro)
                {
                    ReportsMenu.Items.Remove(laboratoryReportSeparatorMenu);
                }


                bloodTestReportMenu.Click += BloodTestReportMenu_Click;
                bloodTypingReportMenu.Click += BloodTypingReportMenu_Click;
                cbcReportMenu.Click += CbcReportMenu_Click;
                HepAReportMenu.Click += HepAReportMenu_Click;
                HepBReportMenu.Click += HepBReportMenu_Click;
                HepCReportMenu.Click += HepCReportMenu_Click;
                HIVReportMenu.Click += HIVReportMenu_Click;
                pregnancyTestReportMenu.Click += PregnancyTestReportMenu_Click;
                stoolReportMenu.Click += StoolReportMenu_Click;
                urinalysisReportMenu.Click += UrinalysisReportMenu_Click;
                medicalCertificateReportMenu.Click += MedicalCertificateReportMenu_Click;
                peReportMenu.Click += PeReportMenu_Click;
            }

        }

        

        void MainForm_Closed(object sender, EventArgs e)
        {
            try
            {
                foreach (Window w in Application.Current.Windows)
                    w.Close();

                this.Close();

            }
            catch (Exception)
            {
                this.Close();
            }
        }
        private void NewClientMenu_Click(object sender, RoutedEventArgs e)
        {
            if (GlobalInstance.Instance.User.CanRegister)
            {
                var frm = new NewClientPage(model, cmdl);
                frm.ShowDialog();
            }
            else
            {
                ShowStopMessage($"{GlobalInstance.Instance.User.UserName} is not permitted to register client.");
            }
        }
        private void ClientVerificationMenu_Click(object sender, RoutedEventArgs e)
        {
            if (GlobalInstance.Instance.User.CanRegister)
            {
                var cv_page = new ClientVerificationPage();
                if (cv_page.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    var ncpage = new NewClientPage(model, cmdl);
                    ncpage.SetClientInfo(cv_page.Record);
                    ncpage.ShowDialog();
                }
            }
            else
            {
                ShowStopMessage($"{GlobalInstance.Instance.User.UserName} is not permitted to verify client's information.");
            }
        }
        private void DisplayClientInfoMenu_Click(object sender, RoutedEventArgs e)
        {
            if (GlobalInstance.Instance.User.CanRegister)
            {
                var disp_info = new DisplayInformation(model);

                if (System.Windows.Forms.Screen.AllScreens.Length > 1)
                {
                    foreach (var s in System.Windows.Forms.Screen.AllScreens)
                    {
                        if (!s.Primary)
                        {
                            disp_info.Left = s.WorkingArea.X;
                            disp_info.Top = 0;
                            disp_info.WindowStartupLocation = System.Windows.WindowStartupLocation.Manual;
                            disp_info.Width = s.WorkingArea.Width;
                            disp_info.Height = s.WorkingArea.Height;
                            disp_info.Show();
                        }
                    }
                }
                else
                {
                    disp_info.Show();
                }
            }
            else
            {
                ShowStopMessage($"{GlobalInstance.Instance.User.UserName} is not allowed to display client's information.");
            }
        }
        private void UpdateClientRecordsMenu_Click(object sender, RoutedEventArgs e)
        {
            if (GlobalInstance.Instance.User.CanRegister)
            {
                var edit_page = new EditRecordsPage(model, cmdl);
                edit_page.ShowDialog();
            }
            else
            {
                ShowStopMessage($"{GlobalInstance.Instance.User.UserName} is not permitted to update client records.");
            }
        }
        private void PrintStubMenu_Click(object sender, RoutedEventArgs e)
        {
            if (GlobalInstance.Instance.User.CanRegister)
            {
                var pr_page = new PrintReceiptPage(cmdl);
                pr_page.AllowPrint = GlobalInstance.Instance.User.CanPrint;
                pr_page.UserName = GlobalInstance.Instance.User.UserName;
                pr_page.ShowDialog();
            }
            else
            {
                ShowStopMessage($"{GlobalInstance.Instance.User.UserName} is not permitted to print stub.");
            }
        }
        private void GrossSalesMenu_Click(object sender, RoutedEventArgs e)
        {
            if (GlobalInstance.Instance.User.CanRegister)
            {
                var ss_page = new SalesStatusPage();
                ss_page.ShowDialog();
            }
            else
            {
                ShowStopMessage($"{GlobalInstance.Instance.User.UserName} is not permitted to view gross sales.");
            }
        }
        private void XRayMenu_Click(object sender, RoutedEventArgs e)
        {
            if (GlobalInstance.Instance.User.UseXRay)
            {
                var xray_client = new XRaySearchClient(cmdl);
                xray_client.AllowPrint = GlobalInstance.Instance.User.CanPrint;
                xray_client.UserName = GlobalInstance.Instance.User.UserName;
                xray_client.ShowDialog();
            }
            else
            {
                ShowStopMessage($"{GlobalInstance.Instance.User.UserName} is not permitted to view or edit x-ray records.");
            }
        }
        private void NeuroMenu_Click(object sender, RoutedEventArgs e)
        {
            if (GlobalInstance.Instance.User.UseNeuro)
            {
                var neuro_client = new NeuroListForm();
                neuro_client.ShowDialog();
            }
            else
            {
                ShowStopMessage($"{GlobalInstance.Instance.User.UserName} is not permitted to view or edit neuro records.");
            }
        }
        private void LaboratoryMenu_Click(object sender, RoutedEventArgs e)
        {
            if (GlobalInstance.Instance.User.UseLaboratory)
            {
                var lab_client = new LabSearchClient(cmdl, GlobalInstance.Instance.User.UserName);
                lab_client.AllowPrint = GlobalInstance.Instance.User.CanPrint;
                lab_client.UserName = GlobalInstance.Instance.User.UserName;
                lab_client.ShowDialog();
            }
            else
            {
                ShowStopMessage($"{GlobalInstance.Instance.User.UserName} is not permitted to view or edit laboratory records.");
            }
        }
        #endregion
        #region REPORTS
        private void SalesSummaryMenu_Click(object sender, RoutedEventArgs e)
        {
            var rp = new ReportPage(DocTestType.Sales);
            rp.ShowDialog();
        }
        private void PeReportMenu_Click(object sender, RoutedEventArgs e)
        {
            var rp = new ReportPage(DocTestType.PE);
            rp.ShowDialog();
        }
        private void MedicalCertificateReportMenu_Click(object sender, RoutedEventArgs e)
        {
            //var rp = new ReportForm(new rfXRay());
            //rp.ShowDialog();
        }
        private void UrinalysisReportMenu_Click(object sender, RoutedEventArgs e)
        {
            var rp = new ReportPage(DocTestType.Urinalysis);
            rp.ShowDialog();
        }
        private void StoolReportMenu_Click(object sender, RoutedEventArgs e)
        {
            var rp = new ReportPage(DocTestType.Stool);
            rp.ShowDialog();
        }
        private void PregnancyTestReportMenu_Click(object sender, RoutedEventArgs e)
        {
            var rp = new ReportPage(DocTestType.PregnancyTest);
            rp.ShowDialog();
        }
        private void CbcReportMenu_Click(object sender, RoutedEventArgs e)
        {
            var rp = new ReportPage(DocTestType.CBC);
            rp.ShowDialog();
        }
        private void BloodTypingReportMenu_Click(object sender, RoutedEventArgs e)
        {
            var rp = new ReportPage(DocTestType.BloodTyping);
            rp.ShowDialog();
        }
        private void HIVReportMenu_Click(object sender, RoutedEventArgs e)
        {
            var rp = new ReportPage(DocTestType.HIV);
            rp.ShowDialog();
        }
        private void HepCReportMenu_Click(object sender, RoutedEventArgs e)
        {
            var rp = new ReportPage(DocTestType.HepC);
            rp.ShowDialog();
        }
        private void HepBReportMenu_Click(object sender, RoutedEventArgs e)
        {
            var rp = new ReportPage(DocTestType.HepB);
            rp.ShowDialog();
        }
        private void HepAReportMenu_Click(object sender, RoutedEventArgs e)
        {
            var rp = new ReportPage(DocTestType.HepA);
            rp.ShowDialog();
        }
        private void BloodTestReportMenu_Click(object sender, RoutedEventArgs e)
        {
            var rp = new ReportPage(DocTestType.BloodTest);
            rp.ShowDialog();
        }
        private void PsychologicalTestSummaryMenu_Click(object sender, RoutedEventArgs e)
        {
            var rp = new ReportPage(DocTestType.Neuro);
            rp.ShowDialog();
        }
        private void XraySummaryMenu_Click(object sender, RoutedEventArgs e)
        {
            var rp = new ReportPage(DocTestType.XRay);
            rp.ShowDialog();
        }
        #endregion
        #region FUNCTIONS
        private void ShowStopMessage(string message)
        {
            MessageBox.Show(message, nameof(MainForm), MessageBoxButton.OK, MessageBoxImage.Stop);
        }
        #endregion
        #region PROPERTIES
        public cmdldbDataSet Cmdl
        {
            get { return cmdl; }
            set
            {
                cmdl = value;
            }
        }
        #endregion





    }
}
