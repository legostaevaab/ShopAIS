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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Shop
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Close(object sender, RoutedEventArgs e)
        {
            this.Close();
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

        private void goToIns(object sender, RoutedEventArgs e)
        {
            Button button = new Button();
            button = (Button)sender;
            App.Current.Properties["par"] = button.Content.ToString();
            ClothesIns clothesIns = new ClothesIns();
            clothesIns.ShowDialog();

        }

        private void AddCart(object sender, RoutedEventArgs e)
        {
            ChangeCards changeCards = new ChangeCards();
            changeCards.ShowDialog();
        }
    }
}
