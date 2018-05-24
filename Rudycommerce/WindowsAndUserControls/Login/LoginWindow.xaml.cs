using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using RudycommerceLibrary.BL;
using RudycommerceLibrary.Entities;
using RudycommerceLibrary.Properties;

namespace Rudycommerce
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        Language _preferredLanguage;
        private List<Language> _LanguageList;
        private bool newWindow = false;

        public LoginWindow()
        {
            InitializeComponent();            

            try
            {
                AnyDesktopUser();
                _LanguageList = BL_Language.GetDesktopLanguages();
                rbPreferNL.IsChecked = true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error");
                newWindow = true;
                this.Close();
            }

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
            try
            {
                bool anyDesktopUser = BL_DesktopUser.AnyDesktopUser();

                if (BL_DesktopUser.AnyDesktopUser())
                {
                    txtUsername.Focus();
                }
                else
                {
                    newWindow = true;
                    AdminUserForm NewDesktopUser = new AdminUserForm();
                    NewDesktopUser.Show();
                    this.Close();
                }
            }
            catch (/*NoDatabaseConnectionError*/ Exception ex)
            {
                MessageBox.Show(ex.Message);
                newWindow = true;
                this.Close();
            }
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            // TODO Validations

            if (BL_DesktopUser.Authenticate(txtUsername.Text, pwdPassword.Password))
            {
                int CurrentUserID = BL_DesktopUser.GetUserID(txtUsername.Text);
                NavigationWindow naviWindow = new NavigationWindow(CurrentUserID);
                naviWindow.Show();
                newWindow = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("OOPS");
            }
        }

        private void btnShowHidePwd_Click(object sender, RoutedEventArgs e)
        {
            btnShowHidePwd.Content =
                (txtPasswordVisible.Visibility == Visibility.Collapsed) ?
                FindResource("Hide") : FindResource("Show");

            ToggleShowPassword();
        }

        private void ToggleShowPassword()
        {
            if (txtPasswordVisible.Visibility == Visibility.Collapsed)
            {
                txtPasswordVisible.Visibility = Visibility.Visible;
                pwdPassword.Visibility = Visibility.Collapsed;
                txtPasswordVisible.Focus();
            }
            else
            {
                pwdPassword.Visibility = Visibility.Visible;
                txtPasswordVisible.Visibility = Visibility.Collapsed;
                pwdPassword.Focus();
            }
        }

        private void btnNewUser_Click(object sender, RoutedEventArgs e)
        {
            NewDesktopUser NewDesktopUser = new NewDesktopUser(_preferredLanguage);
            NewDesktopUser.Show();
            newWindow = true;
            this.Close();
        }

        private void btnLazy_Click(object sender, RoutedEventArgs e)
        {
            txtUsername.Text = "laurens";
            pwdPassword.Password = "laurens";
            btnLogin_Click(null, null);
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (newWindow)
            {
                e.Cancel = false;
            }
            else
            {
                string messageboxContent = LangResource.MBExitContent;
                string messageboxTitle = LangResource.MBExitTitle;

                MessageBoxManager.Yes = LangResource.Yes;
                MessageBoxManager.No = LangResource.No;
                MessageBoxManager.Register();

                if (MessageBox.Show(messageboxContent, messageboxTitle, MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    MessageBoxManager.Unregister();

                    e.Cancel = false;
                }
                else
                {
                    MessageBoxManager.Unregister();
                    e.Cancel = true;
                }  
            }
        }

        private void txtPasswordVisible_TextChanged(object sender, TextChangedEventArgs e)
        {
            pwdPassword.Password = txtPasswordVisible.Text;

            int start = txtPasswordVisible.Text.Length;
            int length = 0;
            txtPasswordVisible.Select(start, length);
        }

        private void pwdPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            txtPasswordVisible.Text = pwdPassword.Password;

            int start = pwdPassword.Password.Length;
            int length = 0;
            pwdPassword.GetType().GetMethod("Select", BindingFlags.Instance | BindingFlags.NonPublic)
                    .Invoke(pwdPassword, new object[] { start, length });
        }
    }
}
