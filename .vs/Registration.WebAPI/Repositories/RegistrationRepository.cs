using Registration.WebAPI.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Registration.WebAPI.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.IO;
using Newtonsoft.Json.Linq;

namespace Registration.WebAPI.Repositories
{
    public class RegistrationRepository : IRegistrationRepository
    {
        SSORegistratonDbContext SSORegistrationDB = new SSORegistratonDbContext();
        public tblRegistrationRequest Add(tblRegistrationRequest item)
        {
            if (item == null)
            {
                throw new ArgumentNullException();
            }
            SSORegistrationDB.tblRegistrationRequests.Add(item);
            SSORegistrationDB.SaveChanges();
            return item;
        }

        public bool Delete(int id)
        {
            tblRegistrationRequest registrationRequest = SSORegistrationDB.tblRegistrationRequests.Find(id);
            SSORegistrationDB.tblRegistrationRequests.Remove(registrationRequest);
            SSORegistrationDB.SaveChanges();
            return true;
        }

        public IEnumerable<tblRegistrationRequest> GetAll()
        {
            GetOktaUsers();
            return SSORegistrationDB.tblRegistrationRequests;
        }

        public csvAttributes GetCSV()
        {
            string csv_file_path = @"C:\git\OktaDemo\PBS.UserManagement\PBS.UserManagement\PBSUserManagementAPI\07142017.csv";
            csvAttributes csvAttrib = new csvAttributes();
            List<csvAttributes> ls = new List<csvAttributes>();

            var csvlines = File.ReadAllLines(csv_file_path);   // IEnumerable<string>

            //skip the first line!
            var csvLinesData = csvlines.Skip(1).Select(l => l.Split(',').ToArray());  // IEnumerable<string[]>

            foreach (var row in csvLinesData)
            {
                csvAttrib.Email = row[0];
                csvAttrib.Login = row[1];
                csvAttrib.FirstName = row[2];
                csvAttrib.LastName = row[3];
                csvAttrib.Organization = row[4];
                csvAttrib.Question = row[5];
                csvAttrib.Answer = row[6];
                csvAttrib.Password = row[7];
                csvAttrib.GroupName = row[8];
                ls.Add(csvAttrib);
            }
            return csvAttrib;
        }

        public tblRegistrationRequest Get(int id)
        {
            GetOktaUser(id);
            return SSORegistrationDB.tblRegistrationRequests.Find(id);
        }

        public bool Update(tblRegistrationRequest item)
        {
            if(item == null)
            {
                throw new ArgumentNullException("item");
            }

            var registrationRequest = SSORegistrationDB.tblRegistrationRequests.Single(a => a.RegistrationId == item.RegistrationId);
            registrationRequest.FirstName = item.FirstName;
            registrationRequest.LastName = item.LastName;
            registrationRequest.Email = item.Email;
            registrationRequest.Login = item.Login;
            registrationRequest.Organization = item.Organization;
            registrationRequest.Question = item.Question;
            registrationRequest.Answer = item.Answer;
            registrationRequest.Password = item.Password;
            registrationRequest.GroupName = item.GroupName;
            SSORegistrationDB.SaveChanges();



            return true;
        }

        public Profile GetOktaUsers()
        {
            const string url = "replace with actual value";

            OktaAttributes[] oAttributes = new OktaAttributes[2];
            Attributes attributes2 = new Attributes();
            List<Profile> attributes = new List<Profile>();
            Profile prfle = new Profile();

            using (var client = new HttpClient())
            {
                var apitoken = "replace with actual value";
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("SSWS", apitoken);
                HttpResponseMessage response = client.GetAsync(url).Result;
                var data = response.Content.ReadAsStringAsync().Result;
                dynamic oktaUserD = JArray.Parse(data);
                JArray oktaUser = JArray.Parse(data);
                for (int i = 0; i < oktaUser.Count; i++)
                {
                    attributes2.id = oktaUser[i]["id"].ToString();
                    prfle.firstName = oktaUser[i]["profile"]["firstName"].ToString();
                    prfle.lastName = oktaUser[i]["profile"]["lastName"].ToString();
                    prfle.email = oktaUser[i]["profile"]["email"].ToString();
                    prfle.login = oktaUser[i]["profile"]["login"].ToString();
                    attributes.Add(prfle);
                }
            }
            return prfle;
        }

        public Profile GetOktaUser(long userId)
        {
            const string url = "Replace with actual value";

            OktaAttributes[] oAttributes = new OktaAttributes[2];
            Attributes attributes2 = new Attributes();
            List<Profile> attributes = new List<Profile>();
            Profile prfle = new Profile();

            if (userId > 0)
            {
                using (var client = new HttpClient())
                {
                    var apitoken = "Replace with actual value";
                    client.BaseAddress = new Uri(url);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("SSWS", apitoken);
                    HttpResponseMessage response = client.GetAsync(url).Result;
                    var data = response.Content.ReadAsStringAsync().Result;
                    JArray oktaUser = JArray.Parse(data);

                    foreach (JObject item in oktaUser)
                    {

                        attributes2.id = item["id"].ToString();
                        prfle.firstName = item["profile"]["firstName"].ToString();
                        prfle.lastName = item["profile"]["lastName"].ToString();
                        prfle.email = item["profile"]["email"].ToString();
                        prfle.login = item["profile"]["login"].ToString();
                        attributes.Add(prfle);
                    }

                }

            }
            else
            {
                Console.WriteLine("The user already exit");
            }
            return prfle;
        }

        

    }
}