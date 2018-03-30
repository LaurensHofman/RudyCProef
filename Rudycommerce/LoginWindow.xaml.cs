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
using System.Windows.Shapes;
using RudycommerceLibrary.BL;
using RudycommerceLibrary.Entities;

namespace Rudycommerce
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        Language _preferredLanguage;
        private List<Language> _LanguageList;

        public LoginWindow()
        {
            InitializeComponent();

            AnyDesktopUser();

            _LanguageList = BL_Language.GetDesktopLanguages();

            rbPreferNL.IsChecked = true;
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            if (rbPreferNL.IsChecked == true)
            {
                _preferredLanguage = _LanguageList.Single(l => l.LocalName == "Nederlands");
                SetLanguageDictionary(_preferredLanguage);
            }
            if (rbPreferEN.IsChecked == true)
            {
                _preferredLanguage = _LanguageList.Single(l => l.LocalName == "English");
                SetLanguageDictionary(_preferredLanguage);
            }
        }

        private void SetLanguageDictionary(Language selectedLanguage)
        {
            ResourceDictionary dict = new ResourceDictionary();

            dict.Source = new Uri(BL_Multilingual.ChooseLanguageDictionary(selectedLanguage), UriKind.Relative);

            this.Resources.MergedDictionaries.Add(dict);
        }

        private void AnyDesktopUser()
        {
            if (BL_DesktopUser.AnyDesktopUser())
            {
                txtUsername.Focus();
            }
            else
            {
                AdminUserForm NewDesktopUser = new AdminUserForm();
                NewDesktopUser.Show();
                this.Close();
            }
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (BL_DesktopUser.Authenticate(txtUsername.Text, pwdPassword.Password))
            {
                int CurrentUserID = BL_DesktopUser.GetUserID(txtUsername.Text);
                NavigationWindow naviWindow = new NavigationWindow(CurrentUserID);
                naviWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("OOPS");
            }
        }
        
        private void btnNewUser_Click(object sender, RoutedEventArgs e)
        {
            NewDesktopUser NewDesktopUser = new NewDesktopUser(_preferredLanguage);
            NewDesktopUser.Show();
            this.Close();
        }

        private void btnLazy_Click(object sender, RoutedEventArgs e)
        {
            pwdPassword.Password = "laurens";
            txtUsername.Text = "laurenshofman";
            btnLogin_Click(null, null);
        }
    }
}
