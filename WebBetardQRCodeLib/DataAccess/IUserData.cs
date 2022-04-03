using System.Collections.Generic;
using System.Threading.Tasks;
using WebBetardQRCodeLib.Models;

namespace WebBetardQRCodeLib.DataAccess
{
    public interface IUserData
    {
        Task CreateUser(UserModel user);
        Task<List<UserModel>> GetAllUsers();
        Task<UserModel> GetUser(string id);
        Task<UserModel> GetUser(string id, string pass = "");
        Task<UserModel> GetUserFromAuthentication(string objectId);
        Task<UserModel> GetUserFromPass(string id);
        Task<List<UserLogModel>> GetUserLogs(string id);
        Task UpdateUserAsync(UserModel user);
    }
}