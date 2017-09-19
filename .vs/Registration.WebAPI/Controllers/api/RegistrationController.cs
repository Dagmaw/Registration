using Registration.WebAPI.Interface;
using Registration.WebAPI.Models;
using Registration.WebAPI.Repositories;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Registration.WebAPI.Controllers
{
    public class RegistrationController : ApiController
    {
        static readonly IRegistrationRepository repository = new RegistrationRepository();
        public IEnumerable GetAllRegistrants()
        {
            return repository.GetAll();
        }

        public csvAttributes GetFromCSV()
        {
            return repository.GetCSV();
        }
        public tblRegistrationRequest PostRegistrant(tblRegistrationRequest item)
        {
            return repository.Add(item);
        }
        public IEnumerable PutRegistrant(int id, tblRegistrationRequest registrant)
        {
            registrant.RegistrationId = id;
            if(repository.Update(registrant))
            {
                return repository.GetAll();
            }
            else
            {
                return null;
            }
        }
        public bool DeleteRegistrant(int id)
        {
            if(repository.Delete(id))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
