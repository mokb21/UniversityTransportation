using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using UniversityTransportation.Interfaces.Services;

namespace UniversityTransportation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

    public class PassengersController : ControllerBase
    {
        private IPassengerService _passengerService;
        private readonly ILogger<PassengersController> _logger;


        public PassengersController(IPassengerService passengerService, ILogger<PassengersController> logger)
        {
            _passengerService = passengerService;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get(Guid? Id)
        {
            try
            {
                //return BadRequest("Client Error Your Angular Code is Fucked up!! Fuck you grandfather Ardogan");
                
                if (Id.HasValue)
                    return Ok(_passengerService.GetPassenger(Id.Value));
                else
                    return Ok(_passengerService.GetAllPassengers());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpDelete]
        public IActionResult Delete(Guid Id)
        {
            try
            {
                _passengerService.DeletePassenger(Id);
                return NoContent();
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
