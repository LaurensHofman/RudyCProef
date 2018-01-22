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
using RudycommerceLibrary.BL;
using RudycommerceLibrary.Entities;

namespace Rudycommerce
{
    /// <summary>
    /// Interaction logic for ManageAccount.xaml
    /// </summary>
    public partial class ManageAccount : UserControl
    {
        public delegate void AccountSaved(string selectedLanguage);
        public event AccountSaved OnAccountSave;

        string _preferredLanguage;
        public DesktopUser CurrentUser { get; set; }

        public ManageAccount(int currentUserID)
        {
            InitializeComponent();

            CurrentUser = BL_DesktopUser.GetCurrentUserByID(currentUserID);
            _preferredLanguage = CurrentUser.PreferredLanguage;

            SelectRadioButtonByLanguage();
        }

        private void SelectRadioButtonByLanguage()
        {
            switch (_preferredLanguage)
            {
                case "Nederlands":
                    rbPreferNL.IsChecked = true;
                    break;
                case "English":
                    rbPreferEN.IsChecked = true;
                    break;
                default:
                    rbPreferNL.IsChecked = true;
                    break;
            }
        }

        private void SetLanguageDictionary(string selectedLanguage)
        {
            ResourceDictionary dict = new ResourceDictionary();

            dict.Source = new Uri(BL_Multilingual.ChooseLanguageDictionary(selectedLanguage), UriKind.Relative);

            this.Resources.MergedDictionaries.Add(dict);
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            if (rbPreferNL.IsChecked == true)
            {
                CurrentUser.PreferredLanguage = "Nederlands";
                SetLanguageDictionary(CurrentUser.PreferredLanguage);
            }
            if (rbPreferEN.IsChecked == true)
            {
                CurrentUser.PreferredLanguage = "English";
                SetLanguageDictionary(CurrentUser.PreferredLanguage);
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            BL_DesktopUser.Update(CurrentUser);
            OnAccountSave(CurrentUser.PreferredLanguage);
        }
    }
}
