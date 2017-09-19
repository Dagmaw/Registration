using Registration.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Registration.WebAPI.Interface
{
    interface IRegistrationRepository
    {
        IEnumerable<tblRegistrationRequest> GetAll();
        csvAttributes GetCSV();
        tblRegistrationRequest Get(int id);
        tblRegistrationRequest Add(tblRegistrationRequest item);       
        bool Update(tblRegistrationRequest item);
        bool Delete(int id);

    }
}