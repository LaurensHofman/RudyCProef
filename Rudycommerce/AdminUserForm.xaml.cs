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

namespace Rudycommerce
{
    /// <summary>
    /// Interaction logic for DesktopUserForm.xaml
    /// </summary>
    public partial class AdminUserForm : Window
    {
        public DesktopUser NewDesktopUser { get; set; }

        public AdminUserForm()
        {
            InitializeComponent();

            DesktopUser newDesktopUser = new DesktopUser();
            NewDesktopUser = newDesktopUser;
            rbPreferNL.IsChecked = true;
        }

        private void SetLanguageDictionary(string selectedLanguage)
        {
            ResourceDictionary dict = new ResourceDictionary();

            dict.Source = new Uri(BL_Multilingual.ChooseLanguageDictionary(selectedLanguage), UriKind.Relative);

            this.Resources.MergedDictionaries.Add(dict);
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
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
                NewDesktopUser.PreferredLanguage = "Nederlands";
                SetLanguageDictionary(NewDesktopUser.PreferredLanguage);
            }
            if (rbPreferEN.IsChecked == true)
            {
                NewDesktopUser.PreferredLanguage = "English";
                SetLanguageDictionary(NewDesktopUser.PreferredLanguage);
            }
        }
    }
}
