﻿using RudycommerceLibrary.BL;
using RudycommerceLibrary.Entities;
using RudycommerceLibrary.Utilities;
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

namespace Rudycommerce
{
    /// <summary>
    /// Interaction logic for NewDesktopUser.xaml
    /// </summary>
    public partial class NewDesktopUser : Window
    {
        public DesktopUser NewUser { get; set; }
        private List<Language> _languageList;

        public NewDesktopUser(Language preferredLanguage)
        {
            InitializeComponent();

            NewUser = new DesktopUser();

            _languageList = BL_Language.GetDesktopLanguages();

            SelectRadioButtonByLanguage(preferredLanguage);

            
        }

        private void SelectRadioButtonByLanguage(Language preferredLanguage)
        {
            switch (preferredLanguage.LocalName)
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
                NewUser.PreferredLanguageID = _languageList.Single(l => l.LocalName == "Nederlands").LanguageID;
                SetLanguageDictionary(NewUser.PreferredLanguage);

            }
            if (rbPreferEN.IsChecked == true)
            {
                NewUser.PreferredLanguageID = _languageList.Single(l => l.LocalName == "English").LanguageID;
                SetLanguageDictionary(NewUser.PreferredLanguage);
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            NewUser.FirstName = txtFirstName.Text;
            NewUser.LastName = txtLastName.Text;
            NewUser.EMail = txtEmail.Text;
            NewUser.Username = txtUsername.Text;
            NewUser.IsAdmin = false;
            NewUser.VerifiedByAdmin = false;

            NewUser.Salt = BL_Encryption.GenerateSalt();
            NewUser.EncryptedPassword = BL_Encryption.EncryptPassword(NewUser.Salt, pwdPassword.Password);

            try
            {
                if (StringExtensions.IsEmailAddress(NewUser.EMail))
                {
                    BL_DesktopUser.Create(NewUser);

                    BL_Mailing.SendMailToAdmin(NewUser.FirstName, NewUser.LastName, NewUser.EMail, NewUser.Username);
                    BL_Mailing.SendMailToUser(NewUser.FirstName, NewUser.LastName, NewUser.EMail, NewUser.Username, NewUser.PreferredLanguage.LocalName);

                    LoginWindow login = new LoginWindow();
                    login.Show();

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
    }
}