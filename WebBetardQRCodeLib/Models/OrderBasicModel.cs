using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebBetardQRCodeLib.Models
{
    public class OrderBasicModel
    {
        [MongoDB.Bson.Serialization.Attributes.BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        public string NumberBET { get; set; }

        public OrderBasicModel()
        {

        }

        public OrderBasicModel(OrderModel order)
        {
            Id = order.Id;
            NumberBET=order.NumberBET;

        }
    }
}
