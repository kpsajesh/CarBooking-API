using AutoMapper;
using CarBookingData.DataModels;
using CarBookingData.DTOModels;
using CarBookingRepository.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetCarModels()
        {
            try
            {
                var carModels = await _unitofWork.CarModels.GetAll(); // Get all the filds from the Car model data class
                var results = _mapper.Map<IList<CarModelDTO>>(carModels); // Using the DTO class, then we can control the fields to be exposed. The fields mentioned in the DTO only will be exposed if using DTO
                return Ok(results); //OK status code is 200 and it is already associated
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,$"Something went wrong in the {nameof(GetCarModels)}");                
                return StatusCode(500, "Internal Server Error: Please try again later.");// Status code 500 is for the internal server erro globally
                //return StatusCode(500, ex.ToString());
            }
        }

        //[Authorize]
        [HttpGet("{id:int}",Name = "GetCarModelsWithId")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetCarModelsWithId(int id)
        {
            try
            {
                /*var carModels = await _unitofWork.CarModels.Get(q => q.Id == id, new List<string> { "Makes" });*/
                var carModels = await _unitofWork.CarModels.Get(q => q.Id == id);//, include: r => r.Include(r => r.Makes));
                var result = _mapper.Map<CarModelDTO>(carModels);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(GetCarModelsWithId)}");
                //return StatusCode(500, "Internal Server Error: Please try again later.");
                return StatusCode(500, ex.ToString());
            }
        }

        //[Authorize(Roles = "Administrator")] // can authorise based on roles, policy
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateCarModel([FromBody] CreateCarModelDTO CarModelDTO)
        {
            _logger.LogInformation($"Invalid POST Attempt for {nameof(CreateCarModel)}");
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var carModel = _mapper.Map<CarModel>(CarModelDTO);
                await _unitofWork.CarModels.Insert(carModel); // Inserts the given data
                await _unitofWork.Save(); // saves the insert

                return CreatedAtRoute("GetCarModelsWithId", new { id = carModel.Id }, carModel); // calling the above API method GetCarModelsWithId to fetch the data of newly created record
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(CreateCarModel)}");
                return Problem($"Something went wrong in the {nameof(CreateCarModel)}", statusCode: 500);
                //return StatusCode(500, ex.ToString());                
            }
        }


    }
}
