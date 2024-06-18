using System;
using System.Collections.Generic;
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
using System.Data.SqlClient;
using System.Data;
using System.Windows.Controls.Primitives;
using System.Data.Common;

namespace Shop
{
    /// <summary>
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization : Window
    {
        string connectionString;
        public Authorization()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            
            SqlCommand command = new SqlCommand("SELECT role FROM employee WHERE login = '" + log.Text + "'", connection);
            object id = command.ExecuteScalar();
            SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT login FROM employee WHERE login ='" + log.Text + "' and password ='" + pass.Password + "'", connectionString);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            try
            {
                if (dataTable.Rows.Count == 0)
                {
                    MessageBox.Show("Неверный логин или пароль");
                    connection.Close();
                }
                else
                {
                    App.Current.Properties["login"] = log.Text.ToString();
                    if (Convert.ToInt32(id) == 2)
                    {
                        AdmPanel admPanel = new AdmPanel();
                        admPanel.Show();
                        connection.Close();
                        this.Close();
                        
                    }
                    else
                    {
                        MainWindow mainWindow = new MainWindow();
                        mainWindow.Show();
                        connection.Close();
                        this.Close();
                    }


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
