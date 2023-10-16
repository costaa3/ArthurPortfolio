using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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
        
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter ada = new SqlDataAdapter();

        public int CurrencyId { get; private set; }

        private SqlConnection EstablishConnection()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            var conn = new SqlConnection(connectionString); // Open the connection
           
            return new SqlConnection(connectionString);
           

        }

        public MainWindow()
        {
            InitializeComponent();
            BindingCurrencies();
            CurrencySelectionComboBox.SelectedIndex = 0;
            ToCurrencyComboBox.SelectedIndex = 0;
            UpdateTable();
        }


        public void BindingCurrencies()
        {
            using (var con = EstablishConnection())
            {
                cmd = new SqlCommand("Select Id, CurrencyName from Currency_Master", con);

                DataTable dt = new DataTable();

                cmd.CommandType = CommandType.Text;

                ada = new SqlDataAdapter(cmd);

                ada.Fill(dt);

                DataRow dr = dt.NewRow();
                dr["Id"] = 0;
                dr["CurrencyName"] = "==Select==";
                ;
                dt.Rows.InsertAt(dr, 0);


                if (dt != null && dt.Rows.Count > 0)
                {
                    CurrencySelectionComboBox.ItemsSource = dt.DefaultView;
                    ToCurrencyComboBox.ItemsSource = dt.DefaultView;
                }
            }
        
            //DataTable dataTable = new DataTable();
            //dataTable.Columns.Add("Text");
            //dataTable.Columns.Add("Value");

            //dataTable.Rows.Add("==Select==", "0");
            //dataTable.Rows.Add("INR", 1);
            //dataTable.Rows.Add("USD", 75);
            //dataTable.Rows.Add("EUR", 85);
            //dataTable.Rows.Add("SAR", 20);
            //dataTable.Rows.Add("POUND", 5);
            //dataTable.Rows.Add("DEM", 43);

            //CurrencySelectionComboBox.ItemsSource = dataTable.DefaultView;
            //ToCurrencyComboBox.ItemsSource = dataTable.DefaultView;
            //ToCurrencyComboBox.SelectedValuePath = "Value";
            //ToCurrencyComboBox.DisplayMemberPath = "Text";
            //CurrencySelectionComboBox.SelectedValuePath = "Value";
            //CurrencySelectionComboBox.DisplayMemberPath = "Text";

            ToCurrencyComboBox.SelectedValuePath = "Id";
            ToCurrencyComboBox.DisplayMemberPath = "CurrencyName";
            CurrencySelectionComboBox.SelectedValuePath = "Id";
            CurrencySelectionComboBox.DisplayMemberPath = "CurrencyName";
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!int.TryParse(e.Text ,out int n))
            {
                e.Handled = true;
                return;
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

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(EnterAmountInput.Text))
            {
                MessageBox.Show("Insert an amount");
                EnterAmountInput.Focus();
            }
            else if (string.IsNullOrEmpty(CurrencyNameSelection.Text) )
            {
                MessageBox.Show("Select the currency");
                EnterAmountInput.Focus();
            }
            else
            {
                try
                {

                    using (var con = EstablishConnection())
                    {
                        con.Open();
                        if (CurrencyId > 0)
                        {

                            cmd = new SqlCommand("Update Currency_Master Set (Amount, CurrencyName) Values (@Amount,@CurrencyName Where Id = @Id ", con);
                            

                        }
                        else
                        {

                            cmd = new SqlCommand("Insert Into Currency_Master (Amount, CurrencyName) Values (@Amount,@CurrencyName)", con);
                            cmd.Parameters.AddWithValue("@Amount", EnterAmountInput.Text);
                            cmd.Parameters.AddWithValue("@CurrencyName", CurrencyNameSelection.Text);
                        }

                        cmd.ExecuteNonQuery();
                    }

                }
                catch (Exception)
                {

                    throw;
                }
                finally
                {
                    UpdateTable();
                }
            }
            //CurrenciesTable.Items.Add()
        }

        private void CurrenciesTable_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            DataGrid dtg = sender as DataGrid;
            DataRowView rowSelection = dtg.CurrentItem as DataRowView;
            MessageBox.Show(rowSelection["Id"].ToString());
            
        }

        private void UpdateTable()
        {
            using(var con =  EstablishConnection()) {
                con.Open();
                DataTable myData = new DataTable();
                cmd = new SqlCommand("Select * from Currency_Master",con);
                cmd.CommandType = CommandType.Text;
                ada = new SqlDataAdapter(cmd);
                ada.Fill(myData);
                CurrenciesTable.ItemsSource = myData.DefaultView;
            }
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            ClearFields();
        }

        private void ClearFields()
        {
            UserInputValue.Text = string.Empty;
            CurrencySelectionComboBox.SelectedIndex = 0;
            ToCurrencyComboBox.SelectedIndex = 0;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            EnterAmountInput.Text = string.Empty;
            CurrencyNameSelection.Text= string.Empty;
            CurrenciesTable.SelectedIndex = -1;
        }
    }
}
