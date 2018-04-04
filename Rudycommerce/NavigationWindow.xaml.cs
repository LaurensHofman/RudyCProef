using RudycommerceLibrary;
using RudycommerceLibrary.BL;
using RudycommerceLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Ribbon;
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
    /// Interaction logic for NavigationWindow.xaml
    /// </summary>
    public partial class NavigationWindow : RibbonWindow
    {
        public NavigationWindow(int currentUserID)
        {
            InitializeComponent();
            Settings.SetDesktopUser(currentUserID);

            SetLanguage();
            EnableUserTab();
        }

        private void EnableUserTab()
        {
            if (Settings.CurrentUser.IsAdmin == true)
            {
                rtabUsers.IsEnabled = true;
                rtabUsers.Visibility = Visibility.Visible;
            }
        }

        private void SetLanguage()
        {
            Settings.UserLanguage = BL_DesktopUser.UserPreferredLanguage(Settings.CurrentUser.UserID);
            SetLanguageDictionary(RudycommerceLibrary.Settings.UserLanguage);
        }
        
        private void SetLanguageDictionary(Language selectedLanguage)
        {
            ResourceDictionary dict = new ResourceDictionary();

            dict.Source = new Uri(BL_Multilingual.ChooseLanguageDictionary(selectedLanguage), UriKind.Relative);

            this.Resources.MergedDictionaries.Add(dict);
        }
        
        private void rbtnAddLanguage_Click(object sender, RoutedEventArgs e)
        {
            navigationControl.Content = new LanguageForm();
        }

        private void rbtnAddProduct_Click(object sender, RoutedEventArgs e)
        {
            navigationControl.Content = new NewProductForm();
        }

        private void rbtnOverviewLanguage_Click(object sender, RoutedEventArgs e)
        {
            navigationControl.Content = new LanguageOverview();
        }

        private void ramiManageCurrentAccount_Click(object sender, RoutedEventArgs e)
        {
            var _settings = new ManageAccount();
            _settings.OnAccountSave += ApplySettings;

            navigationControl.Content = _settings;
        }

        private void ApplySettings(Language selectedLanguage)
        {
            Settings.UserLanguage = selectedLanguage;
            
            SetLanguageDictionary(RudycommerceLibrary.Settings.UserLanguage);
            navigationControl.Content = null;
        }

        private void rbtnUserOverview_Click(object sender, RoutedEventArgs e)
        {
            UserOverview _userOverview = new UserOverview();
            _userOverview.LostAdminRights += LogOut;

            navigationControl.Content = _userOverview;
        }

        private void LogOut()
        {
            LoginWindow relogWindow = new LoginWindow();
            relogWindow.Show();

            this.Close();
        }

        private void rbtnAddCategory_Click(object sender, RoutedEventArgs e)
        {
            navigationControl.Content = new CategoryForm();
        }

        private void rbtnAddSpecificProductProperty_Click(object sender, RoutedEventArgs e)
        {
            navigationControl.Content = new SpecificProductPropertyForm();
        }
    }
}
