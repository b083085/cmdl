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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CMDLWpf
{
    /// <summary>
    /// Interaction logic for UC_Neuro.xaml
    /// </summary>
    public partial class UC_Neuro : UserControl
    {

        List<Psychologist> psychologistList;
        List<Psychiatrist> psychiatristList;

        public UC_Neuro(Test_Neuro obj)
        {
            InitializeComponent();
            this.DataContext = obj;
        }

        public List<Psychologist> PsychologistList
        {
            set
            {
                foreach (var p in value)
                    cbPsychologist.Items.Add(p.Name);

                psychologistList = value;
            }
        }

        public List<Psychiatrist> PsychiatristList
        {
            set
            {
                foreach (var p in value)
                    cbPsychiatrist.Items.Add(p.Name);

                psychiatristList = value;
            }
        }
    }
}
