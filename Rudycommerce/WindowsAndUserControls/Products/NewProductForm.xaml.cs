using MahApps.Metro.Controls;
using RudycommerceLibrary;
using RudycommerceLibrary.BL;
using RudycommerceLibrary.Entities;
using RudycommerceLibrary.Entities.ProductsAndCategories;
using RudycommerceLibrary.Entities.ProductsAndCategories.Localized;
using RudycommerceLibrary.Models;
using RudycommerceLibrary.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
        Image image_to_drag;

        public List<CategoryItem> CategoryItemList { get; set; }

        public List<NecessaryProductPropertyViewItem> NecessaryProductPropertiesList { get; set; }

        public Product ProductModel { get; set; }
        public List<LocalizedProduct> LocalizedProductList { get; set; }

        public List<Product_SpecificProductProperties> Product_ProductPropertiesList { get; set; }

        public List<Values_Product_SpecificProductProperties> LocalizedValuesProduct_SpecificProductProperties { get; set; }

        public List<LocalizedLanguageItem> LocalizedLanguageList { get; set; }

        //bool firstSelectionChangedWhenUpdating = false;

        //public NewProductForm(int productID)
        //{
        //    InitializeComponent();
        //    grdNewProductForm.DataContext = this;

        //    SetLanguageDictionary(Settings.UserLanguage);

        //    ProductModel = BL_Product.GetProduct(productID);
        //    LocalizedProductList = BL_Product.GetLocalizedProductList(productID);

        //    Product_ProductPropertiesList = new List<Product_SpecificProductProperties>();
        //    Product_ProductPropertiesListFromDB = BL_Product.GetPropertiesFromProduct(productID);

        //    LocalizedValuesProduct_SpecificProductProperties = new List<Localized_Product_SpecificProductProperties>();
        //    LocalizedValuesProduct_SpecificProductPropertiesFromDB = BL_Product.GetLocalizedPropertiesFromProduct(productID);





        //    firstSelectionChangedWhenUpdating = true;

        //    SetCategoryComboBoxContent();
        //}

        public NewProductForm()
        {
            InitializeComponent();

            ProductModel = new Product();
            LocalizedProductList = new List<LocalizedProduct>();
            LocalizedValuesProduct_SpecificProductProperties = new List<Values_Product_SpecificProductProperties>();
            Product_ProductPropertiesList = new List<Product_SpecificProductProperties>();

            ImageList = new List<ProductImage>();

            grdNewProductForm.DataContext = this;

            SetLanguageDictionary(RudycommerceLibrary.Settings.UserLanguage);

            SetCategoryComboBoxContent();
        }
        private void SetLanguageDictionary(Language selectedLanguage)
        {
            ResourceDictionary dict = new ResourceDictionary();

            dict.Source = new Uri(BL_Multilingual.ChooseLanguageDictionary(selectedLanguage), UriKind.Relative);

            this.Resources.MergedDictionaries.Add(dict);
        }

        private void SetCategoryComboBoxContent()
        {
            CategoryItemList = BL_ProductCategory.GetCategoryNameWithID(Settings.UserLanguage);


            //CategoryItemList = BL_ProductCategory.GetLocalizedProductCategory(Settings.UserLanguage);

            //cmbxCategories.DataContext = CategoryItemList;
            //cmbxCategories.ItemsSource = CategoryItemList;
        }

        private void cmbxCategories_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            //if (updatingExistingProduct)
            //{
            //    if (MessageBox.Show("NO-ML You are going to lose all content of all currently filled in properties","NO-ML OH NO!", MessageBoxButton.YesNo)
            //        == MessageBoxResult.Yes)
            //    {
            //        tabItemMultilingualProperties.Visibility = Visibility.Visible;
            //        tabItemNonMultilingualProperties.Visibility = Visibility.Visible;

            //        NecessaryProductPropertiesList = BL_SpecificProductProperty
            //            .GetNecessaryProductProperties(Settings.UserLanguage, int.Parse(cmbxCategories.SelectedValue.ToString()));

            //        LocalizedProductList.Clear();

            //        CreateTabsForEachLanguage();
            //        FillNonMultilingualInputTab();
            //    }
            //}
            //else
            //{
            tabItemMultilingualProperties.Visibility = Visibility.Visible;
            tabItemNonMultilingualProperties.Visibility = Visibility.Visible;

            NecessaryProductPropertiesList = BL_SpecificProductProperty
                .GetNecessaryProductProperties(Settings.UserLanguage, int.Parse(cmbxCategories.SelectedValue.ToString()));

            LocalizedProductList.Clear();

            CreateMultilingualTabsForEachLanguage();
            FillNonMultilingualInputTab();
            //}                

        }

        #region Generate tab content for new Product

        private void CreateMultilingualTabsForEachLanguage()
        {
            TabControlLanguages.Items.Clear();
            LocalizedValuesProduct_SpecificProductProperties.Clear();

            LocalizedLanguageList = BL_Multilingual.GetLocalizedListOfLanguages(Settings.UserLanguage);

            // Creates tab for each language
            foreach (LocalizedLanguageItem langItem in LocalizedLanguageList)
            {
                CreateLocalizedTab(langItem);
            }
        }

        private void CreateLocalizedTab(LocalizedLanguageItem langItem)
        {
            MetroTabItem tabItem = CreateMetroTabItem(langItem);
            Grid tabGrid = new Grid { Style = Application.Current.Resources["GridBelowTabItem"] as Style };

            WrapPanel wrapForStacks = new WrapPanel { HorizontalAlignment = HorizontalAlignment.Center };

            StackPanel stackPanelLeft = CreateLeftStackPanelForLabelsNewProduct(langItem);
            StackPanel stackPanelRight = CreateRightStackPanelForInputNewProduct(langItem);

            wrapForStacks.Children.Add(stackPanelLeft);
            wrapForStacks.Children.Add(stackPanelRight);

            tabGrid.Children.Add(wrapForStacks);

            tabItem.Content = tabGrid;

            TabControlLanguages.Items.Add(tabItem);
        }

        private StackPanel CreateRightStackPanelForInputNewProduct(LocalizedLanguageItem langItem)
        {
            // Creates localized product, which contains the name and description
            LocalizedProduct localProduct = new LocalizedProduct()
            {
                LanguageID = langItem.ID
            };

            #region Creates textboxes for name and description

            StackPanel stackRight = new StackPanel();

            TextBox txtName = new TextBox
            {
                Height = 30,
                Width = 300,
                Margin = new Thickness { Top = 20 },
                VerticalContentAlignment = VerticalAlignment.Center
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

            #endregion

            // Creates a textbox for each multilingual property (which isn't an enumeration)
            foreach (NecessaryProductPropertyViewItem necessaryProperty in
                NecessaryProductPropertiesList.Where(np => np.IsMultilingual == true && np.IsEnumeration == false)
                .OrderByDescending(np => np.IsRequired))
            {
                //Product_SpecificProductProperties productProp = new Product_SpecificProductProperties()
                //{
                //    SpecificProductPropertyID = necessaryProperty.PropertyID
                //};

                Values_Product_SpecificProductProperties valueProperty = new Values_Product_SpecificProductProperties()
                {
                    SpecificProductPropertyID = necessaryProperty.PropertyID,
                    LanguageID = langItem.ID
                };

                // Make textbox

                TextBox customTextbox = new TextBox
                {
                    Height = 30,
                    Width = 300,
                    VerticalContentAlignment = VerticalAlignment.Center,
                    Margin = new Thickness { Top = 20 }
                };
                Binding customTextboxBinding = new Binding("Value")
                {
                    Source = valueProperty
                };
                customTextbox.SetBinding(TextBox.TextProperty, customTextboxBinding);

                stackRight.Children.Add(customTextbox);

                LocalizedValuesProduct_SpecificProductProperties.Add(valueProperty);
                //Product_ProductPropertiesList.Add(productProp);
            }

            LocalizedProductList.Add(localProduct);

            return stackRight;
        }

        private StackPanel CreateLeftStackPanelForLabelsNewProduct(LocalizedLanguageItem langItem)
        {
            StackPanel stackLeft = new StackPanel();
            Label labelName = new Label
            {
                Content = BL_Multilingual.NAME(Settings.UserLanguage) + " * : ",
                Height = 30,
                Foreground = Brushes.Black,
                FontSize = 18,
                Margin = new Thickness { Top = 20 },
                Padding = new Thickness { Left = 0, Top = -5, Right = 0, Bottom = -5 },
                HorizontalContentAlignment = HorizontalAlignment.Right
            };
            Label labelDescription = new Label
            {
                Content = BL_Multilingual.DESCRIPTION(Settings.UserLanguage) + " * : ",
                Height = 30,
                Foreground = Brushes.Black,
                FontSize = 18,
                Margin = new Thickness { Top = 20, Bottom = 120 },
                Padding = new Thickness { Left = 0, Top = -5, Right = 0, Bottom = -5 },
                HorizontalContentAlignment = HorizontalAlignment.Right
            };

            stackLeft.Children.Add(labelName);
            stackLeft.Children.Add(labelDescription);

            foreach (NecessaryProductPropertyViewItem necessaryProperty in
                NecessaryProductPropertiesList.Where(np => np.IsMultilingual == true && np.IsEnumeration == false).OrderByDescending(np => np.IsRequired))
            {
                Label customLabel = new Label
                {
                    Content = necessaryProperty.LookupName + (necessaryProperty.IsRequired ? " * " : " ") + ": ",
                    Height = 30,
                    Foreground = Brushes.Black,
                    FontSize = 18,
                    Margin = new Thickness { Top = 20 },
                    Padding = new Thickness { Left = 0, Top = -5, Right = 0, Bottom = -5 },
                    HorizontalContentAlignment = HorizontalAlignment.Right
                };
                stackLeft.Children.Add(customLabel);
            }

            return stackLeft;
        }

        private MetroTabItem CreateMetroTabItem(LocalizedLanguageItem langItem)
        {
            MetroTabItem metroTab = new MetroTabItem
            {
                Header = langItem.Name,
                Name = $"tab{langItem.ID}",
                Padding = new Thickness { Left = 25, Right = 25 },
                Background = Brushes.Beige
            };

            //https://stackoverflow.com/questions/23377194/overwrite-mahapps-metro-style-for-me-header-tabitem
            //https://social.msdn.microsoft.com/Forums/vstudio/en-US/ffcd8d49-267c-4ccb-8ceb-b80305447cb4/c-wpf-implementing-style-using-code?forum=wpf

            Style AutoGeneratedTabItem = new Style
            {
                TargetType = typeof(MetroTabItem)
            };

            Setter SelectedStyle = new Setter
            {
                Property = TabItem.BorderThicknessProperty,
                Value = new Thickness { Top = 2, Bottom = 2, Left = 2, Right = 2 }
            };
            Trigger SelectedTrigger = new Trigger
            {
                Property = TabItem.IsSelectedProperty,
                Value = true
            };
            SelectedTrigger.Setters.Add(SelectedStyle);

            Setter NotSelectedStyle = new Setter
            {
                Property = TabItem.BorderThicknessProperty,
                Value = new Thickness { Top = 0, Bottom = 0, Left = 1, Right = 1 }
            };
            Trigger NotSelectedTrigger = new Trigger
            {
                Property = TabItem.IsSelectedProperty,
                Value = false
            };
            NotSelectedTrigger.Setters.Add(NotSelectedStyle);

            AutoGeneratedTabItem.Triggers.Add(SelectedTrigger);
            AutoGeneratedTabItem.Triggers.Add(NotSelectedTrigger);

            AutoGeneratedTabItem.Setters.Add(new Setter() { Property = ControlsHelper.HeaderFontSizeProperty, Value = 18.0 });
            metroTab.Style = AutoGeneratedTabItem;

            return metroTab;
        }

        #region NonMultilingualInput

        private void FillNonMultilingualInputTab()
        {
            NonMLStackLeftLabels.Children.Clear();
            NonMLStackRightInput.Children.Clear();
            Product_ProductPropertiesList.Clear();

            foreach (NecessaryProductPropertyViewItem necessaryProperty in 
                NecessaryProductPropertiesList.Where(np => np.IsMultilingual == false || np.IsEnumeration == true)
                .OrderByDescending(np => np.IsRequired))
            {
                #region Textbox/Checkbox/Combobox

                if (necessaryProperty.IsEnumeration == false)
                {
                    //Product_SpecificProductProperties productProperty = new Product_SpecificProductProperties()
                    //{
                    //    SpecificProductPropertyID = necessaryProperty.PropertyID
                    //};

                    Values_Product_SpecificProductProperties localValue = new Values_Product_SpecificProductProperties()
                    {
                        SpecificProductPropertyID = necessaryProperty.PropertyID,
                        LanguageID = null
                    };
                    
                    if (necessaryProperty.IsBool == false)
                    {
                        TextBox customTextbox = createNonMultilingualTextBox(localValue);

                        NonMLStackRightInput.Children.Add(customTextbox);
                        //Product_ProductPropertiesList.Add(productProperty);
                        LocalizedValuesProduct_SpecificProductProperties.Add(localValue);
                    }
                    else
                    {
                        CheckBox customCheckbox = CreateNonMultilingualCheckBox(localValue);

                        NonMLStackRightInput.Children.Add(customCheckbox);
                        //Product_ProductPropertiesList.Add(productProperty);
                        LocalizedValuesProduct_SpecificProductProperties.Add(localValue);
                    }
                }
                else
                {
                    Values_Product_SpecificProductProperties valueProperty = new Values_Product_SpecificProductProperties()
                    {
                        SpecificProductPropertyID = necessaryProperty.PropertyID,
                        LanguageID = null
                    };

                    ComboBox customComboBox = CreateNonMultilingualComboBox(valueProperty);

                    NonMLStackRightInput.Children.Add(customComboBox);

                    LocalizedValuesProduct_SpecificProductProperties.Add(valueProperty);
                }                             

                #endregion

                #region Label
                Label customLabel = new Label
                {
                    Content = necessaryProperty.LookupName + (necessaryProperty.IsRequired ? " * " : " ") + ": ",
                    Height = 30,
                    Foreground = Brushes.Black,
                    FontSize = 18,
                    Margin = new Thickness { Top = 20 },
                    Padding = new Thickness { Left = 0, Top = -5, Right = 0, Bottom = -5 },
                    HorizontalContentAlignment = HorizontalAlignment.Right
                };

                NonMLStackLeftLabels.Children.Add(customLabel);
                #endregion
            }
        }

        private ComboBox CreateNonMultilingualComboBox(Values_Product_SpecificProductProperties valueProperty)
        {
            ComboBox returnComboBox = new ComboBox
            {
                Height = 30,
                Width = 300,
                VerticalContentAlignment = VerticalAlignment.Center,
                Margin = new Thickness { Top = 20 },
                DisplayMemberPath = "Value",
                SelectedValuePath = "EnumerationID"
            };

            returnComboBox.SetBinding(ItemsControl.ItemsSourceProperty,
                new Binding
                {
                    Source = BL_SpecificProductProperty.
                    GetPropertyEnumerations(Settings.UserLanguage, valueProperty.SpecificProductPropertyID)
                });

            returnComboBox.SetBinding(
               Selector.SelectedValueProperty,
               new Binding("EnumerationValueID") { Source = valueProperty });

            return returnComboBox;
        }

        private CheckBox CreateNonMultilingualCheckBox(Values_Product_SpecificProductProperties localValue)
        {
            CheckBox returnCheckBox = new CheckBox
            {
                Height = 30,
                Margin = new Thickness { Top = 20 },
                VerticalContentAlignment = VerticalAlignment.Center
            };
            Binding customCheckboxBinding = new Binding("Value")
            {
                Source = localValue
            };
            returnCheckBox.SetBinding(CheckBox.IsCheckedProperty, customCheckboxBinding);

            return returnCheckBox;
        }

        private TextBox createNonMultilingualTextBox(Values_Product_SpecificProductProperties localValue)
        {
            TextBox returnTextBox = new TextBox
            {
                Height = 30,
                Width = 300,
                VerticalContentAlignment = VerticalAlignment.Center,
                Margin = new Thickness { Top = 20 }
            };
            Binding customTextboxBinding = new Binding("Value")
            {
                Source = localValue
            };
            returnTextBox.SetBinding(TextBox.TextProperty, customTextboxBinding);

            return returnTextBox;
        }

        #endregion

        #endregion

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            BL_Product.Create(ProductModel, LocalizedProductList, Product_ProductPropertiesList, 
                LocalizedValuesProduct_SpecificProductProperties, ImageList);
            Console.Beep();
        }

        private void AnimatedTabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Thickness notSelected = new Thickness { Bottom = 0, Top = 0, Left = 1, Right = 1 };
            Thickness Selected = new Thickness { Bottom = 2, Top = 2, Left = 2, Right = 2 };

            tabItemGeneral.BorderThickness = notSelected;
            tabItemMultilingualProperties.BorderThickness = notSelected;
            tabItemNonMultilingualProperties.BorderThickness = notSelected;

            if (tabItemGeneral.IsSelected)
            {
                tabItemGeneral.BorderThickness = Selected;
            }
            if (tabItemMultilingualProperties.IsSelected)
            {
                tabItemMultilingualProperties.BorderThickness = Selected;
            }
            if (tabItemNonMultilingualProperties.IsSelected)
            {
                tabItemNonMultilingualProperties.BorderThickness = Selected;
            }
        }

        #region Generating and moving images

        public List<ProductImage> ImageList { get; set; }
        private int _imgCounter = 0;
        private const int _imgDefaultWidth = 120;
        private const int _imgDefaultHeight = 120;
        private const int _firstImageWidth = 250;
        private const int _firstImageHeight = 250;


        private void addImage(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog fileDialog = new Microsoft.Win32.OpenFileDialog();
            
            fileDialog.Filter = "Image File (*.jpg; *.png)| *.jpg; *.png";
            
            Nullable<bool> result = fileDialog.ShowDialog();

            if (result == true)
            {
                string filename = fileDialog.FileName;

                Image img = new Image
                {
                    Source = new BitmapImage(new Uri(filename)),
                    Width = _imgCounter != 0 ? _imgDefaultWidth : _firstImageWidth  ,
                    Height = _imgCounter != 0 ? _imgDefaultHeight : _firstImageHeight,
                    Margin = new Thickness(20, 0, 20, 0),
                    AllowDrop = true,
                    VerticalAlignment = VerticalAlignment.Stretch
                };
                img.DragEnter += Image_DragEnter;
                img.MouseLeftButtonDown += Image_MouseLeftButtonDown;


                ProductImage imgItem = new ProductImage
                {
                    fileLocation = filename,
                    Order = _imgCounter
                };

                ImageList.Add(imgItem);
                
                imgPnl.Children.Add(img);

                _imgCounter += 1;
            }            
        }

        private void Image_DragEnter(object sender, DragEventArgs e)
        {
            Image img = (Image)e.Source;
            int where_to_drop = imgPnl.Children.IndexOf(img);
            int initial_location = imgPnl.Children.IndexOf(image_to_drag);

            imgPnl.Children.Remove(image_to_drag);       
            imgPnl.Children.Insert(where_to_drop, image_to_drag);

            foreach (var item in imgPnl.Children)
            {
                Image image = item as Image;
                
                image.Height = imgPnl.Children.IndexOf(image) != 0 ? _imgDefaultHeight : _firstImageHeight ;
                image.Width = imgPnl.Children.IndexOf(image) != 0 ? _imgDefaultWidth : _firstImageWidth;
            }

            ProductImage temporary = ImageList.Single(x => x.Order == initial_location);
            ProductImage temporary2 = ImageList.Single(x => x.Order == where_to_drop);

            temporary.Order = where_to_drop;
            temporary2.Order = initial_location;
            
            

            ImageList = ImageList.OrderBy(x => x.Order).ToList() ;            
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            image_to_drag = (Image)e.Source;
            DragDrop.DoDragDrop(image_to_drag, image_to_drag, DragDropEffects.Move);
        }

        #endregion
    }
}

