using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;

namespace Contextualizer
{
    /// <summary>
    /// Logique d'interaction pour AddNew_UC.xaml
    /// </summary>
    public partial class AddNew_UC : UserControl
    {
        public AddNew_UC()
        {
            InitializeComponent();
        }

        private void ExecPath_Click_1(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            Nullable<bool> res = dlg.ShowDialog();
            if (res == true)
            {
                this.ExecPathTextBox.Text = dlg.FileName;
            }
        }

        private void ValideAdd_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                string rep = (string)Registry.GetValue(@"HKEY_CLASSES_ROOT\Directory\Background\shell\powershella", "", null);
                if (rep != null)
                {
                    this.NameAdd.Text = rep;
                }
                else
                {
                    throw new Exception("La clé de registre n'existe pas");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur : " + ex.Message, "Erreur");
            }
        }
    }
}
