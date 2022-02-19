using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartCookers_WebAPI.Data.Interfaces;
using SmartCookers_WebAPI.Dtos.Outlet;

namespace SmartCookers_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OutletController : ControllerBase
    {
        private  readonly IOutletRepo _repo;

        public OutletController(IOutletRepo repo)
        {
            _repo=   repo;
        }


        [HttpPost]
        [Route("AddOutlet")]
        public async Task<ActionResult> AddOutlet(OutletCreateDto outletCreateDto)
        {

            return Ok(_repo.CreateOutlet(outletCreateDto));
        }
    }
}
