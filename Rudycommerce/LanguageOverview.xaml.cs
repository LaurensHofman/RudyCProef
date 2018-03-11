using RudycommerceLibrary.BL;
using RudycommerceLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
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
    /// Interaction logic for LanguageOverview.xaml
    /// </summary>
    public partial class LanguageOverview : UserControl
    {
        private string _preferredLanguage = "Nederlands";

        public LanguageOverview() : this("Nederlands") { }

        public LanguageOverview(string preferredLanguage)
        {
            InitializeComponent();
            BindData();

            SetLanguageDictionary(preferredLanguage);

            _preferredLanguage = preferredLanguage;
        }

        private void SetLanguageDictionary(string preferredLanguage)
        {
            ResourceDictionary dict = new ResourceDictionary();

            dict.Source = new Uri(BL_Multilingual.ChooseLanguageDictionary(preferredLanguage), UriKind.Relative);

            this.Resources.MergedDictionaries.Add(dict);
        }

        public ObservableCollection<SiteLanguage> dataSourceLanguages { get; set; }

        private void BindData()
        {
            dataSourceLanguages = new ObservableCollection<SiteLanguage>(BL_Language.GetAllLanguages());
            dataSourceLanguages.CollectionChanged += DataSourceChanged;
            dgrdLanguageOverview.ItemsSource = dataSourceLanguages;
            dgrdLanguageOverview.DataContext = dataSourceLanguages;
        }

        private void DataSourceChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    foreach (SiteLanguage l in e.NewItems)
                        BL_Language.Save(l);
                    break;

                case NotifyCollectionChangedAction.Remove:
                    foreach (SiteLanguage l in e.OldItems)
                        BL_Language.Delete(l);
                    break;
            }
        }

        private void dgrdLanguageOverview_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            DataGridRow _dgRow = e.Row;
            var _changedValue = _dgRow.DataContext as SiteLanguage;

            BL_Language.Save(_changedValue);
        }
    }
}
