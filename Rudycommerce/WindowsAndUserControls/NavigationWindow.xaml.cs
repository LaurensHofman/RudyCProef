using MahApps.Metro.Controls;
using Rudycommerce.WindowsAndUserControls.Products;
using RudycommerceLibrary;
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
using System.Windows.Controls.Ribbon;
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
    /// Interaction logic for NavigationWindow.xaml
    /// </summary>
    public partial class NavigationWindow : MetroWindow
    {
        public NavigationWindow(int currentUserID)
        {
            InitializeComponent();
            UserSettings.SetDesktopUser(currentUserID);

            SetLanguage();
            EnableUserTab();
        }

        private void EnableUserTab()
        {
            if (UserSettings.CurrentUser.IsAdmin == true)
            {
                menuManageUsers.IsEnabled = true;
                menuManageUsers.Visibility = Visibility.Visible;
            }
        }

        private void HideAllUserControl()
        {
            foreach (ContentControl contentControl in gridUserControls.Children)
            {
                contentControl.Visibility = Visibility.Collapsed;
            }
        }

        private void SetLanguage()
        {
            UserSettings.UserLanguage = BL_DesktopUser.UserPreferredLanguage(UserSettings.CurrentUser.UserID);
            SetLanguageDictionary(UserSettings.UserLanguage);            
        }
        
        private void SetLanguageDictionary(Language selectedLanguage)
        {
            ResourceDictionary dict = new ResourceDictionary();

            dict.Source = new Uri(BL_Multilingual.ChooseLanguageDictionary(selectedLanguage), UriKind.Relative);

            this.Resources.MergedDictionaries.Add(dict);

            Thread.CurrentThread.CurrentUICulture = BL_Multilingual.GetCulture(selectedLanguage);
        }
      
        private void menuItemAddProduct(object sender, RoutedEventArgs e)
        {
            HideAllUserControl();
            if (ucAddProduct.Content == null || (ucAddProduct.Content as NewProductForm).Visibility == Visibility.Collapsed)
            {
                ucAddProduct.Content = new NewProductForm();
            }
            ucAddProduct.Visibility = Visibility.Visible;
            (ucAddProduct.Content as NewProductForm).Visibility = Visibility.Visible;
        }

        private void menuItemAddCategory(object sender, RoutedEventArgs e)
        {
            HideAllUserControl();
            if (ucAddCategory.Content == null || (ucAddCategory.Content as CategoryForm).Visibility == Visibility.Collapsed)
            {
                ucAddCategory.Content = new CategoryForm();
            }
            ucAddCategory.Visibility = Visibility.Visible;
            (ucAddCategory.Content as CategoryForm).Visibility = Visibility.Visible;
        }

        private void menuItemAddProperty(object sender, RoutedEventArgs e)
        {
            HideAllUserControl();
            if (ucAddProductProperty.Content == null || (ucAddProductProperty.Content as SpecificProductPropertyForm).Visibility == Visibility.Collapsed)
            {
                ucAddProductProperty.Content = new SpecificProductPropertyForm();
            }
            ucAddProductProperty.Visibility = Visibility.Visible;
            (ucAddProductProperty.Content as SpecificProductPropertyForm).Visibility = Visibility.Visible;
        }

        private void menuItemAddLanguage(object sender, RoutedEventArgs e)
        {
            HideAllUserControl();
            if (ucAddLanguage.Content == null || (ucAddLanguage.Content as LanguageForm).Visibility == Visibility.Collapsed)
            {
                ucAddLanguage.Content = new LanguageForm();
            }
            ucAddLanguage.Visibility = Visibility.Visible;
            (ucAddLanguage.Content as LanguageForm).Visibility = Visibility.Visible;
        }

        private void menuItemLanguageOverview(object sender, RoutedEventArgs e)
        {
            HideAllUserControl();
            if (ucLanguageOverview.Content == null || (ucLanguageOverview.Content as LanguageOverview).Visibility == Visibility.Collapsed)
            {
                ucLanguageOverview.Content = new LanguageOverview();
            }
            ucLanguageOverview.Visibility = Visibility.Visible;
            (ucLanguageOverview.Content as LanguageOverview).Visibility = Visibility.Visible;
        }

        private void menuItemManageUsers(object sender, RoutedEventArgs e)
        {
            HideAllUserControl();

            if (ucManageUsers.Content == null || (ucManageUsers.Content as UserOverview).Visibility == Visibility.Collapsed)
            {
                UserOverview _userOverview = new UserOverview();
                _userOverview.LostAdminRights += LogOut;

                ucManageUsers.Content = _userOverview;
            }
            ucManageUsers.Visibility = Visibility.Visible;
            (ucManageUsers.Content as UserOverview).Visibility = Visibility.Visible;
        }

        private void menuItemSettings(object sender, RoutedEventArgs e)
        {
            HideAllUserControl();

            if (ucSettings.Content == null || (ucManageUsers.Content as UserOverview).Visibility == Visibility.Collapsed)
            {
                ManageAccount _manageAccount = new ManageAccount();
                _manageAccount.OnAccountSave += ApplySettings;

                ucSettings.Content = _manageAccount;
            }
            ucSettings.Visibility = Visibility.Visible;
            (ucSettings.Content as ManageAccount).Visibility = Visibility.Visible;
        }

        private void LogOut()
        {
            LoginWindow relogWindow = new LoginWindow();
            relogWindow.Show();

            this.Close();
        }

        private void ApplySettings(Language selectedLanguage)
        {
            UserSettings.UserLanguage = selectedLanguage;

            SetLanguageDictionary(UserSettings.UserLanguage);

            foreach (ContentControl contentControl in gridUserControls.Children)
            {
                contentControl.Content = null;
            }            
        }
        
        //private void AnimatedTabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    if (tabItemSettings.IsSelected)
        //    {
        //        var _settings = new ManageAccount();
        //        _settings.OnAccountSave += ApplySettings;

        //        userControlSettings.Content = _settings;
        //    }

        //    Thickness notSelected = new Thickness { Bottom = 0, Top = 0, Left = 1, Right = 1 };
        //    Thickness Selected = new Thickness { Bottom = 2, Top = 2, Left = 2, Right = 2 };

        //    tabItemProducts.BorderThickness = notSelected;
        //    tabItemLanguages.BorderThickness = notSelected;
        //    tabItemSettings.BorderThickness = notSelected;
        //    tabItemUsers.BorderThickness = notSelected;

        //    if (tabItemProducts.IsSelected)
        //    {
        //        tabItemProducts.BorderThickness = Selected;
        //    }
        //    if (tabItemLanguages.IsSelected)
        //    {
        //        tabItemLanguages.BorderThickness = Selected;
        //    }
        //    if (tabItemSettings.IsSelected)
        //    {
        //        tabItemSettings.BorderThickness = Selected;
        //    }
        //    if (tabItemUsers.IsSelected)
        //    {
        //        tabItemUsers.BorderThickness = Selected;
        //    }
        //}

    }
}
