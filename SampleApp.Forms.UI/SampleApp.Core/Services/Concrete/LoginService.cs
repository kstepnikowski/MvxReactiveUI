using System.Collections.Generic;
using System.Threading.Tasks;
using SampleApp.Core.Services.Abstract;

namespace SampleApp.Core.Services.Concrete
{
    public class LoginService : ILoginService
    {
        private readonly Dictionary<string, string> _userCredentials;

        public LoginService()
        {
            _userCredentials = new Dictionary<string, string>()
            {
                {"aa@aa.aa","test123" },
            };
        }
        public async Task<bool> Login(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                return false;
            }

            return _userCredentials.ContainsKey(username) && _userCredentials[username] == password;
        }
    }
}
