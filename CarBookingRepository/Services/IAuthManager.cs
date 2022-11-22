using CarBookingData.DTOModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookingRepository.Services
{
    public interface IAuthManager
    {
        Task<bool> ValidateUser(LoginUserDTO UserDTO);
        Task<string> CreateToken();
    }
}
