using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework10._8
{
    internal class Consultant : IReadUser, IUpdateUser
    {
        public Consultant() { }
        
        public Dictionary<string,string> ShowClientData(ClientsRepository repository, int i)
        { 
            Dictionary<string, string> client = new Dictionary<string,string>();

            client.Add("FirstName", repository.GetClients()[i].FirstName);
            client.Add("LastName", repository.GetClients()[i].LastName);
            client.Add("FatherName", repository.GetClients()[i].FatherName);
            client.Add("PhoneNumber", repository.GetClients()[i].PhoneNumber);
            string passport = "";
            if (repository.GetClients()[i].Passport!=null&& repository.GetClients()[i].Passport.Trim()!="")
            {
                passport = "**** ******";
            }
            client.Add("Passport", passport);            

            return client;
        }

        public Dictionary<string, bool> GetClientDataEditAccess()
        {
            Dictionary<string, bool> access = new Dictionary<string, bool>
            {
                { "FirstName", false},
                { "LastName", false },
                { "FatherName", false },
                { "PhoneNumber", true },
                { "Passport", false }
            };
            return access;
        }

        public void UpdateClientData(ClientsRepository repository, Client updatedClient, int clientPosition)
        {
            // в промежуточную переменную записываем все поля из текущей базы
            // и перезаписываем только то поле, которое доступно консультанту для изменения
            Client updatedClientData = new Client(repository.GetClients()[clientPosition].FirstName,
                repository.GetClients()[clientPosition].LastName,
                repository.GetClients()[clientPosition].FatherName,
                updatedClient.PhoneNumber,
                repository.GetClients()[clientPosition].Passport);
                        
            repository.UpdateClientInfo(updatedClientData, clientPosition);
        }
    }
}
