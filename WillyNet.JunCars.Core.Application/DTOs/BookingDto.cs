using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WillyNet.JunCars.Core.Domain.Common;

namespace WillyNet.JunCars.Core.Application.DTOs
{
    public class BookingDto
    {
        [BsonRepresentation(BsonType.ObjectId)]
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
        [BsonRepresentation(BsonType.Document)]
        public UserDto User { get; set; }
        [BsonRepresentation(BsonType.Document)]
        public CarDto Car { get; set; }

    }
}
