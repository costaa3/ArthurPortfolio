using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
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

namespace CurrencyConverter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            BindingCurrencies();
        }


        public void BindingCurrencies()
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Text");
            dataTable.Columns.Add("Value");

            dataTable.Rows.Add("==Select==", "0");
            dataTable.Rows.Add("INR", 1);
            dataTable.Rows.Add("USD", 75);
            dataTable.Rows.Add("EUR", 85);
            dataTable.Rows.Add("SAR", 20);
            dataTable.Rows.Add("POUND", 5);
            dataTable.Rows.Add("DEM", 43);

            CurrencySelectionComboBox.ItemsSource = dataTable.DefaultView;
            ToCurrencyComboBox.ItemsSource = dataTable.DefaultView;
            ToCurrencyComboBox.SelectedValuePath = "Value";
            ToCurrencyComboBox.DisplayMemberPath = "Text";
            CurrencySelectionComboBox.SelectedValuePath = "Value";
            CurrencySelectionComboBox.DisplayMemberPath= "Text";
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!int.TryParse(e.Text ,out int n))
            {
                
                //e.Text = string.Empty; 
            }
        }

        private void Convert_Click(object sender, RoutedEventArgs e)
        {
            if (CurrencySelectionComboBox.SelectedIndex == 0 || ToCurrencyComboBox.SelectedIndex == 0)
            {
                MessageBox.Show(@"Please select the currency");
                return;
            }
            else
            {
                double value = double.Parse(UserInputValue.Text);
                double result= value * (double.Parse(CurrencySelectionComboBox.SelectedValue.ToString())) / double.Parse(ToCurrencyComboBox.SelectedValue.ToString());
                ResultLabel.Content = result.ToString("N3");
            }
        }
    }
}
