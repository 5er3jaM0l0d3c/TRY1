using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для AddProductPage.xaml
    /// </summary>
    public partial class AddProductPage : Page
    {
        HttpClient client = new HttpClient();
        public AddProductPage()
        {
            InitializeComponent();
        }

        private void Back_Button(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.GoBack();
        }

        private void Add_Button(object sender, RoutedEventArgs e)
        {
            Product product = new Product();
            product.Name = PName.Text;
            product.Price = double.Parse(PPrice.Text);
            product.Count = int.Parse(PCount.Text);

            Upload("https://localhost:7298/api/Product/AddProduct", product);
            Manager.MainFrame.Navigate(new MainPage());
        }

        private async Task Upload(string addres, Product product)
        {
            var jsonProduct = JsonConvert.SerializeObject(product);
            HttpContent content = new StringContent(jsonProduct, Encoding.UTF8, "application/json");
            var respons = await client.PostAsync(addres, content);
        }
    }
}
