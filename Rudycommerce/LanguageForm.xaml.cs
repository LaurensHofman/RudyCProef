using RudycommerceLibrary.BL;
using RudycommerceLibrary.Entities;
using System;
using System.Collections.Generic;
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
        public Language Model { get; private set; }

        public LanguageForm(string selectedLanguage) : this(new Language(), selectedLanguage) { }

        public LanguageForm(Language model, string selectedLanguage)
        {
            InitializeComponent();
            this.Model = model;
            grdLanguageForm.DataContext = this;

            SetLanguageDictionary(selectedLanguage);
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            Model.LanguageName = txtLanguageName.Text;
            Model.ISO = txtISO.Text;
            Model.IsActive = cbxIsActive.IsChecked.Value;
            Model.IsDefault = cbxIsDefault.IsChecked.Value;
            
            BL_Language.Save(Model);
        }

        private void SetLanguageDictionary(string selectedLanguage)
        {
            ResourceDictionary dict = new ResourceDictionary();

            dict.Source = new Uri(BL_Multilingual.ChooseLanguageDictionary(selectedLanguage), UriKind.Relative);

            this.Resources.MergedDictionaries.Add(dict);
        }
    }
}
