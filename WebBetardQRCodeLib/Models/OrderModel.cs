
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebBetardQRCodeLib.Models
{
    public class OrderModel
    {
        [MongoDB.Bson.Serialization.Attributes.BsonId]
        [MongoDB.Bson.Serialization.Attributes.BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        public string NumberBET { get; set; }
        public string Name { get; set; }
        public List<DrawingModel> Drawings { get; set; } = new();
        public DateTime Data { get; set; } = DateTime.UtcNow;
    }
}
