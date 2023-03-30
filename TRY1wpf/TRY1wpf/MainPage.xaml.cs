using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
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

namespace TRY1wpf
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {

        HttpClient client = new HttpClient();
        ObservableCollection<Product> collection = new ObservableCollection<Product>();
        public MainPage()
        {
            InitializeComponent();
            Show();
        }

        private async Task Show()
        {
            var respons = await client.GetAsync("https://localhost:7298/api/Product/GetProducts");
            var products = await respons.Content.ReadAsAsync<List<Product>>();

            ListProduct.ItemsSource = products;

            foreach(var product in products)
            {
                collection.Add(product);
            }
        }
        private async void Delete_Button_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Подтвердить удаление", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                Product SelectProduct = (sender as Button).DataContext as Product;
                var respons = await client.DeleteAsync("https://localhost:7298/api/Product/DeleteProduct?id=" + SelectProduct.Id);
                Manager.MainFrame.Content = new MainPage();
            }
        }

        private async void Update_Page(object sender, RoutedEventArgs e)
        {
            Show();            
        }

        private void Add_Page(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddProductPage());
        }
    }
}
