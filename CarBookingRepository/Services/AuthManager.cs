using CarBookingData.DataModels;
using CarBookingData.DTOModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CarBookingRepository.Services
{
    public class AuthManager:IAuthManager
    {
        private readonly UserManager<ApiUser> _userManager;
        private readonly IConfiguration _configuration;
        private ApiUser _user;

        public AuthManager(UserManager<ApiUser> userManager, IConfiguration configuration)
        {
            _userManager=userManager;
            _configuration=configuration;
        }
        
        public async Task<bool> ValidateUser(LoginUserDTO UserDTO )
        {
            _user = await _userManager.FindByEmailAsync(UserDTO.Email);//checks the user is valid as passing the user id as email id
            return (_user != null && await _userManager.CheckPasswordAsync(_user, UserDTO.Password)); // checks the password is right for the user
        }
        
        public async Task<string> CreateToken()
        {
            var signingCredentials = GetSigningCredentials();
            var claims = await GetClaims();
            var tokenOptions = GenerateTOkenOptions(signingCredentials, claims);

            return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        }

        private SigningCredentials GetSigningCredentials()
        {
            string strKey;
            var key = Environment.GetEnvironmentVariable("CarAPIKey");
            // Not able to pick from environment variable. Environment variable is registered via cmd admin lin using the commend
            // setx CarAPIKey "f09ed3fb-4e12-42aa-b097-459d06af1b56" /M
            // The key is present in Regedit> Computer\HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\Session Manager\Environment

            var key1 = "f09ed3fb - 4e12 - 42aa - b097 - 459d06af1b56";


            /*IDictionary data = Environment.GetEnvironmentVariables();

            // Display the details with key and value
            foreach (DictionaryEntry i in data)
            {
                Console.WriteLine("{0}:{1}", i.Key, i.Value);
                if(i.Value== "f09ed3fb - 4e12 - 42aa - b097 - 459d06af1b56")
                {
                    strKey = Convert.ToString(i.Value);
                }
            }*/

            var secret = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key1));

            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }

        private async Task<List<Claim>> GetClaims()
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name,_user.UserName)
            };
            var roles = await _userManager.GetRolesAsync(_user);
            foreach (var role in roles)
            {
                claims.Add(new Claim (ClaimTypes.Role, role));
            }
            return claims;
        }

        private JwtSecurityToken GenerateTOkenOptions(SigningCredentials signingCredentials, List<Claim> claims)
        {
            var jwtSettings = _configuration.GetSection("Jwt");
            var duration = jwtSettings.GetSection("lifetime").Value;
            var expiration = DateTime.Now.AddMinutes(Convert.ToDouble(duration));

            var token = new JwtSecurityToken(
                issuer: jwtSettings.GetSection("Issuer").Value,
                expires: expiration,
                claims: claims,
                signingCredentials: signingCredentials
                );

            return token;
        }
    }
}
