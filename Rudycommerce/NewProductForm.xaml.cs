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
        public Language DefaultSiteLanguage { get; set; }
      
        public NewProductForm() : this(0) { }

        public NewProductForm(int productID)
        {
            InitializeComponent();
            
            grdNewProductForm.DataContext = this;

            SetLanguageDictionary(RudycommerceLibrary.Settings.UserLanguage);

            SetDropdownBoxContents(RudycommerceLibrary.Settings.UserLanguage);

            GetDefaultLanguage();
            SetLabels();
        }

        private void SetDropdownBoxContents(Language selectedLanguage)
        {
            //cmbxProductType.ItemsSource = BL_Product.GetProductTypes(selectedLanguage);

            //cmbxKeyboardLayout.ItemsSource = Enum.GetValues(typeof(Enumerations.KeyboardLayouts));

            //cmbxHeadsetWearingWay.ItemsSource = BL_Headset.GetWearingWays(selectedLanguage);
        }

        private void SetLanguageDictionary(Language selectedLanguage)
        {
            ResourceDictionary dict = new ResourceDictionary();

            dict.Source = new Uri(BL_Multilingual.ChooseLanguageDictionary(selectedLanguage), UriKind.Relative);

            this.Resources.MergedDictionaries.Add(dict);
        }

        private void SetLabels()
        {
            lblDefaultLanguage.Content += " " + BL_Multilingual.GetTranslatedDefaultLanguage(RudycommerceLibrary.Settings.UserLanguage);
        }

        private void GetDefaultLanguage()
        {
            DefaultSiteLanguage = BL_Language.GetDefaultLanguage();
        }        
    }
}

