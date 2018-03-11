using RudycommerceLibrary.BL;
using RudycommerceLibrary.BL.ProductTypes;
using RudycommerceLibrary.Entities;
using RudycommerceLibrary.Entities.Products;
using RudycommerceLibrary.Entities.Products.GamingEquipments.ElectronicEquipments;
using RudycommerceLibrary.Entities.Products.GamingEquipments.NonElectronicEquipments;
using RudycommerceLibrary.Entities.Products.LocalizedProducts;
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
        public SiteLanguage DefaultSiteLanguage { get; set; }

        string _preferredLanguage = "Nederlands";

        public Product ProductModel { get; set; }

        #region Specific product types
        public MouseMat MouseMatModel { get; set; }
        public GamingMouse MouseModel { get; set; }
        public GamingKeyboard KeyboardModel { get; set; }
        public Headset HeadsetModel { get; set; }
        public GamingController ControllerModel { get; set; }

        public LocalizedHeadset LocalizedHeadsetModel { get; set; }
        public LocalizedGamingController LocalizedGamingControllerModel { get; set; }
        public LocalizedGamingKeyboard LocalizedGamingKeyboardModel { get; set; }
        public LocalizedGamingMouse LocalizedGamingMouseModel { get; set; }
        public LocalizedMouseMat LocalizedMouseMatModel { get; set; }
        #endregion

        public NewProductForm(string selectedLanguage) : this(new Product(), selectedLanguage) { }

        public NewProductForm(Product product, string selectedLanguage)
        {
            InitializeComponent();

            this.ProductModel = product;

            grdNewProductForm.DataContext = this;

            _preferredLanguage = selectedLanguage;

            SetLanguageDictionary(selectedLanguage);

            SetDropdownBoxContents(selectedLanguage);

            GetDefaultLanguage();
            SetLabels();
        }

        private void SetDropdownBoxContents(string selectedLanguage)
        {
            cmbxProductType.ItemsSource = BL_Product.GetProductTypes(selectedLanguage);

            cmbxKeyboardLayout.ItemsSource = Enum.GetValues(typeof(Enumerations.KeyboardLayouts));

            cmbxHeadsetWearingWay.ItemsSource = BL_Headset.GetWearingWays(selectedLanguage);
        }

        private void SetLanguageDictionary(string selectedLanguage)
        {
            ResourceDictionary dict = new ResourceDictionary();

            dict.Source = new Uri(BL_Multilingual.ChooseLanguageDictionary(selectedLanguage), UriKind.Relative);

            this.Resources.MergedDictionaries.Add(dict);
        }

        private void SetLabels()
        {
            lblDefaultLanguage.Content += " " + BL_Multilingual.GetTranslatedDefaultLanguage(_preferredLanguage);
        }

        private void GetDefaultLanguage()
        {
            DefaultSiteLanguage = BL_Language.GetDefaultLanguage();
        }
        
        private void SaveProductModel()
        {
            //Here comes the validation of input

            ProductModel.ProductType = BL_Product.GetProductTypes("English")[cmbxProductType.SelectedIndex];
            ProductModel.EquipmentType = BL_Product.GetSpecificProductTypes("English", ProductModel.ProductType)[cmbxSpecificProductType.SelectedIndex];

            BL_Product.Save(ProductModel);
        }
        
        private ILocalizedProduct SetLocalizedProductModelToContent(ILocalizedProduct localizedProduct)
        {
            localizedProduct.LanguageID = DefaultSiteLanguage.LanguageID;

            localizedProduct.Name = txtName.Text;
            localizedProduct.Description = txtDescription.Text;

            return localizedProduct;
        }

        private IGeneralProduct SetProductModelToContent(IGeneralProduct productModel)
        {
            productModel.UnitPrice = decimal.Parse(txtPrice.Text);
            productModel.InitialStock = int.Parse(txtInitialStock.Text);
            productModel.IronStock = int.Parse(txtIronStock.Text);
            productModel.MaximumStock = int.Parse(txtMaxStock.Text);
            productModel.IsActive = cbIsActive.IsChecked.Value;

            productModel.CurrentStock = productModel.InitialStock;
            productModel.AvailableStock = productModel.InitialStock;

            return productModel;
        }

        private void cmbxProductType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cmbxSpecificProductType.IsEnabled = false;
            cmbxSpecificProductType.Visibility = Visibility.Collapsed;
            lblSpecificTypeOfProduct.Visibility = Visibility.Collapsed;

            HideStackPanels();

            lblSpecificTypeOfProduct.Content = cmbxProductType.SelectedValue.ToString() + " type :";
            
            if (BL_Product.GetSpecificProductTypes(_preferredLanguage, BL_Product.GetProductTypes("English")[cmbxProductType.SelectedIndex])
                != null)
            {
                cmbxSpecificProductType.ItemsSource =
                BL_Product.GetSpecificProductTypes(_preferredLanguage, BL_Product.GetProductTypes("English")[cmbxProductType.SelectedIndex]);

                cmbxSpecificProductType.IsEnabled = true;
                cmbxSpecificProductType.Visibility = Visibility.Visible;
                lblSpecificTypeOfProduct.Visibility = Visibility.Visible;
            }
        }

        private void HideStackPanels()
        {
            txtStackMouseMat.IsEnabled = false;
            txtStackMouseMat.Visibility = Visibility.Collapsed;
            lblStackMouseMat.Visibility = Visibility.Collapsed;

            txtStackMouse.IsEnabled = false;
            txtStackMouse.Visibility = Visibility.Collapsed;
            lblStackMouse.Visibility = Visibility.Collapsed;

            txtStackKeyboard.IsEnabled = false;
            txtStackKeyboard.Visibility = Visibility.Collapsed;
            lblStackKeyboard.Visibility = Visibility.Collapsed;

            txtStackHeadset.IsEnabled = false;
            txtStackHeadset.Visibility = Visibility.Collapsed;
            lblStackHeadset.Visibility = Visibility.Collapsed;

            txtStackController.IsEnabled = false;
            txtStackController.Visibility = Visibility.Collapsed;
            lblStackController.Visibility = Visibility.Collapsed;
        }

        private void cmbxSpecificProductType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // BL_Product.GetProductTypes("English")[cmbxProductType.SelectedIndex]) gets the chosen product type (gaming equipment/game)
            // BL_Product.GetSpecificProductTypes("English",...) gets the specific types in english withing the chosen product type
            HideStackPanels();

            string currentSelectedProductType = BL_Product.GetProductTypes("English")[cmbxProductType.SelectedIndex];
            
            switch ((BL_Product.GetSpecificProductTypes("English", currentSelectedProductType)[cmbxSpecificProductType.SelectedIndex]
                .ToLower()))
            {
                case "mousemat":
                    txtStackMouseMat.IsEnabled = true;
                    txtStackMouseMat.Visibility = Visibility.Visible;
                    lblStackMouseMat.Visibility = Visibility.Visible;
                    break;
                case "mouse":
                    txtStackMouse.IsEnabled = true;
                    txtStackMouse.Visibility = Visibility.Visible;
                    lblStackMouse.Visibility = Visibility.Visible;
                    break;
                case "keyboard":
                    txtStackKeyboard.IsEnabled = true;
                    txtStackKeyboard.Visibility = Visibility.Visible;
                    lblStackKeyboard.Visibility = Visibility.Visible;
                    break;
                case "headset":
                    txtStackHeadset.IsEnabled = true;
                    txtStackHeadset.Visibility = Visibility.Visible;
                    lblStackHeadset.Visibility = Visibility.Visible;
                    break;
                case "controller":
                    txtStackController.IsEnabled = true;
                    txtStackController.Visibility = Visibility.Visible;
                    lblStackController.Visibility = Visibility.Visible;
                    break;
                default:
                    break;
            }            
        }

        private void btnMouseMatSave_Click(object sender, RoutedEventArgs e)
        {
            //validation of mousemat input
            MouseMatModel = new MouseMat();

            SetProductModelToContent(MouseMatModel);

            SaveProductModel();

            MouseMatModel.Length = float.Parse(txtMouseMatLength.Text);
            MouseMatModel.Depth = float.Parse(txtMouseMatDepth.Text);
            MouseMatModel.Width = float.Parse(txtMouseMatWidth.Text);
            MouseMatModel.Weight = float.Parse(txtMouseMatWeight.Text);

            BL_MouseMat.Save(MouseMatModel, ProductModel.ProductID);

            Console.Beep();
        }

        private void btnMouseSave_Click(object sender, RoutedEventArgs e)
        {
            //validation of mouse input
            
            MouseModel = new GamingMouse();

            SetProductModelToContent(MouseModel);

            SaveProductModel();

            MouseModel.Length = float.Parse(txtMouseLength.Text);
            MouseModel.Height = float.Parse(txtMouseHeight.Text);
            MouseModel.Width = float.Parse(txtMouseWidth.Text);
            MouseModel.Weight = float.Parse(txtMouseWeight.Text);
            MouseModel.MaxResolution = int.Parse(txtMouseMaxResolution.Text);
            MouseModel.ProgrammableButtons = int.Parse(txtMouseProgrammableButtons.Text);

            BL_Mouse.Save(MouseModel, ProductModel.ProductID);

            Console.Beep();
        }

        private void btnKeyboardSave_Click(object sender, RoutedEventArgs e)
        {
            //validation of mouse input

            KeyboardModel = new GamingKeyboard();

            SetProductModelToContent(KeyboardModel);

            SaveProductModel();

            KeyboardModel.Length = float.Parse(txtKeyboardLength.Text);
            KeyboardModel.Depth = float.Parse(txtKeyboardDepth.Text);
            KeyboardModel.Width = float.Parse(txtKeyboardWidth.Text);
            KeyboardModel.Weight = float.Parse(txtKeyboardWeight.Text);
            KeyboardModel.FunctionKeys = int.Parse(txtKeyboardFunctionKeys.Text);
            KeyboardModel.Layout = cmbxKeyboardLayout.SelectedValue.ToString();

            BL_Keyboard.Save(KeyboardModel, ProductModel.ProductID);

            Console.Beep();
        }

        private void btnHeadsetSave_Click(object sender, RoutedEventArgs e)
        {
            //validation of headset input

            HeadsetModel = new Headset();
            LocalizedHeadsetModel = new LocalizedHeadset();

            SetProductModelToContent(HeadsetModel);

            SaveProductModel();

            HeadsetModel.Weight = float.Parse(txtHeadsetWeight.Text);
            HeadsetModel.IntegratedMicrophone = cbHeadsetIntegratedMicrophone.IsChecked.Value;

            BL_Headset.Save(HeadsetModel, ProductModel.ProductID);


            SetLocalizedProductModelToContent(LocalizedHeadsetModel);

            LocalizedHeadsetModel.WearingWay = BL_Headset.GetWearingWays("English")[cmbxHeadsetWearingWay.SelectedIndex];

            BL_Headset.LocalizedSave(LocalizedHeadsetModel, ProductModel.ProductID);

            Console.Beep();
        }

        private void btnControllerSave_Click(object sender, RoutedEventArgs e)
        {
            //validation of controller input

            ControllerModel = new GamingController();

            SetProductModelToContent(ControllerModel);

            SaveProductModel();

            ControllerModel.Weight = float.Parse(txtControllerWeight.Text);

            BL_Controller.Save(ControllerModel, ProductModel.ProductID);

            Console.Beep();
        }
    }
}

