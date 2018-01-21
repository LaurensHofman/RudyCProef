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
        string _selectedLanguage;

        public NavigationWindow(string selectedLanguage)
        {
            InitializeComponent();
            _selectedLanguage = selectedLanguage;
            SetLanguageDictionary(_selectedLanguage);
        }

        public NavigationWindow() : this ("Nederlands")
        {

        }
                
        private void rbtnAddLanguage_Click(object sender, RoutedEventArgs e)
        {
            navigationControl.Content = new LanguageForm(_selectedLanguage);
        }

        private void rbtnAddProduct_Click(object sender, RoutedEventArgs e)
        {
            navigationControl.Content = new NewProductForm();
        }

        private void rbtnOverviewLanguage_Click(object sender, RoutedEventArgs e)
        {
            navigationControl.Content = new Test();
        }

        private void SetLanguageDictionary(string selectedLanguage)
        {
            ResourceDictionary dict = new ResourceDictionary();

            dict.Source = new Uri(BL_Multilingual.ChooseLanguageDictionary(selectedLanguage), UriKind.Relative);
            
            this.Resources.MergedDictionaries.Add(dict);
        }

        private void ramiManageCurrentAccount_Click(object sender, RoutedEventArgs e)
        {
            var _settings = new ManageAccount();
            _settings.OnAccountSave += ApplySettings;

            navigationControl.Content = _settings;
        }

        private void ApplySettings(string selectedLanguage)
        {
            _selectedLanguage = selectedLanguage;
            SetLanguageDictionary(selectedLanguage);
            navigationControl.Content = null;
        }
    }
}
