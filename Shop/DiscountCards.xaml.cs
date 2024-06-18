using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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
using System.Windows.Shapes;
using System.Configuration;
using System.Security.Policy;

namespace Shop
{
    /// <summary>
    /// Логика взаимодействия для DiscountCards.xaml
    /// </summary>
    public partial class DiscountCards : Window
    {
        string connectionString;
        SqlDataAdapter adapter;
        DataTable cardTable;
        public DiscountCards()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["defaultConnection"].ConnectionString;
        }

        private void Close(object sender, RoutedEventArgs e)
        {
           this.Close();
        }

        private void Search(object sender, RoutedEventArgs e)
        {
            if (searchRequest.Text != "")
            {
                try
                {
                    SqlConnection connection = new SqlConnection(connectionString);
                    connection.Open();
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"SELECT * FROM discountCards WHERE name LIKE '%{searchRequest.Text}%' or phone LIKE '%{searchRequest.Text}%' or discount LIKE '%{searchRequest.Text}%'", connection);
                    DataTable dataTable = new DataTable();
                    sqlDataAdapter.Fill(dataTable);
                    if (dataTable.Rows.Count == 0)
                    {
                        DataSet dataSet = new DataSet();
                        sqlDataAdapter.Fill(dataSet);
                        cards.ItemsSource = dataSet.Tables[0].DefaultView;
                        MessageBox.Show("Результатов нет");
                        connection.Close();
                    }
                    else
                    {
                        DataSet dataSet = new DataSet();
                        sqlDataAdapter.Fill(dataSet);
                        cards.ItemsSource = dataSet.Tables[0].DefaultView;
                        connection.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cardTable = new DataTable();

            try
            {
                string sql = "SELECT * FROM discountCards";
                SqlConnection connection = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand(sql, connection);
                adapter = new SqlDataAdapter(command);
                connection.Open();

                adapter.Fill(cardTable);
                cards.ItemsSource = cardTable.DefaultView;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            cards.SelectedItem = null;
        }

        private void employee_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                string name = ((DataRowView)cards.SelectedItems[0]).Row["name"].ToString();
                string phone = ((DataRowView)cards.SelectedItems[0]).Row["phone"].ToString();
                string discount = ((DataRowView)cards.SelectedItems[0]).Row["discount"].ToString();
                if (name != null)
                {
                    SqlConnection connection = new SqlConnection(connectionString);
                    connection.Open();
                    SqlCommand command = new SqlCommand($"SELECT id FROM discountCards WHERE name = '{name}' and phone = '{phone}' and discount = '{discount}'", connection);
                    object id = command.ExecuteScalar();
                    App.Current.Properties["cardId"] = id;
                    ChangeEmployee changeEmployee = new ChangeEmployee();
                    changeEmployee.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }
    }
}
