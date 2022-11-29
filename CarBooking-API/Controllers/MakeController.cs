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
using Microsoft.AspNetCore.Authorization;
using Microsoft.Win32;
using CarBookingData.DataModels;
using Microsoft.AspNetCore.Mvc.Diagnostics;

namespace CarBooking_API.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    //[Route("api/Make")]
    [ApiController]
    public class MakeController : ControllerBase
    {
        private readonly IUnitofWork _unitofWork;
        private readonly ILogger<MakeController> _logger;
        private readonly IMapper _mapper;
        private readonly CarBookingDbContext _context;

        public MakeController(IUnitofWork unitofWork, ILogger<MakeController> logger, IMapper mapper, CarBookingDbContext context)
        {
            _unitofWork = unitofWork;
            _logger = logger;
            _mapper = mapper;
            _context = context;
        }

        //[Authorize]
        [HttpGet]
        //[Route("GetMakes")] // Can be used with a post method
        //[ResponseCache(Duration = 60)] // this is removed because the named caching used as below
        //[ResponseCache(CacheProfileName ="CacheDuration")]// removed ie it is implementd globally via Service extension & startup
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetMakes([FromQuery] RequestParams requestParams)// no need to have the fromquery parameters if no paging needed
        {
            try
            {
                /*Before bringing the paging
                var makes = await _unitofWork.Makes.GetAll(); // Get all the filds from the Car model data class
                var results = _mapper.Map<IList<MakeDTO>>(makes); // Using the DTO class, then we can control the fields to be exposed. The fields mentioned in the DTO only will be exposed if using DTO
                return Ok(results); //OK status code is 200 and it is already associated*/

                var makes = await _unitofWork.Makes.GetPagedList(requestParams); // Get all the filds from the Car model data class
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

        /*Before implementing Global error handling
        [HttpGet("{id:int}", Name = "GetMakesWithId")]
        //[Route("GetMakesWithId")] // Can be used with a post method
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetMakesWithId(int id)
        {
            if (id < 1)
            {
                _logger.LogInformation($"Invalid id for {nameof(GetMakesWithId)}");
                return BadRequest("Submitted data is invalid");
            }
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
        }*/

        [HttpGet("{id:int}", Name = "GetMakesWithId")]
        //[Route("GetMakesWithId")] // Can be used with a post method
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetMakesWithId(int id)
        {
            if (id < 1)
            {
                _logger.LogInformation($"Invalid id for {nameof(GetMakesWithId)}");
                return BadRequest("Submitted data is invalid");
            }

            //throw new Exception(); To check whether the global error handling is working or not. So this will log int he log file.

            var make = await _unitofWork.Makes.Get(q => q.Id == id);
            var result = _mapper.Map<MakeDTO>(make);
            return Ok(result);
        }

        //[Authorize(Roles = "Administrator")] // can authorise based on roles, policy
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateMake([FromBody] CreateMakeDTO MakeDTO)
        {
            
            if (!ModelState.IsValid)
            {
                _logger.LogInformation($"Invalid POST Attempt for {nameof(CreateMake)}");
                return BadRequest(ModelState);
            }

            try
            {
                var make = _mapper.Map<Make>(MakeDTO);
                await _unitofWork.Makes.Insert(make); // Inserts the given data
                await _unitofWork.Save(); // saves the insert

                return CreatedAtRoute("GetMakesWithId", new { id = make.Id }, make); // calling the above API method GetMakesWithId to fetch the data of newly created record
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(CreateMake)}");
                return Problem($"Something went wrong in the {nameof(CreateMake)}", statusCode: 500);
                //return StatusCode(500, ex.ToString());                
            }
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateMake(int id, [FromBody] UpdateMakeDTO makeDTO)
        {
            
            if (!ModelState.IsValid || id < 1)
            {
                _logger.LogInformation($"Invalid Update Attempt for {nameof(UpdateMake)}");
                return BadRequest(ModelState);
            }

            try
            {
                var make = await _unitofWork.Makes.Get(a => a.Id == id);
                if (make == null)
                {
                    _logger.LogInformation($"Invalid Update Attempt for {nameof(UpdateMake)}");
                    return BadRequest("Submitted data is invalid");
                }
                _mapper.Map(makeDTO, make);
                _unitofWork.Makes.Update(make);
                await _unitofWork.Save();

                return NoContent();

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(UpdateMake)}");
                return Problem($"Something went wrong in the {nameof(UpdateMake)}", statusCode: 500);
                //return StatusCode(500, ex.ToString());                
            }
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteMake(int id)
        {
            if (id < 1)
            {
                _logger.LogInformation($"Invalid delete Attempt for {nameof(DeleteMake)}");
                return BadRequest("Submitted data is invalid");
            }

            try
            {
                var make = await _unitofWork.Makes.Get(a => a.Id == id);
                if (make == null)
                {
                    _logger.LogInformation($"Invalid delete Attempt for {nameof(DeleteMake)}");
                    return BadRequest("Submitted data is invalid");
                }

                bool CarModelExists = await _context.CarModels.AnyAsync(m => m.MakeId == id);
                if(CarModelExists)
                {
                    _logger.LogInformation($"Child exists in delete Attempt of id {id} for {nameof(DeleteMake)}");
                    return BadRequest("Child record/s exists, please delete the child record/s first");
                }

                await _unitofWork.Makes.Delete(id);
                await _unitofWork.Save();

                return NoContent();

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(DeleteMake)}");
                return Problem($"Something went wrong in the {nameof(DeleteMake)}", statusCode: 500);
                //return StatusCode(500, ex.ToString());                
            }
        }

    }
}
