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

namespace RandomSeatAssigner
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();





            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = client.GetAsync(@"https://lukejlen.github.io/studentsjson/").Result;
                if (response.IsSuccessStatusCode)
                {
                    var content = response.Content.ReadAsStringAsync().Result;
                    var VARIABLE = JsonConvert.DeserializeObject<students>(content);
                }
            }


            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response2 = client.GetAsync(@"https://lukejlen.github.io/workstationJSON/").Result;
                if (response2.IsSuccessStatusCode)
                {
                    var content2 = response2.Content.ReadAsStringAsync().Result;
                    var VARIABLE2 = JsonConvert.DeserializeObject<workstation>(content2);
                }




            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {


        }
    }
}

