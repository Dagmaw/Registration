using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Registration.WebAPI.Models
{
    public class csvAttributes
    {
        private string _email;
        private string _Login;
        private string _firstName;
        private string _lastName;
        private string _organization;
        private string _question;
        private string _answer;
        private string _password;
        private string _groupName;

        public string Email
        {
            get { return this._email; }
            set { this._email = value; }
        }
        public string Login
        {
            get { return this._Login; }
            set { this._Login = value; }
        }
        public string FirstName
        {
            get { return this._firstName; }
            set { this._firstName = value; }
        }
        public string LastName
        {
            get { return this._lastName; }
            set { this._lastName = value; }
        }
        public string Organization
        {
            get { return this._organization; }
            set { this._organization = value; }
        }
        public string Question
        {
            get { return this._question; }
            set { this._question = value; }
        }
        public string Answer
        {
            get { return this._answer; }
            set { this._answer = value; }
        }
        public string Password
        {
            get { return this._password; }
            set { this._password = value; }
        }
        public string GroupName
        {
            get { return this._groupName; }
            set { this._groupName = value; }
        }
    }
}