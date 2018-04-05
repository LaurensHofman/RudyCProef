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


        public CategoryForm()
        {
            InitializeComponent();

            SetLanguageDictionary(RudycommerceLibrary.Settings.UserLanguage);

            InitializeModelsAndContents();

            //TODO MULTILINGUAL
        }

        private void SetLanguageDictionary(Language selectedLanguage)
        {
            ResourceDictionary dict = new ResourceDictionary();

            dict.Source = new Uri(BL_Multilingual.ChooseLanguageDictionary(selectedLanguage), UriKind.Relative);

            this.Resources.MergedDictionaries.Add(dict);
        }

        private void InitializeModelsAndContents()
        {
            // gets potential parents for dropdownlist
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


            SelectSpecificProductProperty _selectPropertyUC = new SelectSpecificProductProperty();
            _selectPropertyUC.OnSelectionProperty += AddSelectedProperty;

            ucSpecificProductPropertySelect.Content = _selectPropertyUC; 
        }

        private void AddSelectedProperty(PropertyAndName propertyAndName)
        {
            PropertyAndCategoryList.Add(
                new PropertyAndCategoryItem
                {
                    PropertyID = propertyAndName.PropertyID,
                    PropertyName = propertyAndName.PropertyName,
                    IsRequired = true
                }); 
        }

        private void SetDataGridItemsToModelList()
        {
            dgLocalizedCategories.ItemsSource = LanguageAndCategoryList;
            dgLocalizedCategories.DataContext = LanguageAndCategoryList;

            dgCategory_SpecificProductProperty.ItemsSource = PropertyAndCategoryList;
            dgCategory_SpecificProductProperty.DataContext = PropertyAndCategoryList;
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            BL_ProductCategory.Save(ProductCategoryModel, LanguageAndCategoryList.ToList(), PropertyAndCategoryList.ToList());
            Console.Beep();
        }







        //private void btnAddDataGridRow_Click(object sender, RoutedEventArgs e)
        //{
        //    bool allowNewDataGridRow = true;

        //    // Checks if the amount of items is already equal to the max amount of languages (minus the -Select one- option)
        //    if (LocalizedProductCategoryList.Count() != LanguageList.Count())
        //    {
        //        //TODO Add validation messages

        //        List<int> testListLanguageIDUnique = new List<int>();
                
        //        foreach (LocalizedProductCategory lpc in LocalizedProductCategoryList)
        //        {
        //            if (lpc.Name == null)
        //            {
        //                allowNewDataGridRow = false;
        //                break;
        //            }
        //            else
        //            {
        //                if (lpc.LanguageID == 0)
        //                {
        //                    allowNewDataGridRow = false;
        //                    break;
        //                }
        //            }
        //            // checks whether the -Select one- option has been chosen once
                    
        //            testListLanguageIDUnique.Add(lpc.LanguageID);
        //        }

        //        // removes items with duplicate languages
        //        testListLanguageIDUnique = testListLanguageIDUnique.Distinct().ToList();

        //        if (testListLanguageIDUnique.Count() != LocalizedProductCategoryList.Count())
        //        {
        //            allowNewDataGridRow = false;
        //        }
        //    }
        //    else
        //    {
        //        allowNewDataGridRow = false;
        //    }            

        //    if (allowNewDataGridRow)
        //    {
        //        LocalizedProductCategoryList.Add(new LocalizedProductCategory() {} );
        //        SetDataGridItemsToModelList();
        //    }
        //}

        ////TODO Dit is prutserig
        //private int _rowCounter = 0;

        //private void cmbxDgLanguages_Loaded(object sender, RoutedEventArgs e)
        //{
        //    ComboBox cmb = (ComboBox)sender;
            
        //    cmb.ItemsSource = LanguageList;
            
        //    if (_rowCounter == 0)
        //    {
        //        cmb.IsEnabled = false;
        //        cmb.Foreground = Brushes.Gray;
        //        cmb.ItemsSource = LanguageList;
        //        LanguageList.RemoveAll(l => l.LanguageID == BL_Language.GetDefaultLanguage().LanguageID);

        //        _rowCounter += 1;
        //    }            
        //}
    }
}
