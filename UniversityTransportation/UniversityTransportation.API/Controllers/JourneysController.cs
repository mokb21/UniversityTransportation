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
    public class JourneysController : ControllerBase
    {
        private readonly ILogger<JourneysController> _logger;
        private readonly IJourneyService _journeyService;
        public JourneysController(ILogger<JourneysController> logger, IJourneyService journeyService)
        {
            _logger = logger;
            _journeyService = journeyService;
        }

        [HttpGet]
        public IActionResult Get(Guid? Id)
        {
            try
            {
                if (Id != null)
                    return Ok(_journeyService.GetJourney(Id.Value));
                else
                    return Ok(_journeyService.GetAllJourneys());
            }
            catch (Exception ex)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] DTO.Journey.Journey journey)
        {
            try
            {
                return Ok(await _journeyService.AddJourneyAsync(journey));
            }
            catch (Exception ex)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] DTO.Journey.Journey journey)
        {
            try
            {
                return Ok(await _journeyService.UpdateJourneyAsync(journey));
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
                _journeyService.DeleteJourney(Id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
