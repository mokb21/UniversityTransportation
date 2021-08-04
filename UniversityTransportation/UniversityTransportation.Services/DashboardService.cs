using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityTransportation.Constants;
using UniversityTransportation.Interfaces.Repository;
using UniversityTransportation.Interfaces.Services;
using UniversityTransportation.Models;

namespace UniversityTransportation.Services
{
    public class DashboardService : IDashboardService
    {
        private readonly IRoomRepository _roomRepository;

        public DashboardService(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public DashboardModel GetDashboardData()
        {
            try
            {
                var model = new DashboardModel();

                //Get rooms data
                var rooms = _roomRepository.GetAll();
                if (rooms != null)
                {
                    rooms = rooms.OrderByDescending(e => e.Passengers.Count).Take(7);

                    model.roomsBarChart.labels = rooms.Select(e => e.Journey.Name).ToList();
                    model.roomsBarChart.datasets.Add(new BarChartDataSetModel()
                    {
                        label = "Passengers",
                        backgroundColor = ThemeContstants.RedLight,
                        borderColor = ThemeContstants.RedStrong,
                        data = rooms.Select(e => e.Passengers.Count).ToList()
                    });
                }

                return model;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(GetDashboardData)} could not get dashboard data: {ex.Message}");
            }

        }
    }
}
