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
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class StationsController : ControllerBase
    {
        private readonly ILogger<StationsController> _logger;
        private readonly IStationService _stationService;

        public StationsController(ILogger<StationsController> logger, IStationService stationService)
        {
            _logger = logger;
            _stationService = stationService;
        }

        [HttpGet]
        public IActionResult Get(Guid? Id)
        {
            try
            {
                if (Id != null)
                    return Ok(_stationService.GetStation(Id.Value));
                else
                    return Ok(_stationService.GetAllStations());
            }
            catch (Exception ex)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet]
        public IActionResult GetByJourneyId(Guid JourneyId)
        {
            try
            {
                return Ok(_stationService.GetDetailedStationsByJourneyId(JourneyId));
            }
            catch (Exception ex)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] DTO.Journey.Station station)
        {
            try
            {
                return Ok(await _stationService.AddStationAsync(station));
            }
            catch (Exception ex)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] DTO.Journey.Station station)
        {
            try
            {
                return Ok(await _stationService.UpdateStationAsync(station));
            }
            catch (Exception ex)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete]
        public IActionResult Delete(Guid Id)
        {
            try
            {
                _stationService.DeleteStation(Id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
