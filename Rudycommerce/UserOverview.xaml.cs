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
    /// Interaction logic for UserOverview.xaml
    /// </summary>
    public partial class UserOverview : UserControl
    {
        public UserOverview()
        {
            InitializeComponent();
            BindData();
        }
        
        public ObservableCollection<DesktopUser> dataSourceUsers { get; set; }

        private void BindData()
        {
            dataSourceUsers = new ObservableCollection<DesktopUser>(BL_DesktopUser.GetAll());
            dataSourceUsers.CollectionChanged += DataSourceChanged;
            dgrdUserOverview.ItemsSource = dataSourceUsers;
            dgrdUserOverview.DataContext = dataSourceUsers;
        }
        
        private void DataSourceChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    foreach (DesktopUser du in e.NewItems)
                        BL_DesktopUser.Update(du);
                    break;

                case NotifyCollectionChangedAction.Remove:
                    foreach (DesktopUser du in e.OldItems)
                        BL_DesktopUser.Delete(du);
                    break;
            }
        }

        private void btnVerifyByAdmin_Click(object sender, RoutedEventArgs e)
        {
            var obj = ((FrameworkElement)sender).DataContext as DesktopUser;

            if (MessageBox.Show($"Are you sure you want to give {obj.LastName} {obj.FirstName} access to this application?", $"Verify {obj.LastName} {obj.FirstName}", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                obj.VerifiedByAdmin = true;

                BL_DesktopUser.Update(obj);
                BindData();
            }
        }

        private void dgrdUserOverview_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            DataGridRow _dgRow = e.Row;
            var _changedValue = _dgRow.DataContext as DesktopUser;

            BindData();
        }
    }
}
