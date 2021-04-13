using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniversityTransportation.DTO.Trip;
using UniversityTransportation.Interfaces.Services;

namespace UniversityTransportation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class RequestTripController : ControllerBase
    {
        private readonly IRequestTripService _requestTripService;
        private readonly ILogger<RequestTripController> _logger;
        public RequestTripController(IRequestTripService requestTripService, ILogger<RequestTripController> logger)
        {
            _requestTripService = requestTripService;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get(Guid? Id)
        {
            try
            {
                if (Id.HasValue)
                    return Ok(_requestTripService.GetRequestTrip(Id.Value));
                else
                    return Ok(_requestTripService.GetAllRequestTrips());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] RequestTrip requestTrip)
        {
            try
            {
                return Ok(await _requestTripService.AddRequestTripAsync(requestTrip));
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
                _requestTripService.DeleteRequestTrip(Id);
                return NoContent();
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
