using RudycommerceLibrary.Entities;
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
using RudycommerceLibrary.Utilities;
using System.Reflection;

namespace Rudycommerce
{
    /// <summary>
    /// Interaction logic for DesktopUserForm.xaml
    /// </summary>
    public partial class AdminUserForm : Window
    {
        public DesktopUser NewDesktopUser { get; set; }
        private List<Language> _languageList { get; set; }

        public AdminUserForm()
        {
            InitializeComponent();

            _languageList = BL_Language.GetDesktopLanguages();

            DesktopUser newDesktopUser = new DesktopUser();
            NewDesktopUser = newDesktopUser;
            rbPreferNL.IsChecked = true;
        }

        private void SetLanguageDictionary(Language selectedLanguage)
        {
            ResourceDictionary dict = new ResourceDictionary();

            dict.Source = new Uri(BL_Multilingual.ChooseLanguageDictionary(selectedLanguage), UriKind.Relative);

            this.Resources.MergedDictionaries.Add(dict);
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            //TODO ModelBinding & Validations

            NewDesktopUser.FirstName = txtFirstName.Text;
            NewDesktopUser.LastName = txtLastName.Text;
            NewDesktopUser.EMail = txtEmail.Text;
            NewDesktopUser.Username = txtUsername.Text;
            NewDesktopUser.IsAdmin = true;
            NewDesktopUser.VerifiedByAdmin = true;

            NewDesktopUser.Salt = BL_Encryption.GenerateSalt();
            NewDesktopUser.EncryptedPassword = BL_Encryption.EncryptPassword(NewDesktopUser.Salt, pwdPassword.Password);

            try
            {
                if (StringExtensions.IsEmailAddress(NewDesktopUser.EMail))
                {
                    BL_DesktopUser.Create(NewDesktopUser);
                    NavigationWindow naviWin = new NavigationWindow(NewDesktopUser.UserID);
                    naviWin.Show();

                    this.Close();
                }
                else
                {
                    MessageBox.Show("Geen goed email");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            if (rbPreferNL.IsChecked == true)
            {
                //
                //
                // TODO The 2 languages need to exist already - ADD TRYCATCH
                //
                //
                NewDesktopUser.PreferredLanguageID = _languageList.Single(l => l.LocalName == "Nederlands").LanguageID;
                SetLanguageDictionary(NewDesktopUser.PreferredLanguage);
            }
            if (rbPreferEN.IsChecked == true)
            {
                NewDesktopUser.PreferredLanguageID = _languageList.Single(l => l.LocalName == "English").LanguageID;
                SetLanguageDictionary(NewDesktopUser.PreferredLanguage);
            }
        }

        private void pwdPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            txtPasswordVisible.Text = pwdPassword.Password;

            int start = pwdPassword.Password.Length;
            int length = 0;
            pwdPassword.GetType().GetMethod("Select", BindingFlags.Instance | BindingFlags.NonPublic)
                    .Invoke(pwdPassword, new object[] { start, length });
        }

        private void txtPasswordVisible_TextChanged(object sender, TextChangedEventArgs e)
        {
            pwdPassword.Password = txtPasswordVisible.Text;

            int start = txtPasswordVisible.Text.Length;
            int length = 0;
            txtPasswordVisible.Select(start, length);
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

    }
}
