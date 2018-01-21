using RudycommerceLibrary.BL;
using RudycommerceLibrary.Entities;
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
        public LocalizedProduct LocalizedProductModel { get; set; }

        public NewProductForm() : this(new Product()) { }

        public NewProductForm(Product productModel)
        {
            InitializeComponent();

            this.ProductModel = productModel;
            grdNewProductForm.DataContext = this;

            this.LocalizedProductModel = new LocalizedProduct();

            GetDefaultLanguage();
            SetLabels();
        }

        private void SetLabels()
        {
            lblDefaultLanguage.Content = "Current Default Language = " + DefaultLanguage.LanguageName;
        }

        private void GetDefaultLanguage()
        {
            DefaultLanguage = BL_Language.GetDefaultLanguage();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            ProductModel.UnitPrice = decimal.Parse(txtUnitPrice.Text);
            ProductModel.InitialStock = int.Parse(txtInitialStock.Text);
            ProductModel.IsActive = cbxIsActive.IsChecked.Value;

            BL_Product.Save(ProductModel);

            LocalizedProductModel.LanguageID = DefaultLanguage.LanguageID;
            LocalizedProductModel.ProductID = ProductModel.ProductID;

            LocalizedProductModel.Name = txtLocalizedName.Text;
            LocalizedProductModel.Description = txtLocalizedDescription.Text;

            BL_LocalizedProduct.Save(LocalizedProductModel);

            MessageBox.Show("You saved!");
        }
    }
}
