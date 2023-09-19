using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework10._8
{
    internal class Consultant
    {
        public Consultant() { }
        /// <summary>
        /// Получение записи одного клиента
        /// </summary>
        /// <param name="repository">ссылка на базу клиентов</param>
        /// <param name="i">порядковый номер клиента в базе</param>
        /// <returns></returns>
        public Dictionary<string,string> showClientData(ClientsRepository repository, int i)
        { 
            Dictionary<string, string> client = new Dictionary<string,string>();

            client.Add("FirstName", repository.GetClients()[i].FirstName);
            client.Add("LastName", repository.GetClients()[i].LastName);
            client.Add("FatherName", repository.GetClients()[i].FatherName);
            client.Add("PhoneNumber", repository.GetClients()[i].PhoneNumber);
            string passport = "Нет данных паспорта";
            if (repository.GetClients()[i].Passport!=null)
            {
                passport = "**** ******";
            }
            client.Add("Passport", passport);            

            return client;
        }

        /// <summary>
        /// список полей, доступных для редактирования
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, bool> GetClientDataEditAccess()
        {
            Dictionary<string, bool> access = new Dictionary<string, bool>();

            access.Add("FirstName", true);
            access.Add("LastName", true);
            access.Add("FatherName", true);
            access.Add("PhoneNumber", false);
            access.Add("Passport", true);

            return access;
        }

        public void updateClientData(ClientsRepository repository, Client updatedClient, int clientPosition)
        {
            Client updatedClientData = repository.GetClients()[clientPosition]; // в промежуточную переменную записываем все поля из текущей базы
            updatedClientData.SetPhoneNumber(updatedClient.PhoneNumber); // и перезаписываем только то поле, которое доступно консультанту для изменения

            repository.UpdateClientInfo(updatedClientData, clientPosition);

            Console.WriteLine("updated client sent to repository");
        }
    }
}
