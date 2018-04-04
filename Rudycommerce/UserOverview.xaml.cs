using Rudycommerce.LanguageResources;
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
using System.Windows.Forms;
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
        public delegate void AdminLostRights();
        public event AdminLostRights LostAdminRights;

        public UserOverview()
        {
            InitializeComponent();
            BindData();
            
            SetLanguageDictionary(RudycommerceLibrary.Settings.UserLanguage);
        }

        private void SetLanguageDictionary(Language preferredLanguage)
        {
            ResourceDictionary dict = new ResourceDictionary();

            dict.Source = new Uri(BL_Multilingual.ChooseLanguageDictionary(preferredLanguage), UriKind.Relative);

            this.Resources.MergedDictionaries.Add(dict);
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
            var user = ((FrameworkElement)sender).DataContext as DesktopUser;

            string messageboxContent = BL_Multilingual.UOVerifyAdminMessageBoxContent(user.LastName, user.FirstName, RudycommerceLibrary.Settings.UserLanguage.LocalName);
            string messageboxTitle = BL_Multilingual.UOVerifyAdminMessageBoxTitle(user.LastName, user.FirstName, RudycommerceLibrary.Settings.UserLanguage.LocalName);

            MessageBoxManager.Yes = BL_Multilingual.Yes(RudycommerceLibrary.Settings.UserLanguage.LocalName);
            MessageBoxManager.No = BL_Multilingual.No(RudycommerceLibrary.Settings.UserLanguage.LocalName);
            MessageBoxManager.Register();

            if (MessageBox.Show(messageboxContent, messageboxTitle, MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                MessageBoxManager.Unregister();

                BL_DesktopUser.VerifyByAdmin(user);
                BindData();

                BL_Mailing.UserVerified(user.LastName, user.FirstName, user.EMail, user.Username, user.PreferredLanguage.LocalName);
            }
            else
            { MessageBoxManager.Unregister(); }
        }

        private void dgrdUserOverview_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            DataGridRow _dgRow = e.Row;
            var _changedValue = _dgRow.DataContext as DesktopUser;

            BL_DesktopUser.Update(_changedValue);
        }

        private void btnDeleteUser_Click(object sender, RoutedEventArgs e)
        {
            var user = ((FrameworkElement)sender).DataContext as DesktopUser;

            string messageboxContent = BL_Multilingual.UODeleteUserMessageBoxContent(user.LastName, user.FirstName, RudycommerceLibrary.Settings.UserLanguage.LocalName);
            string messageboxTitle = BL_Multilingual.UODeleteUserMessageBoxTitle(user.LastName, user.FirstName, RudycommerceLibrary.Settings.UserLanguage.LocalName);

            MessageBoxManager.Yes = BL_Multilingual.Yes(RudycommerceLibrary.Settings.UserLanguage.LocalName);
            MessageBoxManager.No = BL_Multilingual.No(RudycommerceLibrary.Settings.UserLanguage.LocalName);
            MessageBoxManager.Register();

            if (MessageBox.Show(messageboxContent,
                                messageboxTitle,
                                MessageBoxButton.YesNo,
                                MessageBoxImage.Warning) 
                == MessageBoxResult.Yes)
            {
                MessageBoxManager.Unregister();

                dataSourceUsers.Remove(user);
            }
            else
            { MessageBoxManager.Unregister(); }
        }

        private void btnMakeUserAdmin_Click(object sender, RoutedEventArgs e)
        {
            var user = ((FrameworkElement)sender).DataContext as DesktopUser;

            string messageboxContent = BL_Multilingual.UOMakeUserAdminMessageBoxContent(user.LastName, user.FirstName, RudycommerceLibrary.Settings.UserLanguage.LocalName);
            string messageboxTitle = BL_Multilingual.UOMakeUserAdminMessageBoxTitle(user.LastName, user.FirstName, RudycommerceLibrary.Settings.UserLanguage.LocalName);

            MessageBoxManager.Yes = BL_Multilingual.Yes(RudycommerceLibrary.Settings.UserLanguage.LocalName);
            MessageBoxManager.No = BL_Multilingual.No(RudycommerceLibrary.Settings.UserLanguage.LocalName);
            MessageBoxManager.Register();

            if (MessageBox.Show(messageboxContent,
                                messageboxTitle,
                                MessageBoxButton.YesNo,
                                MessageBoxImage.Warning)
                == MessageBoxResult.Yes)
            {
                user.IsAdmin = true;
                user.VerifiedByAdmin = true;
                BL_DesktopUser.AdminLoseHisRights();

                MessageBoxManager.Unregister();

                LostAdminRights();
            }
            else
            { MessageBoxManager.Unregister(); }
        }
    }
}
