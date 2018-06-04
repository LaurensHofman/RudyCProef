using MahApps.Metro.Controls;
using RudycommerceLibrary;
using RudycommerceLibrary.BL;
using RudycommerceLibrary.CustomExceptions;
using RudycommerceLibrary.Entities;
using RudycommerceLibrary.Entities.ProductsAndCategories;
using RudycommerceLibrary.Entities.ProductsAndCategories.Localized;
using RudycommerceLibrary.Models;
using RudycommerceLibrary.Properties;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
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
    /// Interaction logic for SpecificProductPropertyForm.xaml
    /// </summary>
    public partial class SpecificProductPropertyForm : UserControl
    {

        //
        //
        //
        //
        //
        //
        //
        //
        //
        //
        //
        //
        //  TODO ADD PROPERTY GROUPS
        //
        //
        //
        //
        //
        //
        //
        //
        //
        //
        //
        //
        //
        //














        public ProductProperty SpecificProductPropertyModel { get; set; }
        //public ObservableCollection<LanguageAndSpecificPropertyItem> LanguageAndSpecificPropertyList { get; set; }



        public List<LocalizedLanguageItem> LanguageList { get; set; }

        public SpecificProductPropertyForm()
        {
            InitializeComponent();

            InitializeModelsAndContents();

            SetLanguageDictionary(UserSettings.UserLanguage);
        }

        private void InitializeModelsAndContents()
        {
            SpecificProductPropertyModel = new ProductProperty();

            // gets active languages
            try
            {
                LanguageList = BL_Multilingual.GetLocalizedListOfLanguages(UserSettings.UserLanguage);
            }
            catch (DatabaseQueryError ex)
            {
                MessageBox.Show(ex.Message, "NO-ML ERROR", MessageBoxButton.OK);
                btnCancel_Click(null, null);
            }


            //LanguageAndSpecificPropertyList = new ObservableCollection<LanguageAndSpecificPropertyItem>();
            SpecificProductPropertyModel.LocalizedSpecificProductProperties = new List<LocalizedProperty>();

            foreach (LocalizedLanguageItem li in LanguageList)
            {
                CreateLocalizedTab(li);
            }

            //// creates items for the datagrid, based on the active languages
            //LanguageAndSpecificPropertyList = new ObservableCollection<LanguageAndSpecificPropertyItem>();
            //foreach (LocalizedLanguageItem li in LanguageList)
            //{
            //    LanguageAndSpecificPropertyList.Add(
            //    new LanguageAndSpecificPropertyItem() { LanguageID = li.ID, LanguageName = li.Name, PropertyName = null });
            //}

            //grdSpecificProductPropertyForm.DataContext = this;

            //SetDataGridItemsToModelList();
        }

        private void CreateLocalizedTab(LocalizedLanguageItem langItem)
        {
            MetroTabItem tabItem = CreateMetroTabItem(langItem);
            Grid tabGrid = new Grid { Style = Application.Current.Resources["GridBelowTabItem"] as Style };

            //Creates a wrappanel, so the stackpanel with the labels and the stackpanel with the input are nicely next to eachother
            WrapPanel wrapForStacks = new WrapPanel { HorizontalAlignment = HorizontalAlignment.Center };

            StackPanel stackPanelLeft = CreateLeftStackPanelForLabels(langItem);
            StackPanel stackPanelRight = CreateRightStackPanelForInput(langItem);

            wrapForStacks.Children.Add(stackPanelLeft);
            wrapForStacks.Children.Add(stackPanelRight);

            tabGrid.Children.Add(wrapForStacks);

            tabItem.Content = tabGrid;

            TabControlLanguages.Items.Add(tabItem);
        }

        private StackPanel CreateLeftStackPanelForLabels(LocalizedLanguageItem langItem)
        {
            StackPanel stackLeft = new StackPanel();
            Label labelName = new Label
            {
                Content = LangResource.Name + " : ",
                Height = _defaultHeight,
                Foreground = _defaultLabelForeground,
                FontSize = _defaultLabelFontSize,
                Margin = _defaultMargin,
                Padding = _defaultLabelPadding,
                HorizontalContentAlignment = HorizontalAlignment.Right
            };
            Label labelDescription = new Label
            {
                Content = LangResource.AdviceDescription + " : ",
                Height = _defaultHeight,
                Foreground = _defaultLabelForeground,
                FontSize = _defaultLabelFontSize,
                Margin = new Thickness { Top = 20, Bottom = 120 },
                Padding = _defaultLabelPadding,
                HorizontalContentAlignment = HorizontalAlignment.Right
            };

            stackLeft.Children.Add(labelName);
            stackLeft.Children.Add(labelDescription);

            return stackLeft;
        }

        private Thickness _defaultMargin = new Thickness { Top = 20 };
        private const int _defaultHeight = 30;
        private const int _defaultWidth = 400;
        private const int _defaultLabelFontSize = 18;
        private Thickness _defaultLabelPadding = new Thickness { Left = 0, Top = -5, Right = 0, Bottom = -5 };
        private Brush _defaultLabelForeground = Brushes.Black;

        private StackPanel CreateRightStackPanelForInput(LocalizedLanguageItem langItem)
        {
            LocalizedProperty locProp = new LocalizedProperty
            {
                LanguageID = langItem.ID
            };

            StackPanel stackRight = new StackPanel();

            TextBox txtName = new TextBox
            {
                Height = _defaultHeight,
                Width = _defaultWidth,
                Margin = _defaultMargin,
                VerticalContentAlignment = VerticalAlignment.Center
            };
            Binding nameBinding = new Binding("LookupName")
            {
                Source = locProp
            };
            txtName.SetBinding(TextBox.TextProperty, nameBinding);

            TextBox txtAdviceDescription = new TextBox
            {
                Height = 300,
                Width = _defaultWidth,
                TextWrapping = TextWrapping.Wrap,
                AcceptsReturn = true,
                Margin = _defaultMargin
            };
            Binding descriptionBinding = new Binding("AdviceDescription")
            {
                Source = locProp
            };
            txtAdviceDescription.SetBinding(TextBox.TextProperty, descriptionBinding);

            stackRight.Children.Add(txtName);
            stackRight.Children.Add(txtAdviceDescription);

            SpecificProductPropertyModel.LocalizedSpecificProductProperties.Add(locProp);

            return stackRight;
        }

        private MetroTabItem CreateMetroTabItem(LocalizedLanguageItem langItem)
        {
            MetroTabItem metroTab = new MetroTabItem
            {
                Header = langItem.Name,
                Name = $"tab{langItem.ID}",
                Padding = new Thickness { Left = 25, Right = 25 },
                Background = Brushes.Beige
            };

            //https://stackoverflow.com/questions/23377194/overwrite-mahapps-metro-style-for-me-header-tabitem
            //https://social.msdn.microsoft.com/Forums/vstudio/en-US/ffcd8d49-267c-4ccb-8ceb-b80305447cb4/c-wpf-implementing-style-using-code?forum=wpf

            // Creates a new style for the new tabItem
            Style AutoGeneratedTabItem = new Style
            {
                TargetType = typeof(MetroTabItem)
            };

            // Adds a setter to give the tabItem border
            Setter SelectedStyle = new Setter
            {
                Property = TabItem.BorderThicknessProperty,
                Value = new Thickness { Top = 2, Bottom = 2, Left = 2, Right = 2 }
            };

            // Adds a new trigger, for when the tabItem is selected
            Trigger SelectedTrigger = new Trigger
            {
                Property = TabItem.IsSelectedProperty,
                Value = true
            };

            // When the tabItem gets selected, it will generate borders, to clearly see which one is selected
            SelectedTrigger.Setters.Add(SelectedStyle);


            // The same as above for when it is selected, but now to revert the change when unselected
            Setter NotSelectedStyle = new Setter
            {
                Property = TabItem.BorderThicknessProperty,
                Value = new Thickness { Top = 0, Bottom = 0, Left = 1, Right = 1 }
            };
            Trigger NotSelectedTrigger = new Trigger
            {
                Property = TabItem.IsSelectedProperty,
                Value = false
            };
            NotSelectedTrigger.Setters.Add(NotSelectedStyle);

            AutoGeneratedTabItem.Triggers.Add(SelectedTrigger);
            AutoGeneratedTabItem.Triggers.Add(NotSelectedTrigger);

            AutoGeneratedTabItem.Setters.Add(new Setter() { Property = ControlsHelper.HeaderFontSizeProperty, Value = 18.0 });
            metroTab.Style = AutoGeneratedTabItem;

            return metroTab;

        }

        private void SetLanguageDictionary(Language selectedLanguage)
        {
            ResourceDictionary dict = new ResourceDictionary();

            dict.Source = new Uri(BL_Multilingual.ChooseLanguageDictionary(selectedLanguage), UriKind.Relative);

            this.Resources.MergedDictionaries.Add(dict);
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                BL_SpecificProductProperty.Save(SpecificProductPropertyModel/*, LanguageAndSpecificPropertyList.ToList()*/, EnumerationList.ToList());
                Console.Beep();
            }
            catch (SaveFailed)
            {
                MessageBox.Show(LangResource.ErrSaveFailedContent, LangResource.ErrSaveFailedTitle, MessageBoxButton.OK);
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
        }

        private void MLChecked(object sender, RoutedEventArgs e)
        {
            if (SpecificProductPropertyModel.IsMultilingual == true)
            {
                GenerateMultilingualDataGridColumns();
            }
            else
            {
                Generate1DataGridColumn();
            }
        }

        private void Generate1DataGridColumn()
        {
            EnumerationList = new ObservableCollection<PropertyEnumerations>();

            dgEnumeration.ItemsSource = EnumerationList;
            dgEnumeration.DataContext = EnumerationList;

            dgEnumeration.Columns.Clear();

            TextBlock header = new TextBlock()
            {
                Text = LangResource.PotentialValues
            };

            string Bindinglocation = "TemporaryNonMLValue";
            Binding valuesBinding = new Binding(Bindinglocation);

            DataGridTextColumn dgCol = new DataGridTextColumn
            {
                Header = header,
                Binding = valuesBinding,
                Width = new DataGridLength(1.0, DataGridLengthUnitType.Star)
            };

            dgEnumeration.Columns.Add(dgCol);

            AddEnumRow(null, null);
        }

        public ObservableCollection<PropertyEnumerations> EnumerationList { get; set; }

        private void GenerateMultilingualDataGridColumns()
        {
            EnumerationList = new ObservableCollection<PropertyEnumerations>();

            dgEnumeration.ItemsSource = EnumerationList;
            dgEnumeration.DataContext = EnumerationList;

            dgEnumeration.Columns.Clear();

            foreach (var lang in LanguageList)
            {
                TextBlock header = new TextBlock
                {
                    Text = lang.Name
                };
                header.Typography.Capitals = FontCapitals.SmallCaps;

                int index = LanguageList.IndexOf(lang);
                string Bindinglocation = $"ValuesList[{index}].Value";
                Binding valuesBinding = new Binding(Bindinglocation);


                DataGridTextColumn dgCol
                    = new DataGridTextColumn
                    {
                        Header = header,
                        Binding = valuesBinding,
                        Width = new DataGridLength(1.0, DataGridLengthUnitType.Star)
                    };
                dgEnumeration.Columns.Add(dgCol);
            }

            AddEnumRow(null, null);
        }

        private void AddEnumRow(object sender, RoutedEventArgs e)
        {
            PropertyEnumerations newEnum = new PropertyEnumerations();

            foreach (var lang in LanguageList)
            {
                newEnum.ValuesList.Add(
                    new LocalizedEnumerationValues
                    {
                        LanguageID = lang.ID
                    });
            }

            EnumerationList.Add(newEnum);

            dgEnumeration.ItemsSource = EnumerationList;
            dgEnumeration.DataContext = EnumerationList;
        }

        private void EnumChecked(object sender, RoutedEventArgs e)
        {
            dgEnumeration.Visibility = SpecificProductPropertyModel.IsEnumeration ? Visibility.Visible : Visibility.Collapsed;
            btnAdd.Visibility = SpecificProductPropertyModel.IsEnumeration ? Visibility.Visible : Visibility.Collapsed;

            SpecificProductPropertyModel.IsBool = false;
        }
    }
}
