using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniversityTransportation.Data;

namespace UniversityTransportation.API.Hubs
{
    public class NotificationsHub : Hub
    {
        private readonly ApplicationContext _context;

        public NotificationsHub(ApplicationContext context)
        {
            _context = context;
        }

        public async Task SendNotification(string title, string message)
        {
            try
            {
                await Clients.All.SendAsync("ReceiveNotification", title, message);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
