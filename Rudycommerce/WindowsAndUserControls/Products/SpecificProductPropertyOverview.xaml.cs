using RudycommerceLibrary;
using RudycommerceLibrary.BL;
using RudycommerceLibrary.Entities;
using RudycommerceLibrary.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Rudycommerce.WindowsAndUserControls.Products
{
    /// <summary>
    /// Interaction logic for SpecificProductPropertyOverview.xaml
    /// </summary>
    public partial class SpecificProductPropertyOverview : UserControl
    {
        public ObservableCollection<SpecificProductPropertyOverViewItem> PropertyOverview { get; set; }

        public SpecificProductPropertyOverview()
        {
            InitializeComponent();

            SetLanguageDictionary(UserSettings.UserLanguage);

            LoadDataGridItems();
        }

        private void LoadDataGridItems()
        {
            PropertyOverview = new ObservableCollection<SpecificProductPropertyOverViewItem>(BL_SpecificProductProperty.GetPropertyOverview(UserSettings.UserLanguage));
            BindData();
        }

        private void BindData()
        {
            dgPropOverview.ItemsSource = PropertyOverview;
            dgPropOverview.DataContext = PropertyOverview; 
        }

        private void SetLanguageDictionary(Language selectedLanguage)
        {
            ResourceDictionary dict = new ResourceDictionary();

            dict.Source = new Uri(BL_Multilingual.ChooseLanguageDictionary(selectedLanguage), UriKind.Relative);

            this.Resources.MergedDictionaries.Add(dict);
        }
    }
}
