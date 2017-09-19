using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Registration.WebAPI.Models
{
    //paste Json as classes

    public class OktaAttributes
    {
        public Attributes[] aattributes { get; set; }
    }

    public class Attributes
    {
        public string id { get; set; }
        public string status { get; set; }
        public DateTime created { get; set; }
        public DateTime? activated { get; set; }
        public DateTime? statusChanged { get; set; }
        public DateTime? lastLogin { get; set; }
        public DateTime lastUpdated { get; set; }
        public DateTime? passwordChanged { get; set; }
        public Profile profile { get; set; }
        public Credentials credentials { get; set; }
        public _Links _links { get; set; }
    }

    public class Profile
    {
        public string lastName { get; set; }
        public string secondEmail { get; set; }
        public string mobilePhone { get; set; }
        public string email { get; set; }
        public string login { get; set; }
        public string firstName { get; set; }
        public string primaryPhone { get; set; }
        public string deliveryOffice { get; set; }
        public string role { get; set; }
        public string organization { get; set; }
        public string streetAddress { get; set; }
        public string zipCode { get; set; }
        public string countryCode { get; set; }
        public string state { get; set; }
        public string city { get; set; }
    }

    public class Credentials
    {
        public Provider provider { get; set; }
        public Password password { get; set; }
        public Recovery_Question recovery_question { get; set; }
    }

    public class Provider
    {
        public string type { get; set; }
        public string name { get; set; }
    }

    public class Password
    {
    }

    public class Recovery_Question
    {
        public string question { get; set; }
    }

    public class _Links
    {
        public Self self { get; set; }
    }

    public class Self
    {
        public string href { get; set; }
    }

}