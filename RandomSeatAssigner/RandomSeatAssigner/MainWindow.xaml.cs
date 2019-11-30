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
            if (File.Exists(FileBox.Text) == true)
            {
                var lines = File.ReadAllLines(FileBox.Text);
                Random random = new Random();
                List<int> availableseats = new List<int>();
                for(int j = 1; j <= 35; j++)
                {
                    availableseats.Add(j);
                }
                for (int i = 1; i < lines.Length; i++)
                {
                    var line = lines[i];
                    var column = line.Split(',');
                    string name = column[0];
                    StudentLB.Items.Add(name);

                    int seat = random.Next(35);
                    if(availableseats.Contains(seat))
                    {
                        SeatLB.Items.Add(seat);
                        availableseats.Remove(seat);
                    }
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

