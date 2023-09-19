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

        Consultant user;
        ClientsRepository clientBase;

        public MainWindow()
        {
            InitializeComponent();
            user = new Consultant();
            clientBase = new ClientsRepository();
            TextBoxClientAccess(user.GetClientDataEditAccess());
            ClientsLoad();

        }
        /// <summary>
        /// Задаем доступ к изменению полей в зависимости от пользователя
        /// </summary>
        /// <param name="accessList"></param>
        private void TextBoxClientAccess(Dictionary<string,bool> accessList)
        {
            TextBoxClientFirstName.IsReadOnly = accessList["FirstName"];
            TextBoxClientLastName.IsReadOnly = accessList["LastName"];
            TextBoxClientFatherName.IsReadOnly = accessList["FatherName"];
            TextBoxClientPhoneNumber.IsReadOnly = accessList["PhoneNumber"];
            TextBoxClientPassport.IsReadOnly = accessList["Passport"];
        }
        
        /// <summary>
        /// Загружаем список клиентов
        /// </summary>
        private void ClientsLoad()
        {
            ListBox_Clients.Items.Clear();

            clientBase.ReadClientBaseFile();
            int clientCount = clientBase.GetBaseSize();

            for (int i = 0; i < clientCount; i++)
            {
                ListBox_Clients.Items.Add(clientBase.GetClients()[i].GetFullName());
            }

        }
        /// <summary>
        /// Загружаем информацию конкретного клиента
        /// </summary>
        /// <param name="i"></param>
        private void ClientInfoLoad(int clientSelected)
        {
            Dictionary<string, string> client = user.showClientData(clientBase, clientSelected);
            TextBoxClientFirstName.Text = client["FirstName"];
            TextBoxClientLastName.Text = client["LastName"];
            TextBoxClientFatherName.Text = client["FatherName"];
            TextBoxClientPhoneNumber.Text = client["PhoneNumber"];
            TextBoxClientPassport.Text = client["Passport"];
        }

        private void ListBox_Clients_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int clientSelected = ListBox_Clients.SelectedIndex;
            ClientInfoLoad(clientSelected);
        }

        private void Button_SaveClientInfo_Click(object sender, RoutedEventArgs e)
        {
            int clientSelected = ListBox_Clients.SelectedIndex;
            UpdateClientInfo(clientSelected);
            Console.WriteLine("Client Save button clicked");
        }

        private void UpdateClientInfo(int clientSelected)
        {
            Client updatedClient = new Client(TextBoxClientFirstName.Text, TextBoxClientLastName.Text, TextBoxClientFatherName.Text,
                TextBoxClientPhoneNumber.Text,TextBoxClientPassport.Text);

            user.updateClientData(clientBase, updatedClient, clientSelected);
            Console.WriteLine("UpdateClientInfo initiated");
        }
    }
}
