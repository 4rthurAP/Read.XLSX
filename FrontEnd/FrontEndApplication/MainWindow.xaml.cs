using Domain.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
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

namespace FrontEndApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        HttpClient client = new HttpClient();
        public MainWindow()
        {
            InitializeComponent();

            client.BaseAddress = new Uri("http://localhost:5001/api/Xlsx");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            this.Loaded += MainWindow_Loaded;
        }

        async void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync("/api/Xlsx");
                response.EnsureSuccessStatusCode();
                var pagamentos = await response.Content.ReadAsAsync<List<IEnumerable<Pagamento>>>();

                ListPagamentos.ItemsSource = pagamentos;
            }
            catch(Exception exep)
            {
            }
        }
    }
}
