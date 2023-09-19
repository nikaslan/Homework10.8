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
        private string databasePath;
        private List<Client> clients;

        //// для теста записи

        //private string updatedDatabasePath = "updatedClientsList.json";


        public ClientsRepository()
        {
            this.databasePath = "clientsList.json"; // путь до JSON файла с клиентами
                     
        }
        public ClientsRepository(string databasePath)
        {
            this.databasePath = databasePath;
        }
        
        /// <summary>
        /// Считываем список клиентов из файла базы
        /// </summary>
        public void ReadClientBaseFile()
        {
            string fileText = File.ReadAllText(this.databasePath);
            this.clients = JsonConvert.DeserializeObject<List<Client>>(fileText);
        }

        public int GetBaseSize() { return this.clients.Count; } // возвращает количество записей в базе клиентов

        public List<Client> GetClients() { return this.clients;} // возвращает список клиентов

        /// <summary>
        /// Записываем изменения в информации клиента 
        /// </summary>
        /// <param name="updatedClientInfo"></param>
        /// <param name="clientPosition"></param>
        public void UpdateClientInfo(Client updatedClientInfo, int clientPosition)
        {
            clients[clientPosition] = updatedClientInfo;
            UpdateClientBaseFile();
        }

        /// <summary>
        /// Записываем текущий список клиентов в файл
        /// </summary>
        private void UpdateClientBaseFile()
        {
            string fileText = JsonConvert.SerializeObject(this.clients);
            File.WriteAllText(this.databasePath, fileText);
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
