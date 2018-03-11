using RudycommerceLibrary.BL;
using RudycommerceLibrary.Entities;
using RudycommerceLibrary.Utilities.Validations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Interaction logic for LanguageForm.xaml
    /// </summary>
    public partial class LanguageForm : UserControl
    {
        public SiteLanguage Model { get; private set; }

        public LanguageForm(string selectedLanguage) : this(new SiteLanguage(), selectedLanguage) { }
        
        public LanguageForm(SiteLanguage model, string selectedLanguage)
        {
            InitializeComponent();

            this.DataContext = this;

            this.Model = model;
            
            SetLanguageDictionary(selectedLanguage);
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void SetLanguageDictionary(string selectedLanguage)
        {
            ResourceDictionary dict = new ResourceDictionary();

            dict.Source = new Uri(BL_Multilingual.ChooseLanguageDictionary(selectedLanguage), UriKind.Relative);

            this.Resources.MergedDictionaries.Add(dict);
        }

        private void txtLocalName_LostFocus(object sender, RoutedEventArgs e)
        {
            txbLocalNameError.Text = SiteLanguageValidation.ValidateLocalName(txtLocalName.Text);
        }
    }
}
