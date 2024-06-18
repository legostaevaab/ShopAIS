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

namespace Shop
{
    /// <summary>
    /// Логика взаимодействия для AdmPanel.xaml
    /// </summary>
    public partial class AdmPanel : Window
    {
        public AdmPanel()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            object login = App.Current.Properties["login"];
            hello.Content += login.ToString();
        }
        private void LogOff(object sender, RoutedEventArgs e)
        {
            Authorization authorization = new Authorization();
            authorization.Show();
            this.Close();
        }

        private void Close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void employers(object sender, RoutedEventArgs e)
        {
            Employee employee = new Employee();
            employee.Show();
            this.Close();
        }

        private void ToProducts(object sender, RoutedEventArgs e)
        {
            ClothesIns clothesIns = new ClothesIns();
            clothesIns.ShowDialog();
        }

        private void disCards(object sender, RoutedEventArgs e)
        {
            DiscountCards discountCards = new DiscountCards();
            discountCards.Show();
            this.Close();
        }

        private void ChangeEmployee(object sender, RoutedEventArgs e)
        {
            ChangeEmployee changeEmployee= new ChangeEmployee();
            changeEmployee.ShowDialog();
        }

        private void ChangeProduct(object sender, RoutedEventArgs e)
        {
            ChangeProduct changeProduct= new ChangeProduct();
            changeProduct.ShowDialog();
        }

        private void ChangeCard(object sender, RoutedEventArgs e)
        {
            ChangeCards changeCards = new ChangeCards();
            changeCards.ShowDialog();
        }
    }
}
