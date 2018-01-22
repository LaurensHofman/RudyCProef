using RudycommerceLibrary.BL;
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
        int _currentUserID = 0;
        string _preferredLanguage = "Nederlands";

        public NavigationWindow(int currentUserID)
        {
            InitializeComponent();
            _currentUserID = currentUserID;

            SetLanguage(currentUserID);
        }

        private void SetLanguage(int currentUserID)
        {
            _preferredLanguage = BL_DesktopUser.UserPreferredLanguage(currentUserID);
            SetLanguageDictionary(_preferredLanguage);
        }
        
        private void SetLanguageDictionary(string selectedLanguage)
        {
            ResourceDictionary dict = new ResourceDictionary();

            dict.Source = new Uri(BL_Multilingual.ChooseLanguageDictionary(selectedLanguage), UriKind.Relative);

            this.Resources.MergedDictionaries.Add(dict);
        }
        
        private void rbtnAddLanguage_Click(object sender, RoutedEventArgs e)
        {
            navigationControl.Content = new LanguageForm(_preferredLanguage);
        }

        private void rbtnAddProduct_Click(object sender, RoutedEventArgs e)
        {
            navigationControl.Content = new NewProductForm();
        }

        private void rbtnOverviewLanguage_Click(object sender, RoutedEventArgs e)
        {
            //navigationControl.Content = new Test();
        }

        private void ramiManageCurrentAccount_Click(object sender, RoutedEventArgs e)
        {
            var _settings = new ManageAccount(_currentUserID);
            _settings.OnAccountSave += ApplySettings;

            navigationControl.Content = _settings;
        }

        private void ApplySettings(string selectedLanguage)
        {
            _preferredLanguage = selectedLanguage;
            SetLanguageDictionary(selectedLanguage);
            navigationControl.Content = null;
        }

        private void rbtnUserOverview_Click(object sender, RoutedEventArgs e)
        {
            navigationControl.Content = new UserOverview();
        }
    }
}
