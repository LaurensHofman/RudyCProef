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
        private Thickness _defaultMargin = new Thickness { Top = 20 };
        private const int _defaultHeight = 30;
        private const int _defaultWidth = 300;
        private const int _defaultLabelFontSize = 18;
        private Thickness _defaultLabelPadding = new Thickness { Left = 0, Top = -5, Right = 0, Bottom = -5 };
        private Brush _defaultLabelForeground = Brushes.Black;

        /// <summary>
        /// defines the image that is being dragged
        /// </summary>
        Image image_to_drag;
        ///// <summary>
        ///// List of added product images
        ///// </summary>
        //public List<ProductImage> ImageList { get; set; }
        /// <summary>
        /// List of category ID's with their name, to fill the category selection combobox
        /// </summary>
        public List<ProductCategory> CategoryList { get; set; }
        /// <summary>
        /// List of properties belonging to the selected category
        /// </summary>
        public List<NecessaryProductPropertyViewItem> NecessaryProductPropertiesList { get; set; }
        /// <summary>
        /// Model of the product, containing generic non-multilingual properties
        /// </summary>
        public Product ProductModel { get; set; }
        ///// <summary>
        ///// List containing the values of the properties belonging to the product
        ///// </summary>
        //public List<Values_Product_SpecificProductProperties> LocalizedValuesProduct_SpecificProductProperties { get; set; }
        /// <summary>
        /// List of languages with their names
        /// </summary>
        public List<LocalizedLanguageItem> LocalizedLanguageList { get; set; }
        

        /// <summary>
        /// Default constructor
        /// </summary>
        public NewProductForm()
        {
            InitializeComponent();

            ProductModel = new Product();
            
            ProductModel.Values_Product_Properties = new List<Values_Product_ProductProperties>();
            ProductModel.Images = new List<ProductImage>();
            

            grdNewProductForm.DataContext = this;

            SetLanguageDictionary(UserSettings.UserLanguage);

            SetCategoryComboBoxContent();
        }

        /// <summary>
        /// Sets the language dictionary for the XAML content, based on the user's preferred language
        /// </summary>
        /// <param name="selectedLanguage"></param>
        private void SetLanguageDictionary(Language selectedLanguage)
        {
            try
            {
                ResourceDictionary dict = new ResourceDictionary();

                dict.Source = new Uri(BL_Multilingual.ChooseLanguageDictionary(selectedLanguage), UriKind.Relative);

                this.Resources.MergedDictionaries.Add(dict);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " [180501A]", "NO-ML Error", MessageBoxButton.OK);
                btnCancel_Click(null, null);
            }            
        }

        /// <summary>
        /// Gets all categories and fills the designated combobox with these categories
        /// </summary>
        private void SetCategoryComboBoxContent()
        {
            try
            {
                CategoryList = BL_ProductCategory.GetLocalizedCategories(UserSettings.UserLanguage);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " [180501B]", "NO-ML ERROR", MessageBoxButton.OK);
                btnCancel_Click(null, null);
            }
        }

        /// <summary>
        /// When the user selects a category, gets all the properties belonging to the category, and generates the necessary tabs, labels and inputs
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbxCategories_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                tabItemMultilingualProperties.Visibility = Visibility.Visible;
                tabItemNonMultilingualProperties.Visibility = Visibility.Visible;

                //Gets the properties belonging to the selected category
                NecessaryProductPropertiesList = BL_SpecificProductProperty
                    .GetNecessaryProductProperties(UserSettings.UserLanguage, int.Parse(cmbxCategories.SelectedValue.ToString()));

                ProductModel.LocalizedProducts = new List<LocalizedProduct>();
                ProductModel.Values_Product_Properties = new List<Values_Product_ProductProperties>();

                CreateMultilingualTabsForEachLanguage();
                FillNonMultilingualInputTab();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " [180501C]", "NO-ML ERROR", MessageBoxButton.OK);
                btnCancel_Click(null, null);
            }            
        }

        #region Generate tab content for new Product

        /// <summary>
        /// Creates a tab for each language
        /// </summary>
        private void CreateMultilingualTabsForEachLanguage()
        {
            TabControlLanguages.Items.Clear();

            LocalizedLanguageList = BL_Multilingual.GetLocalizedListOfLanguages(UserSettings.UserLanguage);

            // Creates tab for each language
            foreach (LocalizedLanguageItem langItem in LocalizedLanguageList)
            {
                CreateLocalizedTab(langItem);
            }
        }
       
        /// <summary>
        /// Creates a tab for the given language
        /// </summary>
        /// <param name="langItem"></param>
        private void CreateLocalizedTab(LocalizedLanguageItem langItem)
        {
            MetroTabItem tabItem = CreateMetroTabItem(langItem);
            Grid tabGrid = new Grid { Style = Application.Current.Resources["GridBelowTabItem"] as Style };

            //Creates a wrappanel, so the stackpanel with the labels and the stackpanel with the input are nicely next to eachother
            WrapPanel wrapForStacks = new WrapPanel { HorizontalAlignment = HorizontalAlignment.Center };

            StackPanel stackPanelLeft = CreateLeftStackPanelForLabelsMultilingual(langItem);
            StackPanel stackPanelRight = CreateRightStackPanelForInputMultilingual(langItem);

            wrapForStacks.Children.Add(stackPanelLeft);
            wrapForStacks.Children.Add(stackPanelRight);

            tabGrid.Children.Add(wrapForStacks);

            tabItem.Content = tabGrid;

            TabControlLanguages.Items.Add(tabItem);
        }

        /// <summary>
        /// Creates the stackpanel with Input objects for the multilingual properties
        /// </summary>
        /// <param name="langItem"></param>
        /// <returns></returns>
        private StackPanel CreateRightStackPanelForInputMultilingual(LocalizedLanguageItem langItem)
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
                Height = _defaultHeight,
                Width = _defaultWidth,
                Margin = _defaultMargin,
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
                Width = _defaultWidth,
                TextWrapping = TextWrapping.Wrap,
                AcceptsReturn = true,
                Margin = _defaultMargin
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
                /*.OrderByDescending(np => np.IsRequired)*/)
            {

                //Makes a new property to store the value of the newly made textbox
                Values_Product_ProductProperties valueProperty = new Values_Product_ProductProperties()
                {
                    ProductPropertyID = necessaryProperty.PropertyID,
                    LanguageID = langItem.ID
                };

                // Make textbox

                TextBox customTextbox = new TextBox
                {
                    Height = _defaultHeight,
                    Width = _defaultWidth,
                    VerticalContentAlignment = VerticalAlignment.Center,
                    Margin = _defaultMargin
                };
                Binding customTextboxBinding = new Binding("Value")
                {
                    Source = valueProperty
                };
                customTextbox.SetBinding(TextBox.TextProperty, customTextboxBinding);

                stackRight.Children.Add(customTextbox);

                ProductModel.Values_Product_Properties.Add(valueProperty);
                //Product_ProductPropertiesList.Add(productProp);
            }

            ProductModel.LocalizedProducts.Add(localProduct);

            return stackRight;
        }

        /// <summary>
        /// Creates a stackpanel with Labels for the multilingual properties
        /// </summary>
        /// <param name="langItem"></param>
        /// <returns></returns>
        private StackPanel CreateLeftStackPanelForLabelsMultilingual(LocalizedLanguageItem langItem)
        {
            StackPanel stackLeft = new StackPanel();
            Label labelName = new Label
            {
                Content = BL_Multilingual.NAME(UserSettings.UserLanguage) + " : ",
                Height = _defaultHeight,
                Foreground = _defaultLabelForeground,
                FontSize = _defaultLabelFontSize,
                Margin = _defaultMargin,
                Padding = _defaultLabelPadding,
                HorizontalContentAlignment = HorizontalAlignment.Right
            };
            Label labelDescription = new Label
            {
                Content = BL_Multilingual.DESCRIPTION(UserSettings.UserLanguage) + " : ",
                Height = _defaultHeight,
                Foreground = _defaultLabelForeground,
                FontSize = _defaultLabelFontSize,
                Margin = new Thickness { Top = 20, Bottom = 120 },
                Padding = _defaultLabelPadding,
                HorizontalContentAlignment = HorizontalAlignment.Right
            };

            stackLeft.Children.Add(labelName);
            stackLeft.Children.Add(labelDescription);

            foreach (NecessaryProductPropertyViewItem necessaryProperty in
                NecessaryProductPropertiesList.Where(np => np.IsMultilingual == true && np.IsEnumeration == false)/*.OrderByDescending(np => np.IsRequired)*/)
            {
                Label customLabel = new Label
                {
                    Content = necessaryProperty.LookupName /*+ (necessaryProperty.IsRequired ? " * " : " ")*/ + " : ",
                    Height = _defaultHeight,
                    Foreground = _defaultLabelForeground,
                    FontSize = _defaultLabelFontSize,
                    Margin = _defaultMargin,
                    Padding = _defaultLabelPadding,
                    HorizontalContentAlignment = HorizontalAlignment.Right
                };
                stackLeft.Children.Add(customLabel);
            }

            return stackLeft;
        }

        /// <summary>
        /// Creates the TabItem, to give the tab an appropriate header
        /// </summary>
        /// <param name="langItem"></param>
        /// <returns></returns>
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

            // Creates a new style for the new tabItem
            Style AutoGeneratedTabItem = new Style
            {
                TargetType = typeof(MetroTabItem)
            };

            // Adds a setter to give the tabItem border
            Setter SelectedStyle = new Setter
            {
                Property = TabItem.BorderThicknessProperty,
                Value = new Thickness { Top = 2, Bottom = 2, Left = 2, Right = 2 }
            };

            // Adds a new trigger, for when the tabItem is selected
            Trigger SelectedTrigger = new Trigger
            {
                Property = TabItem.IsSelectedProperty,
                Value = true
            };

            // When the tabItem gets selected, it will generate borders, to clearly see which one is selected
            SelectedTrigger.Setters.Add(SelectedStyle);


            // The same as above for when it is selected, but now to revert the change when unselected
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

        /// <summary>
        /// Fills the tab with non multilingual input and binds it to a newly generated input
        /// </summary>
        private void FillNonMultilingualInputTab()
        {
            NonMLStackLeftLabels.Children.Clear();
            NonMLStackRightInput.Children.Clear();
            //Product_ProductPropertiesList.Clear();

            foreach (NecessaryProductPropertyViewItem necessaryProperty in 
                NecessaryProductPropertiesList.Where(np => np.IsMultilingual == false || np.IsEnumeration == true)
                /*.OrderByDescending(np => np.IsRequired)*/)
            {
                #region Textbox/Checkbox/Combobox

                if (necessaryProperty.IsEnumeration == false)
                {
                    //Product_SpecificProductProperties productProperty = new Product_SpecificProductProperties()
                    //{
                    //    SpecificProductPropertyID = necessaryProperty.PropertyID
                    //};

                    Values_Product_ProductProperties localValue = new Values_Product_ProductProperties()
                    {
                        ProductPropertyID = necessaryProperty.PropertyID,
                        LanguageID = null
                    };
                    
                    if (necessaryProperty.IsBool == false)
                    {
                        TextBox customTextbox = createNonMultilingualTextBox(localValue);

                        NonMLStackRightInput.Children.Add(customTextbox);
                        //Product_ProductPropertiesList.Add(productProperty);
                        ProductModel.Values_Product_Properties.Add(localValue);
                    }
                    else
                    {
                        CheckBox customCheckbox = CreateNonMultilingualCheckBox(localValue);

                        NonMLStackRightInput.Children.Add(customCheckbox);
                        //Product_ProductPropertiesList.Add(productProperty);
                        ProductModel.Values_Product_Properties.Add(localValue);
                    }
                }
                else
                {
                    Values_Product_ProductProperties valueProperty = new Values_Product_ProductProperties()
                    {
                        ProductPropertyID = necessaryProperty.PropertyID,
                        LanguageID = null
                    };

                    ComboBox customComboBox = CreateNonMultilingualComboBox(valueProperty);

                    NonMLStackRightInput.Children.Add(customComboBox);

                    ProductModel.Values_Product_Properties.Add(valueProperty);
                }                             

                #endregion

                #region Label
                Label customLabel = new Label
                {
                    Content = necessaryProperty.LookupName /*+ (necessaryProperty.IsRequired ? " * " : " ")*/ + " : ",
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

        /// <summary>
        /// Creates a Non Multilingual Combobox
        /// </summary>
        /// <param name="valueProperty"></param>
        /// <returns></returns>
        private ComboBox CreateNonMultilingualComboBox(Values_Product_ProductProperties valueProperty)
        {
            ComboBox returnComboBox = new ComboBox
            {
                Height = _defaultHeight,
                Width = _defaultWidth,
                VerticalContentAlignment = VerticalAlignment.Center,
                Margin = _defaultMargin,
                DisplayMemberPath = "Value",
                SelectedValuePath = "EnumerationID"
            };

            returnComboBox.SetBinding(ItemsControl.ItemsSourceProperty,
                new Binding
                {
                    Source = BL_SpecificProductProperty.
                    GetPropertyEnumerations(UserSettings.UserLanguage, valueProperty.ProductPropertyID)
                });

            returnComboBox.SetBinding(
               Selector.SelectedValueProperty,
               new Binding("EnumerationValueID") { Source = valueProperty });

            return returnComboBox;
        }

        /// <summary>
        /// Creates a non multilingual checkbox
        /// </summary>
        /// <param name="localValue"></param>
        /// <returns></returns>
        private CheckBox CreateNonMultilingualCheckBox(Values_Product_ProductProperties localValue)
        {
            CheckBox returnCheckBox = new CheckBox
            {
                Height = _defaultHeight,
                Margin = _defaultMargin,
                VerticalContentAlignment = VerticalAlignment.Center
            };
            Binding customCheckboxBinding = new Binding("Value")
            {
                Source = localValue
            };
            returnCheckBox.SetBinding(CheckBox.IsCheckedProperty, customCheckboxBinding);

            return returnCheckBox;
        }

        /// <summary>
        /// Creates a non multilingual textbox
        /// </summary>
        /// <param name="localValue"></param>
        /// <returns></returns>
        private TextBox createNonMultilingualTextBox(Values_Product_ProductProperties localValue)
        {
            TextBox returnTextBox = new TextBox
            {
                Height = _defaultHeight,
                Width = _defaultWidth,
                VerticalContentAlignment = VerticalAlignment.Center,
                Margin = _defaultMargin
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

        /// <summary>
        /// Returns to the navigation screen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
        }

        /// <summary>
        /// Submits the product
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            BL_Product.Create(ProductModel);
            Console.Beep();
        }

        /// <summary>
        /// Changes the border of a selected tabitem.
        /// (For some reason it didn't work here with styles/setters/triggers)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        private int _imgCounter = 0;
        private const int _imgDefaultWidth = 120;
        private const int _imgDefaultHeight = 120;
        private const int _firstImageWidth = 250;
        private const int _firstImageHeight = 250;

        /// <summary>
        /// Opens a filedialog to select a wanted image, and adds it to the list of images
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addImage(object sender, RoutedEventArgs e)
        {
            try
            {
                Microsoft.Win32.OpenFileDialog fileDialog = new Microsoft.Win32.OpenFileDialog
                {
                    Filter = "Image File (*.jpg; *.png)| *.jpg; *.png"
                };

                Nullable<bool> result = fileDialog.ShowDialog();

                if (result == true)
                {
                    string filename = fileDialog.FileName;

                    Image img = new Image
                    {
                        Source = new BitmapImage(new Uri(filename)),
                        Width = _imgCounter != 0 ? _imgDefaultWidth : _firstImageWidth,
                        Height = _imgCounter != 0 ? _imgDefaultHeight : _firstImageHeight,
                        Margin = new Thickness(20, 0, 20, 0),
                        AllowDrop = true,
                        VerticalAlignment = VerticalAlignment.Stretch
                    };
                    img.DragEnter += Image_DragEnter;
                    img.MouseLeftButtonDown += Image_MouseLeftButtonDown;


                    ProductImage imgItem = new ProductImage
                    {
                        FileLocation = filename,
                        Order = _imgCounter
                    };

                    ProductModel.Images.Add(imgItem);

                    imgPnl.Children.Add(img);

                    _imgCounter += 1;
                }
            }
            catch (Exception)
            {
                // TODO
                throw;
            }
            
        }

        /// <summary>
        /// Makes the images swap places when being dragged to another position
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

            ProductImage temporary = ProductModel.Images.Single(x => x.Order == initial_location);
            ProductImage temporary2 = ProductModel.Images.Single(x => x.Order == where_to_drop);

            temporary.Order = where_to_drop;
            temporary2.Order = initial_location;
            
            

            ProductModel.Images = ProductModel.Images.OrderBy(x => x.Order).ToList() ;            
        }

        /// <summary>
        /// Starts the dragging on the selected image
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            image_to_drag = (Image)e.Source;
            DragDrop.DoDragDrop(image_to_drag, image_to_drag, DragDropEffects.Move);
        }

        #endregion
    }
}

