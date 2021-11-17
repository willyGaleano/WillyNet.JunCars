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
    public class CarDto
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        [BsonRepresentation(BsonType.Int64)]
        public int Capacity { get; set; }
        public string FuelType { get; set; }
        [BsonRepresentation(BsonType.Int64)]
        public int RentPerHour { get; set; }
        [BsonExtraElements]
        public Dictionary<string, object> BookedTimeSlots { get; set; }
    }
}
