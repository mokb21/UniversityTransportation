using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniversityTransportation.Interfaces.Services;

namespace UniversityTransportation.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class TripsController : ControllerBase
    {
        private readonly ILogger<TripsController> _logger;
        private readonly ITripService _tripService;

        public TripsController(ILogger<TripsController> logger, ITripService tripService)
        {
            _logger = logger;
            _tripService = tripService;
        }

        [HttpGet]
        public async Task<IActionResult> Start(Guid journeyId)
        {
            try
            {
                return Ok(await _tripService.StartTripAsync(journeyId));
            }
            catch (Exception ex)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet]
        public async Task<IActionResult> End(Guid journeyId)
        {
            try
            {
                return Ok(await _tripService.EndTripAsync(journeyId));
            }
            catch (Exception ex)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet]
        public async Task<IActionResult> AddPassenger(Guid journeyId, Guid qrCode)
        {
            try
            {
                return Ok(await _tripService.AddPassengerToTripAsync(journeyId, qrCode));
            }
            catch (Exception ex)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet]
        public IActionResult GetPassengers(Guid journeyId)
        {
            try
            {
                return Ok(_tripService.GetTripPassengers(journeyId));
            }
            catch (Exception ex)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
