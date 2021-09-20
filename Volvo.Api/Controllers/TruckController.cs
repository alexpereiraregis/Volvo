using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volvo.Application.Interfaces;
using Volvo.Application.Request;
using Volvo.Application.Response;

namespace Volvo.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TruckController : ControllerBase
    {
        private readonly ITruckService _truckService;

        public TruckController(ITruckService truckService)
        {
            _truckService = truckService;
        }

        [HttpGet("GetList")]        
        public async Task<IEnumerable<TruckResponse>> GetListTruck()
        {
            var result = await _truckService.GetListTruck();
            return result;
        }

        [HttpGet("{id}/Get")]        
        public TruckResponse GetTruck(int id)
        {
            var result = _truckService.GetTruck(id);
            return result;
        }

        [HttpPost("Add")]        
        public IActionResult AddTruck(AddTruckRequest addTruckRequest)
        {
            var truckRequest = new TruckRequest()
            {
                Model = addTruckRequest.Model,
                YearManufacture = addTruckRequest.YearManufacture,
                ModelYear = addTruckRequest.ModelYear
            };

            _truckService.AddTruck(truckRequest);
            return Ok();
        }

        [HttpPut("Update")]        
        public IActionResult UpdateTruck(TruckRequest truckRequest)
        {
            _truckService.Update(truckRequest);
            return Ok();

        }

        [HttpDelete("{id}/Delete")]        
        public IActionResult DeleteTruck(int id)
        {
            _truckService.Remove(id);
            return Ok();
        }

    }
}
