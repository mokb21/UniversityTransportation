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
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class PassengerJourneyStationController : ControllerBase
    {
        private readonly ILogger<PassengerJourneyStationController> _logger;
        private readonly IPassengerJourneyStationService _passengerJourneyStationService;
        public PassengerJourneyStationController(ILogger<PassengerJourneyStationController> logger, IPassengerJourneyStationService passengerJourneyStationService)
        {
            _logger = logger;
            _passengerJourneyStationService = passengerJourneyStationService;
        }

        [HttpGet]
        public IActionResult Get(Guid? PassengerId)
        {
            try
            {
                if (PassengerId != null)
                    return Ok(_passengerJourneyStationService.GetPassengerJourneyStation(PassengerId.Value));
                else
                    return Ok(_passengerJourneyStationService.GetAllPassengerJourneyStation());
            }
            catch (Exception ex)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] DTO.Journey.PassengerJourneyStation passengerJourneyStation)
        {
            try
            {
                return Ok(await _passengerJourneyStationService.AddPassengerJourneyStationAsync(passengerJourneyStation));
            }
            catch (Exception ex)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] DTO.Journey.PassengerJourneyStation passengerJourneyStation)
        {
            try
            {
                return Ok(await _passengerJourneyStationService.UpdatePassengerJourneyStationAsync(passengerJourneyStation));
            }
            catch (Exception ex)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
