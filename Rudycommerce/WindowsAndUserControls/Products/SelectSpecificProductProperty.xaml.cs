using RudycommerceLibrary.Models;
using RudycommerceLibrary.BL;
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
using RudycommerceLibrary;

namespace Rudycommerce
{
    /// <summary>
    /// Interaction logic for SelectSpecificProductProperty.xaml
    /// </summary>
    public partial class SelectSpecificProductProperty : UserControl
    {
        public delegate void SelectProperty(PropertyAndName propertyAndName);
        public event SelectProperty OnSelectionProperty;

        ObservableCollection<PropertyAndName> PropertyAndNamesList { get; set; }

        public SelectSpecificProductProperty()
        {
            InitializeComponent();

            grdSelectSpecificProductProperty.DataContext = this;

            PropertyAndNamesList = new ObservableCollection<PropertyAndName>(BL_SpecificProductProperty.GetListWithNames(Settings.UserLanguage));

            dgSelectProperty.ItemsSource = PropertyAndNamesList;
            dgSelectProperty.DataContext = PropertyAndNamesList;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var property = ((FrameworkElement)sender).DataContext as PropertyAndName;

            OnSelectionProperty(property);
        }
    }
}
