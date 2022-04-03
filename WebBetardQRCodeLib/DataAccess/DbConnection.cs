using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebBetardQRCodeLib.Models;
using Microsoft.Extensions.Configuration;

namespace WebBetardQRCodeLib.DataAccess
{
    public class DbConnection : IDbConnection
    {
        private readonly IConfiguration _config;
        private readonly IMongoDatabase _db;
        private string _connectionId = "MongoDB";
        public string DbName { get; private set; }
        public string CommentCollectionName { get; private set; } = "comments";
        public string DrawingCollectionName { get; private set; } = "drawings";
        public string DrawingRevisionCollectionName { get; private set; } = "drawingRevisions";
        public string DrawingStatusCollectionName { get; private set; } = "drawingStatuses";
        public string DrawingStatusTypeCollectionName { get; private set; } = "drawingStatusTypes";
        public string QrReadLogCollectionName { get; private set; } = "qrReadLogs";
        public string OrderCollectionName { get; private set; } = "orders";
        public string UserLogCollectionName { get; private set; } = "userLogs";
        public string UserCollectionName { get; private set; } = "users";


        public MongoClient Client { get; private set; }
        public IMongoCollection<CommentModel> CommentCollection { get; private set; }
        public IMongoCollection<DrawingModel> DrawingCollection { get; private set; }
        public IMongoCollection<DrawingRevisionModel> DrawingRevisionCollection { get; private set; }
        public IMongoCollection<DrawingStatusModel> DrawingStatusCollection { get; private set; }
        public IMongoCollection<DrawingStatusTypeModel> DrawingStatusTypeCollection { get; private set; }
        public IMongoCollection<OrderModel> OrderCollection { get; private set; }
        public IMongoCollection<UserLogModel> UserLogCollection { get; private set; }
        public IMongoCollection<UserModel> UserCollection { get; private set; }

        public DbConnection(IConfiguration config)
        {
            _config = config;
            Client = new MongoClient(_config.GetConnectionString(_connectionId));
            DbName = _config["DatabaseName"];
            _db = Client.GetDatabase(DbName);

            CommentCollection = _db.GetCollection<CommentModel>(CommentCollectionName);
            DrawingCollection = _db.GetCollection<DrawingModel>(DrawingCollectionName);
            DrawingRevisionCollection = _db.GetCollection<DrawingRevisionModel>(DrawingRevisionCollectionName);
            DrawingStatusCollection = _db.GetCollection<DrawingStatusModel>(DrawingStatusCollectionName);
            DrawingStatusTypeCollection = _db.GetCollection<DrawingStatusTypeModel>(DrawingStatusTypeCollectionName);
            OrderCollection = _db.GetCollection<OrderModel>(OrderCollectionName);
            UserLogCollection = _db.GetCollection<UserLogModel>(UserLogCollectionName);
            UserCollection = _db.GetCollection<UserModel>(UserCollectionName);

        }
    }
}
