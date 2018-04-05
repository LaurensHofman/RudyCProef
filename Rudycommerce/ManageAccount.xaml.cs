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
using RudycommerceLibrary;
using RudycommerceLibrary.BL;
using RudycommerceLibrary.Entities;

namespace Rudycommerce
{
    /// <summary>
    /// Interaction logic for ManageAccount.xaml
    /// </summary>
    public partial class ManageAccount : UserControl
    {
        public delegate void AccountSaved(Language selectedLanguage);
        public event AccountSaved OnAccountSave;

        private Language _preferredLanguage;
        private List<Language> _languageList;

        public ManageAccount()
        {
            InitializeComponent();

            _preferredLanguage = BL_Language.GetLanguageByID(Settings.UserLanguage.LanguageID);
            _languageList = BL_Language.GetDesktopLanguages();

            SelectRadioButtonByLanguage();
        }

        private void SelectRadioButtonByLanguage()
        {
            switch (_preferredLanguage.LocalName)
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

        private void SetLanguageDictionary(Language selectedLanguage)
        {
            ResourceDictionary dict = new ResourceDictionary();

            dict.Source = new Uri(BL_Multilingual.ChooseLanguageDictionary(selectedLanguage), UriKind.Relative);

            this.Resources.MergedDictionaries.Add(dict);
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            if (rbPreferNL.IsChecked == true)
            {
                _preferredLanguage = _languageList.Single(l => l.LocalName == "Nederlands");
                Settings.CurrentUser.PreferredLanguageID = _preferredLanguage.LanguageID;
                SetLanguageDictionary(_preferredLanguage);
            }
            if (rbPreferEN.IsChecked == true)
            {
                _preferredLanguage = _languageList.Single(l => l.LocalName == "English");
                Settings.CurrentUser.PreferredLanguageID = _preferredLanguage.LanguageID;
                SetLanguageDictionary(_preferredLanguage);
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            BL_DesktopUser.Update(Settings.CurrentUser);
            OnAccountSave(_preferredLanguage);
        }
    }
}
