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
    /// Логика взаимодействия для ChangeCards.xaml
    /// </summary>
    public partial class ChangeCards : Window
    {
        object id = App.Current.Properties["cardId"];
        string connectionString;
        bool old = false;
        public ChangeCards()
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
                if (name.Text != "" && phone.Text != "" && discount.Text != "")
                {
                    try
                    {
                        SqlCommand cmd = new SqlCommand("Insert into discountCards (name, phone, discount) values (@name, @phone, @discount)", connection);
                        cmd.Parameters.AddWithValue("@name", name.Text);
                        cmd.Parameters.AddWithValue("@phone", Convert.ToInt32(phone.Text));
                        cmd.Parameters.AddWithValue("@discount", Convert.ToInt32(discount.Text));                        
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

                if (name.Text != "" && phone.Text != "" && discount.Text != "")
                {
                    try
                    {
                       SqlCommand cmd = new SqlCommand($"UPDATE discountCards set name='{name.Text}', phone='{phone.Text}', discount = '{discount.Text}' WHERE id=" + id, connection);

                        cmd.Parameters.AddWithValue("@id", id);
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
                if (id != null)
                {

                    string req = "SELECT * FROM discountCards WHERE id = " + Convert.ToInt32(id);
                    SqlCommand command = new SqlCommand(req, connection);
                    SqlDataReader sdr = command.ExecuteReader();
                    sdr.Read();

                    name.Text = sdr[1].ToString();
                    phone.Text = sdr[2].ToString();
                    discount.Text = sdr[3].ToString();
                    
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
