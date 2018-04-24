using RudycommerceLibrary;
using RudycommerceLibrary.BL;
using RudycommerceLibrary.Entities;
using RudycommerceLibrary.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Rudycommerce.WindowsAndUserControls.Products
{
    /// <summary>
    /// Interaction logic for ProductOverview.xaml
    /// </summary>
    public partial class ProductOverview : UserControl
    {
        public ObservableCollection<ProductOverViewItem> ProductOverviewList { get; set; }

        public ProductOverview()
        {
            InitializeComponent();

            SetLanguageDictionary(Settings.UserLanguage);

            SetDataGridContent();            
        }

        private void SetLanguageDictionary(Language selectedLanguage)
        {
            ResourceDictionary dict = new ResourceDictionary();

            dict.Source = new Uri(BL_Multilingual.ChooseLanguageDictionary(selectedLanguage), UriKind.Relative);

            this.Resources.MergedDictionaries.Add(dict);
        }

        private void SetDataGridContent()
        {
            ProductOverviewList = new ObservableCollection<ProductOverViewItem>( BL_Product.GetProductOverview(Settings.UserLanguage) );
            BindData();
        }

        private void BindData()
        {
            dgProductOverview.DataContext = ProductOverviewList;
            dgProductOverview.ItemsSource = ProductOverviewList; 
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
        }

        private void ModifyProduct_Click(object sender, RoutedEventArgs e)
        {
            //int productID = (((FrameworkElement)sender).DataContext as ProductOverViewItem).ProductID;

            //this.Content = new NewProductForm(productID);
        }
    }
}
