using AutoMapper;
using CarBookingData.DTOModels;
using CarBookingRepository.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Serilog;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarBooking_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarModelController : ControllerBase
    {
        private readonly IUnitofWork _unitofWork;
        private readonly ILogger<CarModelController> _logger;
        private readonly IMapper _mapper;

        public CarModelController(IUnitofWork unitofWork, ILogger<CarModelController> logger,IMapper mapper)
        {
            _unitofWork = unitofWork;
            _logger = logger;
            _mapper = mapper;
            //_logger = (ILogger<CarModelController>) logger;
        }
        [HttpGet]
        public async Task<IActionResult> GetCarModels()
        {
            try
            {
                var countries = await _unitofWork.CarModels.GetAll(); // Get all the filds from the Car model data class
                var results = _mapper.Map<IList<CarModelDTO>>(countries); // Using the DTO class, then we can control the fields to be exposed. The fields mentioned in the DTO only will be exposed if using DTO
                return Ok(results); //OK status code is 200 and it is already associated
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,$"Something went wrong in the {nameof(GetCarModels)}");                
                return StatusCode(500, "Internal Server Error: Please try again later.");// Status code 500 is for the internal server erro globally
                //return StatusCode(500, ex.ToString());
            }
        }

    }
}
