using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.IO;
using System.ComponentModel;
using System.Data;
using CMDL.Models;

namespace CMDL
{
    /// <summary>
    /// Interaction logic for NeuroEditForm.xaml
    /// </summary>
    public partial class NeuroEditForm : Window
    {

        public event Action SaveRecordEvent;


        public NeuroEditForm()
        {
            InitializeComponent();
        }

        public void SetBinding(NeuroItemV2 item)
        {
            if (item.Version1)
            {
                var v1 = new NeuroV1Page();
                v1.SetBinding(item);

                scrollViewer.Content = v1;
            }
            else if (item.Version2)
            {
                var v2 = new NeuroV2Page();
                v2.SaveRecordEvent += V2_SaveRecordEvent;
                v2.SetBinding(item);

                scrollViewer.Content = v2;

            }
            else
            {
                var v3 = new NeuroV3Page();
                v3.SaveRecordEvent += V2_SaveRecordEvent;
                v3.SetBinding(item);

                scrollViewer.Content = v3;
            }
        }

        private void V2_SaveRecordEvent()
        {
            SaveRecordEvent?.Invoke();
        }
    }
}






