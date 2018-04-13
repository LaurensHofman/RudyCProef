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
using RudycommerceLibrary.BL;
using RudycommerceLibrary.Entities;
using RudycommerceLibrary.Entities.ProductsAndCategories;
using RudycommerceLibrary.Entities.ProductsAndCategories.Localized;
using RudycommerceLibrary.Models;


namespace Rudycommerce
{
    /// <summary>
    /// Interaction logic for CategoryForm.xaml
    /// </summary>
    public partial class CategoryForm : UserControl
    {
        public List<CategoryItem> PotentialParents { get; set; }

        public ProductCategory ProductCategoryModel { get; set; }

        public List<LocalizedLanguageItem> LanguageList { get; set; }
        public ObservableCollection<LanguageAndCategoryItem> LanguageAndCategoryList { get; set; }

        public ObservableCollection<PropertyAndCategoryItem> PropertyAndCategoryList { get; set; }
        public ObservableCollection<LocalizedSpecificProductProperty> LocalizedSpecificProductPropertyList { get; set; }


        public CategoryForm()
        {
            InitializeComponent();

            SetLanguageDictionary(RudycommerceLibrary.Settings.UserLanguage);

            InitializeModelsAndContents();

            SetSelectPropertyDataGridContent();

            //TODO When selecting parent, implement parent properties;
        }

        #region PropertySelectionDataGrid

        private void SetSelectPropertyDataGridContent()
        {
            LocalizedSpecificProductPropertyList = new ObservableCollection<LocalizedSpecificProductProperty>(BL_SpecificProductProperty.GetLocalizedSpecificProductProperties(Settings.UserLanguage).OrderBy(prop => prop.LookupName));

            BindPropertySelectionData();
        }

        private void BindPropertySelectionData()
        {
            dgSelectProperty.ItemsSource = LocalizedSpecificProductPropertyList.OrderBy(prop => prop.LookupName);
            dgSelectProperty.DataContext = LocalizedSpecificProductPropertyList;
        }

        private void AddSelectedProperty(LocalizedSpecificProductProperty propertyAndName)
        {
            PropertyAndCategoryList.Add(
                new PropertyAndCategoryItem
                {
                    PropertyID = propertyAndName.SpecificProductPropertyID,
                    PropertyName = propertyAndName.LookupName,
                    IsRequired = true
                });

            BindPropertyAndCategoryData();
        }

        private void AddProperty_Click(object sender, RoutedEventArgs e)
        {
            LocalizedSpecificProductProperty prop = ((FrameworkElement)sender).DataContext as LocalizedSpecificProductProperty;
            AddSelectedProperty(prop);
            RemoveSelectedPropertyFromList(prop);
        }

        private void RemoveSelectedPropertyFromList(LocalizedSpecificProductProperty prop)
        {
            LocalizedSpecificProductPropertyList.Remove(prop);
            BindPropertySelectionData();
        }
        #endregion
                
        #region SelectedPropertyDataGrid
        
        private void RemoveProperty_Click(object sender, RoutedEventArgs e)
        {
            PropertyAndCategoryItem prop = ((FrameworkElement)sender).DataContext as PropertyAndCategoryItem;
            RemoveSelectedPropertyFromAddedList(prop);
            AddPropertyBackToSelectionList(prop);
        }
        
        private void AddPropertyBackToSelectionList(PropertyAndCategoryItem prop)
        {
            LocalizedSpecificProductPropertyList.Add(
                new LocalizedSpecificProductProperty
                {
                    SpecificProductPropertyID = prop.PropertyID,
                    LookupName = prop.PropertyName
                });

            BindPropertySelectionData();
        }
        
        private void RemoveSelectedPropertyFromAddedList(PropertyAndCategoryItem prop)
        {
            PropertyAndCategoryList.Remove(prop);
            BindPropertyAndCategoryData();
        }

        private void BindPropertyAndCategoryData()
        {
            dgCategory_SpecificProductProperty.ItemsSource = PropertyAndCategoryList;
            dgCategory_SpecificProductProperty.DataContext = PropertyAndCategoryList;
        }
        #endregion

        private void SetLanguageDictionary(Language selectedLanguage)
        {
            ResourceDictionary dict = new ResourceDictionary();

            dict.Source = new Uri(BL_Multilingual.ChooseLanguageDictionary(selectedLanguage), UriKind.Relative);

            this.Resources.MergedDictionaries.Add(dict);
        }

        private void InitializeModelsAndContents()
        {
            ProductCategoryModel = new ProductCategory();
            PotentialParents = BL_ProductCategory.GetPotentialParents(RudycommerceLibrary.Settings.UserLanguage);


            // gets active languages
            LanguageList = BL_Multilingual.GetLocalizedListOfLanguages(RudycommerceLibrary.Settings.UserLanguage);

            // creates items for the datagrid, based on the active languages
            LanguageAndCategoryList = new ObservableCollection<LanguageAndCategoryItem>();
            foreach (LocalizedLanguageItem li in LanguageList)
            {
                LanguageAndCategoryList.Add(
                new LanguageAndCategoryItem() { LanguageID = li.ID, LanguageName = li.Name, CategoryName = null });
            }

            PropertyAndCategoryList = new ObservableCollection<PropertyAndCategoryItem>();

            grdCategoryForm.DataContext = this;

            SetDataGridItemsToModelList();
        }

        private void SetDataGridItemsToModelList()
        {
            dgLocalizedCategories.ItemsSource = LanguageAndCategoryList;
            dgLocalizedCategories.DataContext = LanguageAndCategoryList;
        }
        
        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            BL_ProductCategory.Save(ProductCategoryModel, LanguageAndCategoryList.ToList(), PropertyAndCategoryList.ToList());
            Console.Beep();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Visibility = Visibility.Collapsed;
        }







    }
}
