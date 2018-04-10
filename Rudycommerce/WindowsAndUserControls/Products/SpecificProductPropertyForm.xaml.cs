using RudycommerceLibrary.BL;
using RudycommerceLibrary.Entities;
using RudycommerceLibrary.Entities.ProductsAndCategories;
using RudycommerceLibrary.Entities.ProductsAndCategories.Localized;
using RudycommerceLibrary.Models;
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

namespace Rudycommerce
{
    /// <summary>
    /// Interaction logic for SpecificProductPropertyForm.xaml
    /// </summary>
    public partial class SpecificProductPropertyForm : UserControl
    {
        public SpecificProductProperty SpecificProductPropertyModel { get; set; }
        public ObservableCollection<LanguageAndSpecificPropertyItem> LanguageAndSpecificPropertyList { get; set; }

        public List<LocalizedLanguageItem> LanguageList { get; set; }

        public SpecificProductPropertyForm()
        {
            InitializeComponent();

            InitializeModelsAndContents();

            SetLanguageDictionary(RudycommerceLibrary.Settings.UserLanguage);
        }

        private void InitializeModelsAndContents()
        {
            SpecificProductPropertyModel = new SpecificProductProperty();

            // gets active languages
            LanguageList = BL_Multilingual.GetLocalizedListOfLanguages(RudycommerceLibrary.Settings.UserLanguage);

            // creates items for the datagrid, based on the active languages
            LanguageAndSpecificPropertyList = new ObservableCollection<LanguageAndSpecificPropertyItem>();
            foreach (LocalizedLanguageItem li in LanguageList)
            {
                LanguageAndSpecificPropertyList.Add(
                new LanguageAndSpecificPropertyItem() { LanguageID = li.ID, LanguageName = li.Name, PropertyName = null });
            }

            grdSpecificProductPropertyForm.DataContext = this;

            SetDataGridItemsToModelList();
        }

        private void SetDataGridItemsToModelList()
        {
            dgLocalizedSpecificProperties.ItemsSource = LanguageAndSpecificPropertyList;
            dgLocalizedSpecificProperties.DataContext = LanguageAndSpecificPropertyList;
        }

        private void SetLanguageDictionary(Language selectedLanguage)
        {
            ResourceDictionary dict = new ResourceDictionary();

            dict.Source = new Uri(BL_Multilingual.ChooseLanguageDictionary(selectedLanguage), UriKind.Relative);

            this.Resources.MergedDictionaries.Add(dict);
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            BL_SpecificProductProperty.Save(SpecificProductPropertyModel, LanguageAndSpecificPropertyList.ToList());
            Console.Beep();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Visibility = Visibility.Collapsed;
        }
    }
}
