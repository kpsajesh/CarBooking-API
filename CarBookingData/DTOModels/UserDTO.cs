using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookingData.DTOModels
{
    public class LoginUserDTO
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email{ get; set; }

        [Required]
        [StringLength(15, ErrorMessage ="Your password is limited to {2} to {1} characters.", MinimumLength =8)]
        public string Password{ get; set; }
    }
    public class UserDTO : LoginUserDTO
    {
        public string FirstName{ get; set; }
        public string SecondName { get; set; }


        /*[DataType(DataType.PhoneNumber)]
        public string PhoneNumber{ get; set; }        */

        public ICollection<string> Roles { get; set; }
    }
}
