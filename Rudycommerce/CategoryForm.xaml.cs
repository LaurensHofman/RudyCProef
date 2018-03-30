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
        public LocalizedProductCategory LocalizedProductCategoryModel { get; set; }

        public CategoryForm(Language selectedLanguage)
        {
            InitializeComponent();

            ProductCategoryModel = new ProductCategory();
            LocalizedProductCategoryModel = new LocalizedProductCategory
            {
                LanguageID = BL_Language.GetDefaultLanguage().LanguageID
            };

            PotentialParents = BL_ProductCategory.GetPotentialParents(selectedLanguage);

            grdCategoryForm.DataContext = this;
        }



        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            BL_ProductCategory.Save(ProductCategoryModel, LocalizedProductCategoryModel);
            Console.Beep();
        }
    }
}
