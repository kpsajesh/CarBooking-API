using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookingData.DataModels
{
    public class ApiUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string SecondName{ get; set; }
    }
}
