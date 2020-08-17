using System.Security.Cryptography;
using System.Threading.Tasks;
using CoreServices.AuthenticationServices.Dtos;
using CoreServices.AuthenticationServices.Interface;
using Microsoft.AspNetCore.Identity;
using Models;
using Models.Entities;

namespace CoreServices.AuthenticationServices
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly UserManager<User> _userManager;
        private static RNGCryptoServiceProvider rngCsp = new RNGCryptoServiceProvider();


        public AuthenticationService(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<User> Register(RegistrationDto userToRegister)
        {
            var passwordHash = HashPassword(userToRegister.Password);

            var user = new User
            {
                UserName = userToRegister.UserName,
                Email = userToRegister.EmailAddress,

                
            };
            
            var result = await _userManager.CreateAsync(user, passwordHash);

            if (result.Succeeded)
            {

            }

            return await _userManager.FindByNameAsync(userToRegister.UserName);

        }

        public User Login(LoginDto username, string password)
        {

        }


        private string HashPassword(string password)
        {

        }
    }
}
