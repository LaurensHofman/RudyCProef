using RudycommerceLibrary;
using RudycommerceLibrary.BL;
using RudycommerceLibrary.CustomExceptions;
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
        public ProductProperty SpecificProductPropertyModel { get; set; }
        public ObservableCollection<LanguageAndSpecificPropertyItem> LanguageAndSpecificPropertyList { get; set; }

        

        public List<LocalizedLanguageItem> LanguageList { get; set; }

        public SpecificProductPropertyForm()
        {
            InitializeComponent();

            InitializeModelsAndContents();

            SetLanguageDictionary(UserSettings.UserLanguage);
        }

        private void InitializeModelsAndContents()
        {
            SpecificProductPropertyModel = new ProductProperty();

            // gets active languages
            try
            {
                LanguageList = BL_Multilingual.GetLocalizedListOfLanguages(UserSettings.UserLanguage);
            }
            catch (DatabaseQueryError ex)
            {
                MessageBox.Show(ex.Message, "NO-ML ERROR", MessageBoxButton.OK);
                btnCancel_Click(null, null);
            }
            

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
            try
            {
                BL_SpecificProductProperty.Save(SpecificProductPropertyModel, LanguageAndSpecificPropertyList.ToList(), EnumerationList.ToList());
                Console.Beep();
            }
            catch (SaveFailed)
            {
                MessageBox.Show(BL_Multilingual.SaveFailedContent(UserSettings.UserLanguage), BL_Multilingual.SaveFailedTitle(UserSettings.UserLanguage), MessageBoxButton.OK);
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
        }

        private void MLChecked(object sender, RoutedEventArgs e)
        {
            if (SpecificProductPropertyModel.IsMultilingual == true)
            {
                GenerateMultilingualDataGridColumns();
            }
            else
            {
                Generate1DataGridColumn();
            }
        }

        private void Generate1DataGridColumn()
        {
            EnumerationList = new ObservableCollection<PropertyEnumerations>();

            dgEnumeration.ItemsSource = EnumerationList;
            dgEnumeration.DataContext = EnumerationList;

            dgEnumeration.Columns.Clear();

            TextBlock header = new TextBlock()
            {
                Text = BL_Multilingual.POTENTIAL_VALUES(UserSettings.UserLanguage)
            };

            string Bindinglocation = "TemporaryNonMLValue";
            Binding valuesBinding = new Binding(Bindinglocation);

            DataGridTextColumn dgCol = new DataGridTextColumn
            {
                Header = header,
                Binding = valuesBinding,
                Width =  new DataGridLength(1.0, DataGridLengthUnitType.Star)
            };

            dgEnumeration.Columns.Add(dgCol);

            AddEnumRow(null, null);
        }

        public ObservableCollection<PropertyEnumerations> EnumerationList { get; set; }

        private void GenerateMultilingualDataGridColumns()
        {
            EnumerationList = new ObservableCollection<PropertyEnumerations>();

            dgEnumeration.ItemsSource = EnumerationList;
            dgEnumeration.DataContext = EnumerationList;

            dgEnumeration.Columns.Clear();

            foreach (var lang in LanguageList)
            {
                TextBlock header = new TextBlock
                {
                    Text = lang.Name
                };
                header.Typography.Capitals = FontCapitals.SmallCaps;

                int index = LanguageList.IndexOf(lang);
                string Bindinglocation = $"ValuesList[{index}].Value";
                Binding valuesBinding = new Binding(Bindinglocation);
                

                DataGridTextColumn dgCol
                    = new DataGridTextColumn
                    {
                        Header = header,
                        Binding = valuesBinding,
                        Width = new DataGridLength(1.0, DataGridLengthUnitType.Star)
                    };
                dgEnumeration.Columns.Add(dgCol);
            }

            AddEnumRow(null, null);
        }

        private void AddEnumRow(object sender, RoutedEventArgs e)
        {
            PropertyEnumerations newEnum = new PropertyEnumerations();

            foreach (var lang in LanguageList)
            {
                newEnum.ValuesList.Add(
                    new LocalizedEnumerationValues
                    {
                        LanguageID = lang.ID
                    });
            }

            EnumerationList.Add(newEnum);

            dgEnumeration.ItemsSource = EnumerationList;
            dgEnumeration.DataContext = EnumerationList;
        }

        private void EnumChecked(object sender, RoutedEventArgs e)
        {
            dgEnumeration.Visibility = SpecificProductPropertyModel.IsEnumeration ? Visibility.Visible : Visibility.Collapsed;
            btnAdd.Visibility = SpecificProductPropertyModel.IsEnumeration ? Visibility.Visible : Visibility.Collapsed;

            SpecificProductPropertyModel.IsBool = false;
        }
    }
}
