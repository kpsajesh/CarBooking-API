using CarBookingData.DataModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CarBooking_API.Controllers
{
    [ApiVersion("2.0")] // give the version of the method
    //[ApiVersion("2.0", Deprecated = true)] //Version is deprecated
    [Route("api/{v:apiversion}/Make")] //Give the same controller name
    [ApiController]
    public class MakeV2Controller : ControllerBase
    {
        private CarBookingDbContext _context;

        public MakeV2Controller(CarBookingDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetMakes()//To show the version, here just says the 2.0 version of Getmakes is this
        {
            return Ok(_context.Makes);
        }
    }
}
