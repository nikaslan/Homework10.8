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

        private string firstName;
        private string lastName;
        private string fatherName;
        private string phoneNumber;
        private string passport;

        public string FirstName 
        { 
            get { return firstName; }
            private set { this.firstName = value; } 
        }
        public string LastName 
        {
            get { return lastName; }
            private set { this.lastName = value; }
        }
        public string FatherName 
        {
            get { return fatherName; }
            private set { this.fatherName = value; } 
        }
        public string PhoneNumber
        {
            get { return phoneNumber; }
            private set { this.phoneNumber = value; }
        }
        public string Passport
        {
            get { return passport; }
            private set { this.passport = value; }
        }

        public Client(string firstName, string lastName, string fatherName, string phoneNumber, string passport)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.FatherName = fatherName;
            this.PhoneNumber = phoneNumber;
            this.Passport = passport;
        }

        #region Методы получение параметров клиента

        /// <summary>
        /// Получение полного имени пользователя
        /// </summary>
        /// <returns></returns>
        public string GetFullName()
        {
            string fullName = $"{this.LastName} {this.FirstName} {this.FatherName}";
            return fullName;
        }        

        #endregion

        #region Методы задания параметров
        public void SetPhoneNumber(string phoneNumber)
        {
            this.phoneNumber = phoneNumber;
        }


        #endregion
    }
}
