using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework10._8
{
    internal class Manager : IReadUser, IUpdateUser
    {
        public Manager() { }
                
        public Dictionary<string, bool> GetClientDataEditAccess()
        {
            Dictionary<string, bool> access = new Dictionary<string, bool>
            {
                { "FirstName", true },
                { "LastName", true },
                { "FatherName", true },
                { "PhoneNumber", true },
                { "Passport", true }
            };
            return access;
        }

        public Dictionary<string, string> ShowClientData(ClientsRepository repository, int i)
        {
            Dictionary<string, string> client = new Dictionary<string, string>();

            client.Add("FirstName", repository.GetClients()[i].FirstName);
            client.Add("LastName", repository.GetClients()[i].LastName);
            client.Add("FatherName", repository.GetClients()[i].FatherName);
            client.Add("PhoneNumber", repository.GetClients()[i].PhoneNumber);
            string passport = "";
            if (repository.GetClients()[i].Passport != null && repository.GetClients()[i].Passport.Trim() != "")
            {
                passport = repository.GetClients()[i].Passport;
            }
            client.Add("Passport", passport);
            return client;
        }

        public void UpdateClientData(ClientsRepository repository, Client updatedClient, int clientPosition)
        {
            repository.UpdateClientInfo(updatedClient, clientPosition);
        }
    }
}
