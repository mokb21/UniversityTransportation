using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UniversityTransportation.API.Hubs
{
    public class TrackingHub : Hub
    {
        public async Task SendGPSPoint(double latitude, double longitude)
        {
            await Clients.All.SendAsync("ShowPointsOnMap", latitude, longitude);
        }
    }
}
