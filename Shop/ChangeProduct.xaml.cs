using System;
using System.Collections.Generic;
using System.Configuration;
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

namespace Shop
{
    /// <summary>
    /// Логика взаимодействия для ChangeProduct.xaml
    /// </summary>
    public partial class ChangeProduct : Window
    {
        object id = App.Current.Properties["productId"];
        string connectionString;
        bool old = false;
        public ChangeProduct()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["defaultConnection"].ConnectionString;
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();


            try
            {
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT sex FROM sex", connection);
                DataTable dataTable= new DataTable();
                sqlDataAdapter.Fill(dataTable);
                DataSet dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet);
                sex.ItemsSource = dataSet.Tables[0].DefaultView;
                sex.DisplayMemberPath = dataSet.Tables[0].Columns["sex"].ToString();
                sex.SelectedValuePath = dataSet.Tables[0].Columns["sex"].ToString();
                sex.SelectedItem = sex.Items[0];

                SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT age FROM ages", connection);
                DataTable table = new DataTable();
                dataAdapter.Fill(table);
                DataSet set = new DataSet();
                dataAdapter.Fill(set);
                age.ItemsSource = set.Tables[0].DefaultView;
                age.DisplayMemberPath = set.Tables[0].Columns["age"].ToString();
                age.SelectedValuePath = set.Tables[0].Columns["age"].ToString();
                age.SelectedItem = age.Items[0];

                if (id != null)
                {

                    string req = "SELECT * FROM products WHERE id = " + Convert.ToInt32(id);
                    SqlCommand command = new SqlCommand(req, connection);
                    SqlDataReader sdr = command.ExecuteReader();
                    sdr.Read();

                    type.Text = sdr[6].ToString();
                    manufacturer.Text = sdr[1].ToString();
                    price.Text = sdr[3].ToString();
                    size.Text = sdr[4].ToString();
                    balance.Text = sdr[5].ToString();
                    description.Text = sdr[2].ToString();
                    color.Text = sdr[7].ToString();
                   
                    sex.SelectedItem = sex.Items[Convert.ToInt32(sdr[8])-1];
                    age.SelectedItem = age.Items[Convert.ToInt32(sdr[9])-1];

                    connection.Close();
                    old = true;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Change(object sender, RoutedEventArgs e)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            if (!old)
            {
                if (type.Text != "" && manufacturer.Text != "" && price.Text != "" && size.Text != "" && balance.Text != "" && sex.SelectedItem!=null && age.SelectedItem!=null)
                {
                    try
                    {
                        SqlCommand cmd = new SqlCommand("Insert into products (manufacturer, description, price, size, balance, type, color, sex_id, age_id) values (@manufacturer, @description, @price, @size, @balance, @type, @color, @sex_id, @age_id)", connection);
                        cmd.Parameters.AddWithValue("@manufacturer", manufacturer.Text);
                        cmd.Parameters.AddWithValue("@description", description.Text);
                        cmd.Parameters.AddWithValue("@price", price.Text);
                        cmd.Parameters.AddWithValue("@size", size.Text);
                        cmd.Parameters.AddWithValue("@balance", balance.Text);
                        cmd.Parameters.AddWithValue("@type", type.Text);
                        cmd.Parameters.AddWithValue("@color", color.Text);
                        int sex_id = sex.SelectedIndex + 1; 
                        int age_id = age.SelectedIndex+ 1;
                        cmd.Parameters.AddWithValue("@sex_id", sex_id);
                        cmd.Parameters.AddWithValue("@age_id", age_id);
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

                if (type.Text != "" && manufacturer.Text != "" && price.Text != "" && size.Text != "" && balance.Text != "" && sex.SelectedItem != null && age.SelectedItem != null)
                {
                    try
                    {
                        int sex_id = sex.SelectedIndex + 1;
                        int age_id = age.SelectedIndex + 1;
                        SqlCommand cmd = new SqlCommand($"UPDATE products set manufacturer='{manufacturer.Text}', description='{description.Text}', price = '{price.Text}', size = '{size.Text}', balance = '{balance.Text}', type = '{type.Text}', color = '{color.Text}', sex_id={sex_id}, age_id={age_id} WHERE id=" + id, connection);

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
    }
}
