using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Newtonsoft.Json;


namespace Homework10._8
{
    internal class ClientsRepository
    {
        public ClientsRepository() { }

        public List<Client> clients = new List<Client>();

        private string databasePath = "clientsList.json"; // путь до JSON файла с клиентами
             

        public void readClientBase()
        {
            string fileText = File.ReadAllText(this.databasePath);
            this.clients = JsonConvert.DeserializeObject<List<Client>>(fileText);
        }

        public string printClientBase()
        {
            string clientsTable = "";
            foreach (var client in this.clients)
            {
                clientsTable += client.ToString();
                clientsTable += "\n";
            }
            return clientsTable;
        }
        
        //public void updateClientBase()
        //{
        //    Stream fStream = new FileStream(this.databasePath, FileMode.Create, FileAccess.Write);

        //    newContact.Save(fStream);

        //    fStream.Close();
        //}
        // нужен разбор файла в коллекцию элементов типа client 
        // нужен метод записи изменений обратно в файл. Думаю при любом изменении, надо перезаписывать их в файл из текущей коллекции

        // нужно реализовать многопоточность. Смотрим примеры работ в модуле 8 и модуле 7.

        // сначала все реализуем, потом попробуем сделать с потоками

    }
}
