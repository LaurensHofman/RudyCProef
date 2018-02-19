using RudycommerceLibrary.BL;
using RudycommerceLibrary.Entities;
using RudycommerceLibrary.Entities.Products;
using RudycommerceLibrary.Entities.Products.GamingEquipments.NonElectronicEquipments;
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
        public Language DefaultLanguage { get; set; }

        public Product ProductModel { get; set; }

        public NewProductForm(string selectedLanguage) : this(new Product(), selectedLanguage) { }

        public NewProductForm(Product product, string selectedLanguage)
        {
            InitializeComponent();

            this.ProductModel = product;
            grdNewProductForm.DataContext = this;

            SetLanguageDictionary(selectedLanguage);

            SetDropdownItemsProducts(selectedLanguage);


            //GetDefaultLanguage();
            //SetLabels();
        }

        private void SetDropdownItemsProducts(string selectedLanguage)
        {
            cmbxProductType.ItemsSource = BL_Product.GetProductTypes(selectedLanguage);
            cmbxProductType.SelectedIndex = 0;
        }

        private void SetLanguageDictionary(string selectedLanguage)
        {
            ResourceDictionary dict = new ResourceDictionary();

            dict.Source = new Uri(BL_Multilingual.ChooseLanguageDictionary(selectedLanguage), UriKind.Relative);

            this.Resources.MergedDictionaries.Add(dict);
        }

        //private void SetLabels()
        //{
        //    lblDefaultLanguage.Content = "Current Default Language = " + DefaultLanguage.LanguageName;
        //}

        //private void GetDefaultLanguage()
        //{
        //    DefaultLanguage = BL_Language.GetDefaultLanguage();
        //}

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            //ProductModel.UnitPrice = decimal.Parse(txtUnitPrice.Text);
            //ProductModel.InitialStock = int.Parse(txtInitialStock.Text);
            //ProductModel.IsActive = cbxIsActive.IsChecked.Value;

            //BL_Product.Save(ProductModel);

            //LocalizedProductModel.LanguageID = DefaultLanguage.LanguageID;
            //LocalizedProductModel.ProductID = ProductModel.ProductID;

            //LocalizedProductModel.Name = txtLocalizedName.Text;
            //LocalizedProductModel.Description = txtLocalizedDescription.Text;

            //BL_LocalizedProduct.Save(LocalizedProductModel);

            //MessageBox.Show("You saved!");
        }

        private void cbProductType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ProductModel.TypeOfProduct = BL_Product.GetProductTypes("English")[cmbxProductType.SelectedIndex];
            MessageBox.Show(ProductModel.TypeOfProduct);
        }
    }
}
