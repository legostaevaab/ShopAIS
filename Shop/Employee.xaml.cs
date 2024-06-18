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

namespace Shop
{
    /// <summary>
    /// Логика взаимодействия для Employee.xaml
    /// </summary>
    public partial class Employee : Window
    {
        string connectionString;
        SqlDataAdapter adapter;
        DataTable employeeTable;
        public Employee()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["defaultConnection"].ConnectionString;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            employeeTable = new DataTable();

            try
            {
                string sql = "SELECT employee.surname, employee.name, employee.patronymic, roles.role, employee.login, employee.password FROM employee join roles on roles.id=employee.role";
                SqlConnection connection = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand(sql, connection);
                adapter = new SqlDataAdapter(command);
                connection.Open();

                adapter.Fill(employeeTable);
                employee.ItemsSource = employeeTable.DefaultView;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            employee.SelectedItem = null;
        }

        private void Search(object sender, RoutedEventArgs e)
        {
            if (searchRequest.Text != "")
            {
                try
                {
                    SqlConnection connection = new SqlConnection(connectionString);
                    connection.Open();
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"SELECT * FROM employee join roles on roles.id=employee.role WHERE employee.surname LIKE '%{searchRequest.Text}%' or employee.name LIKE '%{searchRequest.Text}%' or employee.patronymic LIKE '%{searchRequest.Text}%' or roles.role LIKE '%{searchRequest.Text}%'", connection);
                    DataTable dataTable = new DataTable();
                    sqlDataAdapter.Fill(dataTable);
                    if (dataTable.Rows.Count == 0)
                    {
                        DataSet dataSet = new DataSet();
                        sqlDataAdapter.Fill(dataSet);
                        employee.ItemsSource = dataSet.Tables[0].DefaultView;
                        MessageBox.Show("Результатов нет");
                        connection.Close();
                    }
                    else
                    {
                        DataSet dataSet = new DataSet();
                        sqlDataAdapter.Fill(dataSet);
                        employee.ItemsSource = dataSet.Tables[0].DefaultView;
                        connection.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }
            }
        }

        private void employee_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                string surname = ((DataRowView)employee.SelectedItems[0]).Row["surname"].ToString();
                string name = ((DataRowView)employee.SelectedItems[0]).Row["name"].ToString();
                string patronymic = ((DataRowView)employee.SelectedItems[0]).Row["patronymic"].ToString();
                string login = ((DataRowView)employee.SelectedItems[0]).Row["login"].ToString();
                string password = ((DataRowView)employee.SelectedItems[0]).Row["password"].ToString();
                if (surname != null)
                {
                    SqlConnection connection = new SqlConnection(connectionString);
                    connection.Open();
                    SqlCommand command = new SqlCommand($"SELECT id FROM employee WHERE surname = '{surname}' and name = '{name}' and patronymic = '{patronymic}' and login='{login}' and password ='{password}'", connection);
                    object id = command.ExecuteScalar();
                    App.Current.Properties["employeeId"] = id;
                    ChangeEmployee changeEmployee = new ChangeEmployee();
                    changeEmployee.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void Close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
