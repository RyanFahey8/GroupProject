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
using System.IO;

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


        }

        private void AssignButton_Click(object sender, RoutedEventArgs e)
        {
            int seatnum = Convert.ToInt32(SeatCountTB.Text);
            if (File.Exists(FileBox.Text) == true)
            {
                var lines = File.ReadAllLines(FileBox.Text);
                Random random = new Random();
                List<int> availableseats = new List<int>();
                for(int j = 1; j <= seatnum; j++)
                {
                    availableseats.Add(j);
                }

                if(BrokenTB.Text.Length>0)
                {
                    string brokenlist = BrokenTB.Text;
                    List<int> brokenseats = brokenlist.Split(',').Select(int.Parse).ToList();
                    foreach (var brokenseat in brokenseats)
                    {
                        availableseats.Remove(Convert.ToInt32(brokenseat));
                    }
                }


                for (int i = 1; i < lines.Length; i++)
                {
                    var line = lines[i];
                    var column = line.Split(',');
                    string name = column[0];
                    StudentLB.Items.Add(name);

                    int seat;
                    do
                    {
                       seat = random.Next(seatnum);
                    } while (!availableseats.Contains(seat));


                        SeatLB.Items.Add(seat);
                        availableseats.Remove(seat);
                }
            }
        }

        private void FileButton_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            var result = dlg.ShowDialog();
            FileBox.Text = dlg.FileName;
        }
    }
}

