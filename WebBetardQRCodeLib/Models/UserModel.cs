
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebBetardQRCodeLib.Models
{
    public class UserModel
    {
        [MongoDB.Bson.Serialization.Attributes.BsonId]
        [MongoDB.Bson.Serialization.Attributes.BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        public string ObjectIdentifier { get; set; }
        public string Mail { get; set; }
        public string Phone { get; set; }
        public string Company { get; set; }
        public string LastAuthCode { get; set; }
        public string Function { get; set; }
        public string AuthorizePass { get; set; }
        public List<UserLogModel> UserLogs { get; set; } = new();
        public DateTime Data { get; set; } = DateTime.UtcNow;

    }
}
