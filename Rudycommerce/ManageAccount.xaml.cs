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

namespace Rudycommerce
{
    /// <summary>
    /// Interaction logic for ManageAccount.xaml
    /// </summary>
    public partial class ManageAccount : UserControl
    {
        string _selectedLanguage;

        public delegate void AccountSaved(string selectedLanguage);
        public event AccountSaved OnAccountSave;

        public ManageAccount()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            _selectedLanguage = cmbxLanguage.SelectedValue.ToString();
            OnAccountSave(_selectedLanguage);
        }        
    }
}
