using MahApps.Metro.Controls;
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
    public partial class NavigationWindow : MetroWindow
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
                tabItemUsers.IsEnabled = true;
                tabItemUsers.Visibility = Visibility.Visible;
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
      
        private void tabTileAddProduct_Click(object sender, RoutedEventArgs e)
        {
            userControlProducts.Content = new NewProductForm();
        }

        private void tabTileAddCategory_Click(object sender, RoutedEventArgs e)
        {
            userControlProducts.Content = new CategoryForm();
        }

        private void tabTileAddProductProperty_Click(object sender, RoutedEventArgs e)
        {
            userControlProducts.Content = new SpecificProductPropertyForm();
        }

        private void tabTileAddLanguage_Click(object sender, RoutedEventArgs e)
        {
            userControlLanguages.Content = new LanguageForm();
        }

        private void tabTileLanguageOverview_Click(object sender, RoutedEventArgs e)
        {
            userControlLanguages.Content = new LanguageOverview();
        }

        private void tabTileUserOverview_Click(object sender, RoutedEventArgs e)
        {
            UserOverview _userOverview = new UserOverview();
            _userOverview.LostAdminRights += LogOut;

            userControlUsers.Content = _userOverview;
        }

        private void LogOut()
        {
            LoginWindow relogWindow = new LoginWindow();
            relogWindow.Show();

            this.Close();
        }
        
        private void btnSettings_Click(object sender, RoutedEventArgs e)
        {
            tabItemSettings.IsSelected = true;

            var _settings = new ManageAccount();
            _settings.OnAccountSave += ApplySettings;

            userControlSettings.Content = _settings;
        }

        private void ApplySettings(Language selectedLanguage)
        {
            Settings.UserLanguage = selectedLanguage;

            SetLanguageDictionary(RudycommerceLibrary.Settings.UserLanguage);
            userControlSettings.Content = null;
        }
    }
}
