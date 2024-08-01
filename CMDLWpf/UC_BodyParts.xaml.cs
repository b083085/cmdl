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
    /// Interaction logic for UC_BodyParts.xaml
    /// </summary>
    public partial class UC_BodyParts : UserControl
    {
        public UC_BodyParts()
        {
            InitializeComponent();
        }

        public bool ValidateEntries()
        {
            if (!String.IsNullOrWhiteSpace(cbEars.Text))
            {
                if (!String.IsNullOrWhiteSpace(cbNoseThroat.Text))
                {
                    if (!String.IsNullOrWhiteSpace(cbDentals.Text))
                    {
                        if (!String.IsNullOrWhiteSpace(cbBreast.Text))
                        {
                            if (!String.IsNullOrWhiteSpace(cbExtremities.Text))
                            {
                                if (!String.IsNullOrWhiteSpace(cbNeurolog.Text))
                                {
                                    if (!String.IsNullOrWhiteSpace(cbHeart.Text))
                                    {
                                        if (!String.IsNullOrWhiteSpace(cbLungs.Text))
                                        {
                                            if (!String.IsNullOrWhiteSpace(cbAbdomen.Text))
                                            {
                                                if (!String.IsNullOrWhiteSpace(cbGenitalia.Text))
                                                {
                                                    if (!String.IsNullOrWhiteSpace(cbAnoRectal.Text))
                                                    {
                                                        if (!String.IsNullOrWhiteSpace(cbSkin.Text))
                                                        {
                                                            if (!String.IsNullOrWhiteSpace(cbOthers.Text))
                                                            {
                                                                if (!String.IsNullOrWhiteSpace(cbMedicalHistory.Text))
                                                                {
                                                                    return true;
                                                                }
                                                                else
                                                                {
                                                                    MessageBox.Show("Medical History not specified!", "Validation Message", MessageBoxButton.OK, MessageBoxImage.Stop);
                                                                }
                                                            }
                                                            else
                                                            {
                                                                MessageBox.Show("Others not specified!", "Validation Message", MessageBoxButton.OK, MessageBoxImage.Stop);
                                                            }
                                                        }
                                                        else
                                                        {
                                                            MessageBox.Show("Skin not specified!", "Validation Message", MessageBoxButton.OK, MessageBoxImage.Stop);
                                                        }
                                                    }
                                                    else
                                                    {
                                                        MessageBox.Show("Ano-Rectal not specified!", "Validation Message", MessageBoxButton.OK, MessageBoxImage.Stop);
                                                    }
                                                }
                                                else
                                                {
                                                    MessageBox.Show("Genitalia not specified!", "Validation Message", MessageBoxButton.OK, MessageBoxImage.Stop);
                                                }
                                            }
                                            else
                                            {
                                                MessageBox.Show("Abdomen not specified!", "Validation Message", MessageBoxButton.OK, MessageBoxImage.Stop);
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show("Lungs not specified!", "Validation Message", MessageBoxButton.OK, MessageBoxImage.Stop);
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Heart not specified!", "Validation Message", MessageBoxButton.OK, MessageBoxImage.Stop);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Neurologic not specified!", "Validation Message", MessageBoxButton.OK, MessageBoxImage.Stop);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Extremities not specified!", "Validation Message", MessageBoxButton.OK, MessageBoxImage.Stop);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Breast / Chest not specified!", "Validation Message", MessageBoxButton.OK, MessageBoxImage.Stop);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Dentals not specified!", "Validation Message", MessageBoxButton.OK, MessageBoxImage.Stop);
                    }
                }
                else
                {
                    MessageBox.Show("Nose/Throat not specified!", "Validation Message", MessageBoxButton.OK, MessageBoxImage.Stop);
                }
            }
            else
            {
                MessageBox.Show("Ears not specified!", "Validation Message", MessageBoxButton.OK, MessageBoxImage.Stop);
            }

            return false;
        }

        public void BindingDataContext(Test_PE obj)
        {
            this.DataContext = obj;
        }
    }
}
