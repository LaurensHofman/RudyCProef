using MahApps.Metro.Controls;
using RudycommerceLibrary;
using RudycommerceLibrary.BL;
using RudycommerceLibrary.Entities;
using RudycommerceLibrary.Entities.ProductsAndCategories;
using RudycommerceLibrary.Entities.ProductsAndCategories.Localized;
using RudycommerceLibrary.Models;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for NewProductForm.xaml
    /// </summary>
    public partial class NewProductForm : UserControl
    {
        public List<CategoryItem> CategoryItemList { get; set; }

        public List<NecessaryProductProperties> NecessaryProductPropertiesList { get; set; }

        public Product ProductModel { get; set; }
        public List<LocalizedProduct> LocalizedProductList { get; set; }
        public List<Product_SpecificProductProperties> Product_ProductPropertiesList { get; set; }
        public List<Localized_Product_SpecificProductProperties> LocalizedValuesProduct_SpecificProductProperties { get; set; }

        public List<LocalizedLanguageItem> LocalizedLanguageList { get; set; }

        public NewProductForm()
        {
            InitializeComponent();

            ProductModel = new Product();
            LocalizedProductList = new List<LocalizedProduct>();
            LocalizedValuesProduct_SpecificProductProperties = new List<Localized_Product_SpecificProductProperties>();
            Product_ProductPropertiesList = new List<Product_SpecificProductProperties>();

            grdNewProductForm.DataContext = this;

            SetLanguageDictionary(RudycommerceLibrary.Settings.UserLanguage);

            SetCategoryComboBoxContent();
        }

        #region Generate tab content

        private void CreateTabsForEachLanguage()
        {
            TabControlLanguages.Items.Clear();
            LocalizedValuesProduct_SpecificProductProperties.Clear();

            LocalizedLanguageList = BL_Multilingual.GetLocalizedListOfLanguages(Settings.UserLanguage);

            int tabMarginMultiplier = 1;
            foreach (LocalizedLanguageItem langItem in LocalizedLanguageList)
            {
                CreateLocalizedTab(langItem, tabMarginMultiplier);
                tabMarginMultiplier += 1;
            }
        }

        private void CreateLocalizedTab(LocalizedLanguageItem langItem, int tabMarginMultiplier)
        {
            MetroTabItem tabItem = CreateMetroTabItem(langItem, tabMarginMultiplier);
            Grid tabGrid = new Grid();

            WrapPanel wrapForStacks = new WrapPanel();

            StackPanel stackPanelLeft = CreateLeftStackPanelForLabels(langItem);
            StackPanel stackPanelRight = CreateRightStackPanelForInput(langItem);

            wrapForStacks.Children.Add(stackPanelLeft);
            wrapForStacks.Children.Add(stackPanelRight);

            tabGrid.Children.Add(wrapForStacks);

            tabItem.Content = tabGrid;

            TabControlLanguages.Items.Add(tabItem);
        }

        private StackPanel CreateRightStackPanelForInput(LocalizedLanguageItem langItem)
        {
            LocalizedProduct localProduct = new LocalizedProduct()
            {
                LanguageID = langItem.ID
            };

            StackPanel stackRight = new StackPanel();

            TextBox txtName = new TextBox
            {
                Height = 30,
                Width = 300,
                Margin = new Thickness { Top = 20 }
            };
            Binding nameBinding = new Binding("Name")
            {
                Source = localProduct
            };
            txtName.SetBinding(TextBox.TextProperty, nameBinding);

            TextBox txtDescription = new TextBox
            {
                Height = 150,
                Width = 300,
                TextWrapping = TextWrapping.Wrap,
                AcceptsReturn = true,
                Margin = new Thickness { Top = 20 }
            };
            Binding descriptionBinding = new Binding("Description")
            {
                Source = localProduct
            };
            txtDescription.SetBinding(TextBox.TextProperty, descriptionBinding);

            stackRight.Children.Add(txtName);
            stackRight.Children.Add(txtDescription);

            foreach (NecessaryProductProperties necessaryProperty in NecessaryProductPropertiesList.Where(np => np.IsMultilingual == true))
            {
                Localized_Product_SpecificProductProperties valueProperty = new Localized_Product_SpecificProductProperties()
                {
                    SpecificProductPropertyID = necessaryProperty.PropertyID,
                    LanguageID = langItem.ID
                };

                TextBox customTextbox = new TextBox
                {
                    Height = 30,
                    Width = 300,
                    Margin = new Thickness { Top = 20 }
                };
                Binding customTextboxBinding = new Binding("PropertyValue")
                {
                    Source = valueProperty
                };
                customTextbox.SetBinding(TextBox.TextProperty, customTextboxBinding);

                stackRight.Children.Add(customTextbox);
                LocalizedValuesProduct_SpecificProductProperties.Add(valueProperty);
            }

            LocalizedProductList.Add(localProduct);

            return stackRight;
        }

        private StackPanel CreateLeftStackPanelForLabels(LocalizedLanguageItem langItem)
        {
            StackPanel stackLeft = new StackPanel();
            Label labelName = new Label
            {
                Content = "NO-ML Name:",
                Margin = new Thickness { Top = 20 },
                HorizontalContentAlignment = HorizontalAlignment.Right
            };
            Label labelDescription = new Label
            {
                Content = "NO-ML Description:",
                Margin = new Thickness { Top = 20, Bottom = 130 },
                HorizontalContentAlignment = HorizontalAlignment.Right
            };

            stackLeft.Children.Add(labelName);
            stackLeft.Children.Add(labelDescription);

            foreach (NecessaryProductProperties necessaryProperty in NecessaryProductPropertiesList.Where(np => np.IsMultilingual == true))
            {
                Label customLabel = new Label
                {
                    Content = necessaryProperty.LookupName + (necessaryProperty.IsRequired ? "* " : "") + ":",
                    Margin = new Thickness { Top = 20 },
                    HorizontalContentAlignment = HorizontalAlignment.Right
                };
                stackLeft.Children.Add(customLabel);
            }

            return stackLeft;
        }

        private MetroTabItem CreateMetroTabItem(LocalizedLanguageItem langItem, int tabMarginMultiplier)
        {
            MetroTabItem metroTab = new MetroTabItem
            {
                Header = langItem.Name,
                Name = $"tab{langItem.ID}",
                Margin = new Thickness { Left = 20 * tabMarginMultiplier, Right = -20 * tabMarginMultiplier }
            };

            //https://stackoverflow.com/questions/23377194/overwrite-mahapps-metro-style-for-me-header-tabitem
            //https://social.msdn.microsoft.com/Forums/vstudio/en-US/ffcd8d49-267c-4ccb-8ceb-b80305447cb4/c-wpf-implementing-style-using-code?forum=wpf

            Style smallerTabItem = new Style
            {
                TargetType = typeof(MetroTabItem)
            };
            smallerTabItem.Setters.Add(new Setter() { Property = ControlsHelper.HeaderFontSizeProperty, Value = 18.0 });

            metroTab.Style = smallerTabItem;

            return metroTab;
        }
        
        private void FillNonMultilingualInputTab()
        {
            NonMLStackLeftLabels.Children.Clear();
            NonMLStackRightInput.Children.Clear();
            Product_ProductPropertiesList.Clear();

            foreach (NecessaryProductProperties necessaryProperty in NecessaryProductPropertiesList.Where(np => np.IsMultilingual == false))
            {
                #region Textbox/Checkbox
                Product_SpecificProductProperties productProperty = new Product_SpecificProductProperties()
                {
                    SpecificProductPropertyID = necessaryProperty.PropertyID
                };

                //TODO If statement to choose between textbox or checkbox
                if (necessaryProperty.IsBool == false)
                {
                    TextBox customTextbox = new TextBox
                    {
                        Height = 30,
                        Width = 300,
                        Margin = new Thickness { Top = 20 }
                    };
                    Binding customTextboxBinding = new Binding("NonMultilingualValue")
                    {
                        Source = productProperty
                    };
                    customTextbox.SetBinding(TextBox.TextProperty, customTextboxBinding);

                    NonMLStackRightInput.Children.Add(customTextbox);
                    Product_ProductPropertiesList.Add(productProperty);
                }
                else
                {
                    CheckBox customCheckbox = new CheckBox
                    {
                        Height = 30,
                        Margin = new Thickness { Top = 20 }
                    };
                    Binding customCheckboxBinding = new Binding("NonMultilingualValue")
                    {
                        Source = productProperty
                    };
                    customCheckbox.SetBinding(CheckBox.IsCheckedProperty, customCheckboxBinding);

                    NonMLStackRightInput.Children.Add(customCheckbox);
                    Product_ProductPropertiesList.Add(productProperty);
                }

                #endregion

                #region Label
                Label customLabel = new Label
                {
                    Content = necessaryProperty.LookupName + (necessaryProperty.IsRequired ? " * " : "") + ":",
                    Height = 30,
                    Margin = new Thickness { Top = 20 },
                    HorizontalContentAlignment = HorizontalAlignment.Right
                };

                NonMLStackLeftLabels.Children.Add(customLabel);
                #endregion
            }
        }

        #endregion
        
        private void SetCategoryComboBoxContent()
        {
            CategoryItemList = BL_ProductCategory.GetCategoryNameWithID(Settings.UserLanguage);

            //cmbxCategories.DataContext = CategoryItemList;
            //cmbxCategories.ItemsSource = CategoryItemList;
        }        

        private void SetLanguageDictionary(Language selectedLanguage)
        {
            ResourceDictionary dict = new ResourceDictionary();

            dict.Source = new Uri(BL_Multilingual.ChooseLanguageDictionary(selectedLanguage), UriKind.Relative);

            this.Resources.MergedDictionaries.Add(dict);
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Visibility = Visibility.Collapsed;
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            BL_Product.Create(ProductModel, LocalizedProductList, Product_ProductPropertiesList, LocalizedValuesProduct_SpecificProductProperties);
            Console.Beep();
        }

        private void cmbxCategories_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            NecessaryProductPropertiesList = BL_SpecificProductProperty
                .GetNecessaryProductProperties(Settings.UserLanguage , int.Parse(cmbxCategories.SelectedValue.ToString()));

            LocalizedProductList.Clear();

            CreateTabsForEachLanguage();
            FillNonMultilingualInputTab();
        }        
    }
}

