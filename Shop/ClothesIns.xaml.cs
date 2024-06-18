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
using System.Diagnostics;

namespace Shop
{
    /// <summary>
    /// Логика взаимодействия для ClothesIns.xaml
    /// </summary>
    public partial class ClothesIns : Window
    {
        string connectionString;
        SqlDataAdapter adapter;
        DataTable clothesTable;

        object names = App.Current.Properties["par"];
        public ClothesIns()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["defaultConnection"].ConnectionString;
        }

        private void LoadInfo(string sql)
        {
            clothesTable= new DataTable();
            
            try
            {

                SqlConnection connection = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand(sql, connection);
                adapter = new SqlDataAdapter(command);
                connection.Open();
                
                adapter.Fill(clothesTable);
                clothes.ItemsSource = clothesTable.DefaultView;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            clothes.SelectedItem = null;
        }


       

        private void Close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void ToMain(object sender, RoutedEventArgs e)
        {            
            this.Close();
        }

        private void clothes_PreviewMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            switch (names.ToString())
            {
                case "Женщины":
                    try
                    {
                        string type = ((DataRowView)clothes.SelectedItems[0]).Row["type"].ToString();
                        string manufacturer = ((DataRowView)clothes.SelectedItems[0]).Row["manufacturer"].ToString();
                        string price = ((DataRowView)clothes.SelectedItems[0]).Row["price"].ToString();
                        string size = ((DataRowView)clothes.SelectedItems[0]).Row["size"].ToString();
                        string color = ((DataRowView)clothes.SelectedItems[0]).Row["color"].ToString();
                        if (type != null)
                        {
                            SqlConnection connection = new SqlConnection(connectionString);
                            connection.Open();
                            SqlCommand command = new SqlCommand($"SELECT id FROM products WHERE type = '{type}' and manufacturer = '{manufacturer}' and price = '{price}' and size='{size}' and color ='{color}'", connection);
                            object productId = command.ExecuteScalar();
                            App.Current.Properties["productId"] = productId;
                            ChangeProduct changeProduct = new ChangeProduct();
                            changeProduct.ShowDialog();
                            
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);

                    }
                    break;
                case "Мужчины":
                    try
                    {
                        string type = ((DataRowView)clothes.SelectedItems[0]).Row["type"].ToString();
                        string manufacturer = ((DataRowView)clothes.SelectedItems[0]).Row["manufacturer"].ToString();
                        string price = ((DataRowView)clothes.SelectedItems[0]).Row["price"].ToString();
                        string size = ((DataRowView)clothes.SelectedItems[0]).Row["size"].ToString();
                        string color = ((DataRowView)clothes.SelectedItems[0]).Row["color"].ToString();
                        if (type != null)
                        {
                            SqlConnection connection = new SqlConnection(connectionString);
                            connection.Open();
                            SqlCommand command = new SqlCommand($"SELECT id FROM products WHERE type = '{type}' and manufacturer = '{manufacturer}' and price = '{price}' and size='{size}' and color ='{color}'", connection);
                            object productId = command.ExecuteScalar();
                            App.Current.Properties["productId"] = productId;
                            
                            ChangeProduct changeProduct = new ChangeProduct();
                            changeProduct.ShowDialog();
                            
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);

                    }
                    break;
                case "Подростки":
                    try
                    {
                        string type = ((DataRowView)clothes.SelectedItems[0]).Row["type"].ToString();
                        string manufacturer = ((DataRowView)clothes.SelectedItems[0]).Row["manufacturer"].ToString();
                        string price = ((DataRowView)clothes.SelectedItems[0]).Row["price"].ToString();
                        string size = ((DataRowView)clothes.SelectedItems[0]).Row["size"].ToString();
                        string color = ((DataRowView)clothes.SelectedItems[0]).Row["color"].ToString();
                        if (type != null)
                        {
                            SqlConnection connection = new SqlConnection(connectionString);
                            connection.Open();
                            SqlCommand command = new SqlCommand($"SELECT id FROM products WHERE type = '{type}' and manufacturer = '{manufacturer}' and price = '{price}' and size='{size}' and color ='{color}'", connection);
                            object productId = command.ExecuteScalar();
                            App.Current.Properties["productId"] = productId;
                            ChangeProduct changeProduct = new ChangeProduct();
                            changeProduct.ShowDialog();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);

                    }
                    break;
                case "Дети":
                    try
                    {
                        string type = ((DataRowView)clothes.SelectedItems[0]).Row["type"].ToString();
                        string manufacturer = ((DataRowView)clothes.SelectedItems[0]).Row["manufacturer"].ToString();
                        string price = ((DataRowView)clothes.SelectedItems[0]).Row["price"].ToString();
                        string size = ((DataRowView)clothes.SelectedItems[0]).Row["size"].ToString();
                        string color = ((DataRowView)clothes.SelectedItems[0]).Row["color"].ToString();
                        if (type != null)
                        {
                            SqlConnection connection = new SqlConnection(connectionString);
                            connection.Open();
                            SqlCommand command = new SqlCommand($"SELECT id FROM products WHERE type = '{type}' and manufacturer = '{manufacturer}' and price = '{price}' and size='{size}' and color ='{color}'", connection);
                            object productId = command.ExecuteScalar();
                            App.Current.Properties["productId"] = productId;
                            ChangeProduct changeProduct = new ChangeProduct();
                            changeProduct.ShowDialog();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);

                    }
                    break;
                case "Малыши":
                    try
                    {
                        string type = ((DataRowView)clothes.SelectedItems[0]).Row["type"].ToString();
                        string manufacturer = ((DataRowView)clothes.SelectedItems[0]).Row["manufacturer"].ToString();
                        string price = ((DataRowView)clothes.SelectedItems[0]).Row["price"].ToString();
                        string size = ((DataRowView)clothes.SelectedItems[0]).Row["size"].ToString();
                        string color = ((DataRowView)clothes.SelectedItems[0]).Row["color"].ToString();
                        if (type != null)
                        {
                            SqlConnection connection = new SqlConnection(connectionString);
                            connection.Open();
                            SqlCommand command = new SqlCommand($"SELECT id FROM products WHERE type = '{type}' and manufacturer = '{manufacturer}' and price = '{price}' and size='{size}' and color ='{color}'", connection);
                            object productId = command.ExecuteScalar();
                            App.Current.Properties["productId"] = productId;
                            ChangeProduct changeProduct = new ChangeProduct();
                            changeProduct.ShowDialog();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);

                    }
                    break;

            }

            
        }

        private void Search(object sender, RoutedEventArgs e)
        {
            if (searchRequest.Text!="")
            {
                try
                {
                    SqlConnection connection = new SqlConnection(connectionString);
                    connection.Open();
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"SELECT * FROM products WHERE type LIKE '%{searchRequest.Text}%' or manufacturer LIKE '%{searchRequest.Text}%' or description LIKE '%{searchRequest.Text}%' or color LIKE '%{searchRequest.Text}%'", connection);
                    DataTable dataTable = new DataTable();
                    sqlDataAdapter.Fill(dataTable);
                    if(dataTable.Rows.Count==0)
                    {
                        DataSet dataSet = new DataSet();
                        sqlDataAdapter.Fill(dataSet);
                        clothes.ItemsSource = dataSet.Tables[0].DefaultView;
                        MessageBox.Show("Результатов нет");
                        connection.Close();
                    }
                    else
                    {
                        DataSet dataSet = new DataSet();
                        sqlDataAdapter.Fill(dataSet);
                        clothes.ItemsSource = dataSet.Tables[0].DefaultView;
                        connection.Close() ;
                    }    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }
            }
            else
            {
                MessageBox.Show("Заполните поле");
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            switch (names.ToString())
            {
                case "Женщины":
                    firstTB.Text = "Низ";
                    secondTB.Text = "Верх";
                    thirdTB.Text = "Платья";
                    fourthTB.Text = "Нижнее бельё";
                    fifthsTB.Text = "Верхняя одежда";
                    LoadInfo("SELECT * FROM products where sex_id='2' or sex_id='3' AND age_id='4'");
                    break;
                case "Мужчины":
                    firstTB.Text = "Низ";
                    secondTB.Text = "Верх";
                    thirdTB.Text = "Костюмы";
                    fourthTB.Text = "Нижнее бельё";
                    fifthsTB.Text = "Верхняя одежда";
                    LoadInfo("SELECT * FROM products where sex_id='1' or sex_id='3' AND age_id='4'");
                    break;
                case "Подростки":
                    firstTB.Text = "Низ";
                    secondTB.Text = "Верх";
                    thirdTB.Text = "Платья и костюмы";
                    fourthTB.Text = "Нижнее бельё";
                    fifthsTB.Text = "Верхняя одежда";
                    LoadInfo("SELECT * FROM products where age_id='3'");
                    break;
                case "Дети":
                    firstTB.Text = "Низ";
                    secondTB.Text = "Верх";
                    thirdTB.Text = "Платья и костюмы";
                    fourthTB.Text = "Нижнее бельё";
                    fifthsTB.Text = "Верхняя одежда";
                    LoadInfo("SELECT * FROM products where age_id='2'");
                    break;
                case "Малыши":
                    firstTB.Text = "Низ";
                    secondTB.Text = "Верх";
                    thirdTB.Text = "Платья и костюмы";
                    fourthTB.Text = "Нижнее бельё";
                    fifthsTB.Text = "Верхняя одежда";
                    LoadInfo("SELECT * FROM products where age_id='1'");
                    break;

            }
        }
        private void firstBT_Click(object sender, RoutedEventArgs e)
        {
            switch (names)
            {
                case "Женщины":
                    LoadInfo("SELECT * FROM products where (sex_id='2' or sex_id='3') AND age_id='4' AND type='низ'");
                    break;
                case "Мужчины":
                    LoadInfo("SELECT * FROM products where (sex_id='1' or sex_id='3') AND age_id='4' AND type='низ'");
                    break;
                case "Подростки":
                    LoadInfo("SELECT * FROM products where age_id='3' AND type='низ'");

                    break;
                case "Дети":
                    LoadInfo("SELECT * FROM products where age_id='2' AND type='низ'");
                    break;
                case "Малыши":
                    LoadInfo("SELECT * FROM products where age_id='1' AND type='низ'");
                    break;
            }
        }

        private void secondBT_Click(object sender, RoutedEventArgs e)
        {
            switch (names)
            {
                case "Женщины":
                    LoadInfo("SELECT * FROM products where (sex_id='2' or sex_id='3') AND age_id='4' AND type='верх'");
                    break;
                case "Мужчины":
                    LoadInfo("SELECT * FROM products where (sex_id='1' or sex_id='3') AND age_id='4' AND type='верх'");
                    break;
                case "Подростки":
                    LoadInfo("SELECT * FROM products where age_id='3' AND type='верх'");

                    break;
                case "Дети":
                    LoadInfo("SELECT * FROM products where age_id='2' AND type='верх'");
                    break;
                case "Малыши":
                    LoadInfo("SELECT * FROM products where age_id='1' AND type='верх'");
                    break;
            }
        }

        private void thirdBT_Click(object sender, RoutedEventArgs e)
        {
            switch (names)
            {
                case "Женщины":
                    LoadInfo("SELECT * FROM products where (sex_id='2' or sex_id='3') AND age_id='4' AND type='платье'");
                    break;
                case "Мужчины":
                    LoadInfo("SELECT * FROM products where (sex_id='1' or sex_id='3') AND age_id='4' AND type='костюм'");
                    break;
                case "Подростки":
                    LoadInfo("SELECT * FROM products where age_id='3' AND type='платье' OR type='костюм'");

                    break;
                case "Дети":
                    LoadInfo("SELECT * FROM products where age_id='2' AND type='платье' OR type='костюм'");
                    break;
                case "Малыши":
                    LoadInfo("SELECT * FROM products where age_id='1' AND type='платье' OR type='костюм'");
                    break;
            }
        }

        private void fourthBT_Click(object sender, RoutedEventArgs e)
        {
            switch (names)
            {
                case "Женщины":
                    LoadInfo("SELECT * FROM products where (sex_id='2' or sex_id='3') AND age_id='4' AND type='нижнее бельё'");
                    break;
                case "Мужчины":
                    LoadInfo("SELECT * FROM products where (sex_id='1' or sex_id='3') AND age_id='4' AND type='нижнее бельё'");
                    break;
                case "Подростки":
                    LoadInfo("SELECT * FROM products where age_id='3' AND type='нижнее бельё'");

                    break;
                case "Дети":
                    LoadInfo("SELECT * FROM products where age_id='2' AND type='нижнее бельё'");
                    break;
                case "Малыши":
                    LoadInfo("SELECT * FROM products where age_id='1' AND type='нижнее бельё'");
                    break;
            }
        }

        private void fifthsBT_Click(object sender, RoutedEventArgs e)
        {
            switch (names)
            {
                case "Женщины":
                    LoadInfo("SELECT * FROM products where (sex_id='2' or sex_id='3') AND age_id='4' AND type='верхняя одежда'");
                    break;
                case "Мужчины":
                    LoadInfo("SELECT * FROM products where (sex_id='1' or sex_id='3') AND age_id='4' AND type='верхняя одежда'");
                    break;
                case "Подростки":
                    LoadInfo("SELECT * FROM products where age_id='3' AND type='верхняя одежда'");

                    break;
                case "Дети":
                    LoadInfo("SELECT * FROM products where age_id='2' AND type='верхняя одежда'");
                    break;
                case "Малыши":
                    LoadInfo("SELECT * FROM products where age_id='1' AND type='верхняя одежда'");
                    break;
            }
        }
    }
}
