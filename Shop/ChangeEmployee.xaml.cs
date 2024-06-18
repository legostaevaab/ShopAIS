using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;
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

namespace Shop
{
    /// <summary>
    /// Логика взаимодействия для ChangeEmployee.xaml
    /// </summary>
    public partial class ChangeEmployee : Window
    {
        object id = App.Current.Properties["employeeId"];
        string connectionString;
        bool old = false;
        public ChangeEmployee()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["defaultConnection"].ConnectionString;
        }

        private void Change(object sender, RoutedEventArgs e)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            if (!old)
            {
                if (surname.Text != "" && name.Text != "" && patronymic.Text != "" && login.Text != "" && passwprd.Text != "" && role.SelectedItem != null)
                {
                    try
                    {
                        SqlCommand cmd = new SqlCommand("Insert into employee (surname, name, patronymic, login, password, role) values (@surname, @name, @patronymic, @login, @password, @role)", connection);
                        cmd.Parameters.AddWithValue("@surname", surname.Text);
                        cmd.Parameters.AddWithValue("@name", name.Text);
                        cmd.Parameters.AddWithValue("@patronymic", patronymic.Text);
                        cmd.Parameters.AddWithValue("@login", login.Text);
                        cmd.Parameters.AddWithValue("@password", passwprd.Text);                        
                        cmd.Parameters.AddWithValue("@role", role.SelectedIndex+1);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Запись добавлена");
                        this.Close();
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message); }
                }
                else
                {
                    MessageBox.Show("Заполните все обязательные поля");
                }
            }
            else
            {

                if (surname.Text != "" && name.Text != "" && patronymic.Text != "" && login.Text != "" && passwprd.Text != "" && role.SelectedItem != null)
                {
                    try
                    {
                        SqlCommand cmd = new SqlCommand($"UPDATE products set surname='{surname.Text}', name='{name.Text}', patronymic = '{patronymic.Text}', login = '{login.Text}', password = '{passwprd.Text}', role ='{role.SelectedItem.ToString()}' WHERE id=" + id, connection);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Запись обновлена");
                        this.Close();
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message); }
                }
                else
                {
                    MessageBox.Show("Заполните все обязательные поля");
                }

            }
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();


            try
            {
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT role FROM roles", connection);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                DataSet dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet);
                role.ItemsSource = dataSet.Tables[0].DefaultView;
                role.DisplayMemberPath = dataSet.Tables[0].Columns["role"].ToString();
                role.SelectedValuePath = dataSet.Tables[0].Columns["role"].ToString();
                role.SelectedItem = role.Items[0];
                

                if (id != null)
                {

                    string req = "SELECT employee.surname, employee.name, employee.patronymic, roles.role, employee.login, employee.password FROM employee join roles on roles.id=employee.role WHERE employee.id = " + Convert.ToInt32(id);
                    SqlCommand command = new SqlCommand(req, connection);
                    SqlDataReader sdr = command.ExecuteReader();
                    sdr.Read();

                    surname.Text = sdr[0].ToString();
                    name.Text = sdr[1].ToString();
                    patronymic.Text = sdr[2].ToString();
                    login.Text = sdr[4].ToString();
                    passwprd.Text = sdr[5].ToString();

                    role.SelectedItem = role.Items[Convert.ToInt32(sdr[3])];
                    

                    connection.Close();
                    old = true;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
