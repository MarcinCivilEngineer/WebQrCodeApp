using Microsoft.Extensions.Caching.Memory;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebBetardQRCodeLib.Models;

namespace WebBetardQRCodeLib.DataAccess
{
    public class MongoUserData : IUserData
    {



        private readonly IMongoCollection<UserModel> _user;
        private readonly IMemoryCache _cache;
        private const string CacheName = "UserData";

        public MongoUserData(IDbConnection db, IMemoryCache cache)
        {
            _cache = cache;
            _user = db.UserCollection;
        }

        public async Task<List<UserModel>> GetAllUsers()
        {
            var output = _cache.Get<List<UserModel>>(CacheName);
            if (output is null)
            {
                var results = await _user.FindAsync(_ => true);
                output = results.ToList();

                _cache.Set(CacheName, output, TimeSpan.FromDays(1));
            }
            return output.ToList();
        }

        public async Task<UserModel> GetUser(string id, string pass = "")
        {
            UserModel results;
            if (pass != "")
            {
                results = (await _user.FindAsync(u => u.AuthorizePass == pass)).FirstOrDefault();
            }
            else
            {
                results = (await _user.FindAsync(u => u.Id == id)).FirstOrDefault();
            }

            return results;
        }
        public async Task<UserModel> GetUser(string id)
        {

            var results = (await _user.FindAsync(u => u.Id == id));


            return results.FirstOrDefault();
        }
        public async Task<UserModel> GetUserFromPass(string id)
        {

            var results = (await _user.FindAsync(u => u.AuthorizePass == id));


            return results.FirstOrDefault();
        }

        public async Task<List<UserLogModel>> GetUserLogs(string id)
        {
            var results = await _user.FindAsync(u => u.Id == id);
            return results.FirstOrDefault().UserLogs.ToList();
        }

        public async Task<UserModel> GetUserFromAuthentication(string objectId)
        {
            var results = await _user.FindAsync(u => u.ObjectIdentifier == objectId);
            return results.FirstOrDefault();
        }

        public Task CreateUser(UserModel user)
        {
            _cache.Remove(CacheName);
            return _user.InsertOneAsync(user);
        }

        public async Task UpdateUserAsync(UserModel user)
        {
            var results = await _user.ReplaceOneAsync(c => c.Id == user.Id, user);
            _cache.Remove(CacheName);
        }
    }


}
