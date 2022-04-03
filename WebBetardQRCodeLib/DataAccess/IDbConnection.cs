using MongoDB.Driver;
using WebBetardQRCodeLib.Models;

namespace WebBetardQRCodeLib.DataAccess
{
    public interface IDbConnection
    {
        MongoClient Client { get; }
        IMongoCollection<CommentModel> CommentCollection { get; }
        string CommentCollectionName { get; }
        string DbName { get; }
        IMongoCollection<DrawingModel> DrawingCollection { get; }
        string DrawingCollectionName { get; }
        IMongoCollection<DrawingRevisionModel> DrawingRevisionCollection { get; }
        string DrawingRevisionCollectionName { get; }
        IMongoCollection<DrawingStatusModel> DrawingStatusCollection { get; }
        string DrawingStatusCollectionName { get; }
        IMongoCollection<DrawingStatusTypeModel> DrawingStatusTypeCollection { get; }
        string DrawingStatusTypeCollectionName { get; }
        string QrReadLogCollectionName { get; }
        IMongoCollection<OrderModel> OrderCollection { get; }
        string OrderCollectionName { get; }
        IMongoCollection<UserModel> UserCollection { get; }
        string UserCollectionName { get; }
        IMongoCollection<UserLogModel> UserLogCollection { get; }
        string UserLogCollectionName { get; }
    }
}