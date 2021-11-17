using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WillyNet.JunCars.Core.Application.Features.Cars.Queries;

namespace WillyNet.JunCars.API.Controllers.v1
{   
    public class CarController : BaseApiController
    {
        [HttpGet("GetAllAsync")]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await Mediator.Send(new GetAllCarQuery()));
        }
    }
}
