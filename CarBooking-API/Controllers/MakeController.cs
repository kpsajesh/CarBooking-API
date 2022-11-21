using AutoMapper;
using CarBookingData.DTOModels;
using CarBookingRepository.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Microsoft.EntityFrameworkCore;

namespace CarBooking_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MakeController : ControllerBase
    {
        private readonly IUnitofWork _unitofWork;
        private readonly ILogger<MakeController> _logger;
        private readonly IMapper _mapper;

        public MakeController(IUnitofWork unitofWork, ILogger<MakeController> logger, IMapper mapper)
        {
            _unitofWork = unitofWork;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        //[Route("GetMakes")] // Can be used with a post method
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetMakes()
        {
            try
            {
                var makes = await _unitofWork.Makes.GetAll(); // Get all the filds from the Car model data class
                var results = _mapper.Map<IList<MakeDTO>>(makes); // Using the DTO class, then we can control the fields to be exposed. The fields mentioned in the DTO only will be exposed if using DTO
                return Ok(results); //OK status code is 200 and it is already associated
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(GetMakes)}");
                return StatusCode(500, "Internal Server Error: Please try again later.");// Status code 500 is for the internal server erro globally
                //return StatusCode(500, ex.ToString());
            }
        }

        [HttpGet("{id:int}", Name= "GetMakesWithId")]
        //[Route("GetMakesWithId")] // Can be used with a post method
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetMakesWithId(int id)
        {
            try
            {
                //var make = await _unitofWork.Makes.Get(q => q.Id == id, new List<string> { "CarModels" });
                //var make = await _unitofWork.Makes.Get(q => q.Id == id, include: r => r.Include(r => r.CarModels));
                var make = await _unitofWork.Makes.Get(q => q.Id == id);
                var result = _mapper.Map<MakeDTO>(make);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(GetMakesWithId)}");
                //return StatusCode(500, "Internal Server Error: Please try again later.");
                return StatusCode(500, ex.ToString());
            }
        }
    }
}
