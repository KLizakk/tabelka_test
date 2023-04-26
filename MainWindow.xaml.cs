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
using System.Net.Http.Headers;
using System.IO;

namespace tabelka
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //tworzenie nowego objektu

            Employee JhonSmith = new Employee();
            JhonSmith.ID = 5;
            JhonSmith.Name = "Jhon";
            JhonSmith.LastName = "Smith";
            JhonSmith.Wiek = 19;

            Testowa.Items.Add(JhonSmith);
        }

        public class Employee
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public string LastName { get; set; }
            public int Wiek { get; set; }
        }

        private async void Szukaj_Click(object sender, RoutedEventArgs e)
        {

            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://api-nba-v1.p.rapidapi.com/players?search=james"),
                Headers =
    {
        { "X-RapidAPI-Key", "82e608ca0amshfb8be84d382c693p152ebejsn0ed3121d87c8" },
        { "X-RapidAPI-Host", "api-nba-v1.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();

                List<Response> Zawodnicy = new List<Response>();
                
            }
        }
    }

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);

    
    public class Birth
    {
        public string date { get; set; }
        public string country { get; set; }
    }

    public class Height
    {
        public string feets { get; set; }
        public string inches { get; set; }
        public string meters { get; set; }
    }

    public class Leagues
    {
        public Standard standard { get; set; }
        public Vegas vegas { get; set; }
        public Sacramento sacramento { get; set; }
    }

    public class Nba
    {
        public int start { get; set; }
        public int pro { get; set; }
    }

    public class Parameters
    {
        public string search { get; set; }
    }

    public class Response
    {
        public int id { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public Birth birth { get; set; }
        public Nba nba { get; set; }
        public Height height { get; set; }
        public Weight weight { get; set; }
        public string college { get; set; }
        public string affiliation { get; set; }
        public Leagues leagues { get; set; }
    }

    public class Root
    {
        public string get { get; set; }
        public Parameters parameters { get; set; }
        public List<object> errors { get; set; }
        public int results { get; set; }
        public List<Response> response { get; set; }
    }

    public class Sacramento
    {
        public object jersey { get; set; }
        public bool active { get; set; }
        public string pos { get; set; }
    }

    public class Standard
    {
        public int jersey { get; set; }
        public bool active { get; set; }
        public string pos { get; set; }
    }

    public class Vegas
    {
        public int jersey { get; set; }
        public bool active { get; set; }
        public string pos { get; set; }
    }

    public class Weight
    {
        public string pounds { get; set; }
        public string kilograms { get; set; }
    }


}
