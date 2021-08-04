using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityTransportation.Models;

namespace UniversityTransportation.Interfaces.Services
{
    public interface IDashboardService
    {
        DashboardModel GetDashboardData();
    }
}
