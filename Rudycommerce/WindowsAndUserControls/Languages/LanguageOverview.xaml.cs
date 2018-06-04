using RudycommerceLibrary;
using RudycommerceLibrary.BL;
using RudycommerceLibrary.Entities;
using RudycommerceLibrary.Utilities.Validations;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Rudycommerce
{
    /// <summary>
    /// Interaction logic for LanguageOverview.xaml
    /// </summary>
    public partial class LanguageOverview : UserControl
    {        
        public LanguageOverview()
        {
            InitializeComponent();
            BindData();
            
            SetLanguageDictionary(UserSettings.UserLanguage);
        }

        private void SetLanguageDictionary(Language preferredLanguage)
        {
            ResourceDictionary dict = new ResourceDictionary();

            dict.Source = new Uri(BL_Multilingual.ChooseLanguageDictionary(preferredLanguage), UriKind.Relative);

            this.Resources.MergedDictionaries.Add(dict);

            Thread.CurrentThread.CurrentUICulture = BL_Multilingual.GetCulture(preferredLanguage);
        }

        public ObservableCollection<Language> dataSourceLanguages { get; set; }

        private void BindData()
        {
            dataSourceLanguages = new ObservableCollection<Language>(BL_Language.GetAllLanguages());
            dataSourceLanguages.CollectionChanged += DataSourceChanged;
            dgrdLanguageOverview.ItemsSource = dataSourceLanguages;
            dgrdLanguageOverview.DataContext = dataSourceLanguages;
        }

        private void DataSourceChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    foreach (Language l in e.NewItems)
                        BL_Language.Save(l);
                    break;

                case NotifyCollectionChangedAction.Remove:
                    foreach (Language l in e.OldItems)
                        BL_Language.Delete(l);
                    break;
            }
        }

        private void dgrdLanguageOverview_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            DataGridRow _dgRow = e.Row;
            var _changedValue = _dgRow.DataContext as Language;

            if (SiteLanguageValidation.ValidateISO(_changedValue.ISO) == "")
            {
                BL_Language.Save(_changedValue);
            }            
        }
        
        private void btnDeleteLanguage_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void btnToggleLanguage_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnMakeDefault_Click(object sender, RoutedEventArgs e)
        {
            var language = ((FrameworkElement)sender).DataContext as Language;

            BL_Language.MakeLanguageDefault(language);

            BindData();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Visibility = Visibility.Collapsed;
        }
    }
}
