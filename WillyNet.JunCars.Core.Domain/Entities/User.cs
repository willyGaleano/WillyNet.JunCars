using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WillyNet.JunCars.Core.Domain.Common;

namespace WillyNet.JunCars.Core.Domain.Entities
{
    public class User : IEntity
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
