using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WillyNet.JunCars.Core.Domain.Common;

namespace WillyNet.JunCars.Core.Domain.Entities
{
    public class Booking : IEntity
    {
        public string Id { get; set; }
        [BsonExtraElements]
        public BsonDocument BookedTimeSlots { get; set; }

        [BsonRepresentation(BsonType.Int64)]
        public int TotalHours { get; set; }

        [BsonRepresentation(BsonType.Int64)]
        public int TotalAmount { get; set; }
        public string TransactionId { get; set; }

        [BsonRepresentation(BsonType.Boolean)]
        public bool DriverRequired { get; set; }

        [BsonIgnore]
        public User User { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string UserId { get; set; }

        [BsonIgnore]
        public Car Car { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string CarId { get; set; }        
    }
}
