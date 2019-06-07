using System.Threading.Tasks;

namespace SampleApp.Core.Services.Abstract
{
    public interface ILoginService
    {
        Task<bool> Login(string username, string password);
    }
}