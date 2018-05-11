using RudycommerceLibrary;
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
        public Language Model { get; private set; }

        public LanguageForm() : this(new Language()) { }

        public LanguageForm(Language model)
        {
            InitializeComponent();

            this.DataContext = this;

            this.Model = model;
            
            SetLanguageDictionary(UserSettings.UserLanguage);
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            Console.Beep();
            if (ValidationOnSave() == true)
            {                
                try
                {
                    BL_Language.Save(Model);
                }
                catch (RudycommerceLibrary.CustomExceptions.AlreadyADefaultLanguage)
                {
                    if (MessageBox.Show("NO-ML Make this language the new default one?", "NO-ML New default language",
                        MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        Model.IsActive = true;
                        BL_Language.ToggleOldDefaultLanguage();
                        BL_Language.Save(Model);
                    }
                }
            }
        }

        private void SetLanguageDictionary(Language selectedLanguage)
        {
            ResourceDictionary dict = new ResourceDictionary();

            dict.Source = new Uri(BL_Multilingual.ChooseLanguageDictionary(selectedLanguage), UriKind.Relative);

            this.Resources.MergedDictionaries.Add(dict);
        }

        private bool ValidationOnSave()
        {
            string localNameError = SiteLanguageValidation.ValidateLocalName(txtLocalName.Text);
            string dutchNameError = SiteLanguageValidation.ValidateDutchName(txtDutchName.Text);
            string englishNameError = SiteLanguageValidation.ValidateEnglishName(txtEnglishName.Text);
            string ISOError = SiteLanguageValidation.ValidateISO(txtISO.Text);
            string ActiveDefaultError = SiteLanguageValidation.ValidateDefaultActive(cbxIsActive.IsChecked.Value, cbxIsDefault.IsChecked.Value);

            if (localNameError == "" &&
                dutchNameError == "" &&
                englishNameError == "" &&
                ISOError == "" &&
                ActiveDefaultError == "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #region Validations on leaving textboxes
        private void txtLocalName_LostFocus(object sender, RoutedEventArgs e)
        {
            txbLocalNameError.Text = SiteLanguageValidation.ValidateLocalName(txtLocalName.Text);
        }
        private void txtDutchName_LostFocus(object sender, RoutedEventArgs e)
        {
            txbDutchNameError.Text = SiteLanguageValidation.ValidateDutchName(txtDutchName.Text);
        }
        private void txtEnglishName_LostFocus(object sender, RoutedEventArgs e)
        {
            txbEnglishNameError.Text = SiteLanguageValidation.ValidateEnglishName(txtEnglishName.Text);
        }
        private void txtISO_LostFocus(object sender, RoutedEventArgs e)
        {
            txbISOError.Text = SiteLanguageValidation.ValidateISO(txtISO.Text);
        }
        private void cbxIsActive_Click(object sender, RoutedEventArgs e)
        {
            txbIsActiveError.Text = SiteLanguageValidation.ValidateDefaultActive(cbxIsActive.IsChecked.Value, cbxIsDefault.IsChecked.Value);
        }
        private void cbxIsDefault_Click(object sender, RoutedEventArgs e)
        {
            txbIsActiveError.Text = SiteLanguageValidation.ValidateDefaultActive(cbxIsActive.IsChecked.Value, cbxIsDefault.IsChecked.Value);
        }
        #endregion

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Visibility = Visibility.Collapsed;
        }
    }
}
