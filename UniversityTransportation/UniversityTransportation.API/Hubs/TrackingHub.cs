using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniversityTransportation.Data;

namespace UniversityTransportation.API.Hubs
{
    public class TrackingHub : Hub
    {
        private readonly ApplicationContext _context;

        public TrackingHub(ApplicationContext context)
        {
            _context = context;
        }

        public async Task SendGPSPoint(Guid id, double latitude, double longitude)
        {
            try
            {
                var driver = _context.Drivers.Include(e => e.ApplicationUser).FirstOrDefault(e => e.Id == id);

                await Clients.All.SendAsync("ShowPointsOnMap", driver.Id, driver.ApplicationUser.UserName, latitude, longitude);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
