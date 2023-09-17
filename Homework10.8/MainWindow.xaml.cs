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

namespace Homework10._8
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Consultant user = new Consultant();
        }
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Clients_Load();

        }

        private void Clients_Load()
        {
            ClientsRepository clientBase = new ClientsRepository();
            clientBase.readClientBase();
            ListBox_Clients.Items.Clear();

            foreach (Client client in clientBase.clients)
            {
                ListBox_Clients.Items.Add(client);
            }
        }
    }
}
