using RudycommerceLibrary;
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
    /// Interaction logic for Test.xaml
    /// </summary>
    public partial class Test : UserControl
    {
        private readonly AppDBContext context;

        public ObservableCollection<LocalizedProduct> dataSource { get; set; }

        public Test()
        {
            InitializeComponent();
            context = AppDBContext.Instance();
            BindData();
        }

        private void BindData()
        {
            dataSource = new ObservableCollection<LocalizedProduct>(BL_LocalizedProduct.GetAll());
            dataSource.CollectionChanged += DataSourceChanged;
            grdDVDOverview.ItemsSource = dataSource;
            grdDVDOverview.DataContext = dataSource;
        }

        private void DataSourceChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            //switch (e.Action)
            //{
            //    case NotifyCollectionChangedAction.Add:
            //        foreach (LocalizedProduct lp in e.NewItems)
            //            BL_LocalizedProduct.Save(lp);
            //        break;

            //    case NotifyCollectionChangedAction.Remove:
            //        foreach (LocalizedProduct lp in e.OldItems)
            //            BL_LocalizedProduct.Delete(lp);
            //        break;
            //}
        }

       
    }
}
