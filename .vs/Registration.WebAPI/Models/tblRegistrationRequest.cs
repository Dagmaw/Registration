//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Registration.WebAPI.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblRegistrationRequest
    {
        public long RegistrationId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string Organization { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public string Password { get; set; }
        public string GroupName { get; set; }
    }
}
