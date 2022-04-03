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
    public class MongoDrawingStatusTypeData : IDrawingStatusTypeData
    {
        private readonly IMongoCollection<DrawingStatusTypeModel> _user;
        private readonly IMemoryCache _cache;
        private const string CacheName = "DrawingStatusData";

        public MongoDrawingStatusTypeData(IDbConnection db, IMemoryCache cache)
        {
            _cache = cache;
            _user = db.DrawingStatusTypeCollection;
        }

        public async Task<List<DrawingStatusTypeModel>> GetAllDrawingStatusTypes()
        {
            var output = _cache.Get<List<DrawingStatusTypeModel>>(CacheName);
            if (output is null)
            {
                var results = await _user.FindAsync(_ => true);
                output = results.ToList();

                _cache.Set(CacheName, output, TimeSpan.FromDays(1));
            }
            return output.ToList();
        }

        public async Task<DrawingStatusTypeModel> GetDrawingStatusType(string id)
        {
            var output = await GetAllDrawingStatusTypes();
            return output.Where(x => x.Id == id).FirstOrDefault();
        }
        public async Task<DrawingStatusTypeModel> GetDrawingStatusId(string text)
        {
            var output = await GetAllDrawingStatusTypes();
            return output.Where(x => x.Text == text).FirstOrDefault();
        }
        public Task CreateDrawingStatusType(DrawingStatusTypeModel drawingStatusType)
        {
            _cache.Remove(CacheName);
            return _user.InsertOneAsync(drawingStatusType);
        }
    }
}
