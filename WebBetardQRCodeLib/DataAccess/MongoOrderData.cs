using Microsoft.Extensions.Caching.Memory;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebBetardQRCodeLib.Models;

namespace WebBetardQRCodeLib.DataAccess
{
    public class MongoOrderData : IOrderData
    {
        private readonly IMongoCollection<OrderModel> _order;
        private readonly IDbConnection _db;
        private readonly IMemoryCache _cache;
        private const string CacheName = "OrderData";



        public MongoOrderData(IDbConnection db, IMemoryCache cache)
        {
            _db = db;
            _cache = cache;
            _order = db.OrderCollection;
        }

        public async Task<List<OrderModel>> GetAllOrdersAsync()
        {
            var output = _cache.Get<List<OrderModel>>(CacheName);
            if (output is null)
            {
                var results = await _order.FindAsync(_ => true);
                output = results.ToList();
                _cache.Set(CacheName, output, TimeSpan.FromMinutes(10));
            }
            return output.ToList();
        }

        public async Task RemoveOrder(string orderId)
        {
            var deleteFilter = Builders<OrderModel>.Filter.Eq("Id", orderId);
            var results = await _order.DeleteOneAsync(deleteFilter);
            _cache.Remove(CacheName);
        }
        public async Task<OrderModel> GetOrdersAsync(string id)
        {
            var output = (await GetAllOrdersAsync()).Where(x => x.Id == id);

            if (output is null)
            {
                var results = await _order.FindAsync(c => c.Id == id);
                output = results.ToList();
                _cache.Set(CacheName, output, TimeSpan.FromMinutes(1));
            }
            return output.FirstOrDefault();
        }

        public async Task<List<DrawingModel>> GetOrderDrawingsAsync(string id)
        {
            var output = (await GetAllOrdersAsync()).Where(x => x.Id == id);

            if (output is null)
            {
                var results = await _order.FindAsync(c => c.Id == id);
                output = results.ToList();
                _cache.Set(CacheName, output, TimeSpan.FromMinutes(1));
            }
            return output.FirstOrDefault().Drawings.ToList();
        }

        public async Task CreateOrderAsync(OrderModel order)
        {
            var client = _db.Client;
            using var session = await client.StartSessionAsync();
            session.StartTransaction();

            try
            {
                var db = client.GetDatabase(_db.DbName);
                var commentInTransaction = db.GetCollection<OrderModel>(_db.OrderCollectionName);
                await commentInTransaction.InsertOneAsync(order);

                await session.CommitTransactionAsync();
            }
            catch (Exception ex)
            {
                await session.AbortTransactionAsync();
                throw;
            }
            _cache.Remove(CacheName);
        }

        public async Task UpdateOrderAsync(OrderModel order)
        {
            var client = _db.Client;
            using var session = await client.StartSessionAsync();
            session.StartTransaction();

            try
            {
                var db = client.GetDatabase(_db.DbName);
                var taskInTransaction = db.GetCollection<OrderModel>(_db.OrderCollectionName);
                await taskInTransaction.ReplaceOneAsync(c => c.Id == order.Id, order);

                await session.CommitTransactionAsync();
            }
            catch (Exception ex)
            {
                await session.AbortTransactionAsync();
                throw;
            }
            _cache.Remove(CacheName);
        }
    }
}
