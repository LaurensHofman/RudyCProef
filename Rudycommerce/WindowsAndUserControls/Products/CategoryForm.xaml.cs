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
        public ProductCategory ProductCategoryModel { get; set; }

        public List<LocalizedLanguageItem> LanguageList { get; set; }

        //public ObservableCollection<LanguageAndCategoryItem> LanguageAndCategoryList { get; set; }
        //public ObservableCollection<PropertyAndCategoryItem> PropertyAndCategoryList { get; set; }


            
        public ObservableCollection<LocalizedProperty> LocalizedSpecificProductPropertyList { get; set; }


        public CategoryForm()
        {
            InitializeComponent();

            SetLanguageDictionary(UserSettings.UserLanguage);

            InitializeModelsAndContents();

            SetSelectPropertyDataGridContent();
        }

        #region PropertySelectionDataGrid

        private void SetSelectPropertyDataGridContent()
        {            
            // Didn't apply EF Lazy Loading everywhere yet, if I knew earlier about it, I actually would've done it. Same with similar cases.
            
            LocalizedSpecificProductPropertyList = new ObservableCollection<LocalizedProperty>(BL_SpecificProductProperty.GetLocalizedSpecificProductProperties(UserSettings.UserLanguage).OrderBy(prop => prop.LookupName));

            BindPropertySelectionData();
        }

        private void BindPropertySelectionData()
        {
            dgSelectProperty.ItemsSource = LocalizedSpecificProductPropertyList.OrderBy(prop => prop.LookupName);
            dgSelectProperty.DataContext = LocalizedSpecificProductPropertyList;
        }

        private void AddSelectedProperty(LocalizedProperty propertyAndName)
        {
            ProductCategoryModel.Category_SpecificProductProperties.Add(
                new Category_Property
                {
                    PropertyID = propertyAndName.PropertyID,
                    PropertyName = propertyAndName.LookupName
                });

            BindPropertyAndCategoryData();
        }

        private void AddProperty_Click(object sender, RoutedEventArgs e)
        {
            LocalizedProperty prop = ((FrameworkElement)sender).DataContext as LocalizedProperty;
            AddSelectedProperty(prop);
            RemoveSelectedPropertyFromList(prop);
        }

        private void RemoveSelectedPropertyFromList(LocalizedProperty prop)
        {
            LocalizedSpecificProductPropertyList.Remove(prop);
            BindPropertySelectionData();
        }
        #endregion
                
        #region SelectedPropertyDataGrid
        
        private void RemoveProperty_Click(object sender, RoutedEventArgs e)
        {
            Category_Property prop = ((FrameworkElement)sender).DataContext as Category_Property;
            RemoveSelectedPropertyFromAddedList(prop);
            AddPropertyBackToSelectionList(prop);
        }
        
        private void AddPropertyBackToSelectionList(Category_Property prop)
        {
            LocalizedSpecificProductPropertyList.Add(
                new LocalizedProperty
                {
                    PropertyID = prop.PropertyID,
                    LookupName = prop.PropertyName
                });

            BindPropertySelectionData();
        }
        
        private void RemoveSelectedPropertyFromAddedList(Category_Property prop)
        {
            ProductCategoryModel.Category_SpecificProductProperties.Remove(prop);
            BindPropertyAndCategoryData();
        }

        private void BindPropertyAndCategoryData()
        {
            dgCategory_SpecificProductProperty.ItemsSource = ProductCategoryModel.Category_SpecificProductProperties;
            dgCategory_SpecificProductProperty.DataContext = ProductCategoryModel.Category_SpecificProductProperties;
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
            //PotentialParents = BL_ProductCategory.GetPotentialParents(RudycommerceLibrary.Settings.UserLanguage);

            ProductCategoryModel.Category_SpecificProductProperties = new ObservableCollection<Category_Property>();
            ProductCategoryModel.LocalizedProductCategories = new ObservableCollection<LocalizedCategory>();

            // gets active languages
            LanguageList = BL_Multilingual.GetLocalizedListOfLanguages(UserSettings.UserLanguage);

            // creates items for the datagrid, based on the active languages
            foreach (LocalizedLanguageItem li in LanguageList)
            {
                ProductCategoryModel.LocalizedProductCategories.Add(
                new LocalizedCategory() { LanguageID = li.ID, LanguageName = li.Name, Name = null });
            }
            

            grdCategoryForm.DataContext = this;

            SetDataGridItemsToModelList();
        }

        private void SetDataGridItemsToModelList()
        {
            dgLocalizedCategories.ItemsSource = ProductCategoryModel.LocalizedProductCategories;
            dgLocalizedCategories.DataContext = ProductCategoryModel.LocalizedProductCategories;
        }
        
        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            BL_ProductCategory.Create(ProductCategoryModel);
            Console.Beep();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Visibility = Visibility.Collapsed;
        }
    }
}
