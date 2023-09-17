using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;

namespace Homework10._8
{
    internal class Client
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FatherName { get; set; }
        public string PhoneNumber { get; set; }
        public string Passport { get; set; }

        public Client(string FirstName, string LastName, string FatherName, string PhoneNumber, string Passport)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.FatherName = FatherName;
            this.PhoneNumber = PhoneNumber;
            this.Passport = Passport;
        }
        //public Client() { }

        /// <summary>
        /// Получение полного имени пользователя
        /// </summary>
        /// <returns></returns>
        public string getFullName()
        {
            string fullName = $"{this.LastName} {this.FirstName} {this.FatherName}";
            return fullName;
        }

        /// <summary>
        /// Получение номера паспорта
        /// </summary>
        /// <returns></returns>
        public string getPassport()
        {
            string passport = "";
            if (Passport != null) { passport = "************"; }
            else passport = "Нет паспортных данных";
            return passport;
        }

        /// <summary>
        /// Смена номера телефона клиента
        /// </summary>
        /// <param name="phoneNumber"></param>
        public void setPhoneNumber(string phoneNumber)
        {
            this.PhoneNumber = phoneNumber;
        }

        public override string ToString()
        {
            string clientEntry = $"{this.getFullName()} {PhoneNumber} {this.getPassport()}";
            return clientEntry;
        }
    }
}
