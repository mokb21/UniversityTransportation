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
        private readonly IStationRepository _stationRepository;
        private readonly IJourneyRepository _journeyRepository;

        public DashboardService(IRoomRepository roomRepository,
            IStationRepository stationRepository,
            IJourneyRepository journeyRepository)
        {
            _roomRepository = roomRepository;
            _stationRepository = stationRepository;
            _journeyRepository = journeyRepository;
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
                    rooms = rooms.OrderByDescending(e => e.Passengers.Count).Take(5);

                    model.roomsBarChart.labels = rooms.Select(e => e.Journey.Name).ToList();
                    model.roomsBarChart.datasets.Add(new BarChartDataSetModel()
                    {
                        label = "Passengers",
                        borderWidth = 1,
                        backgroundColor = ThemeContstants.RedLight,
                        borderColor = ThemeContstants.RedStrong,
                        data = rooms.Select(e => e.Passengers.Count).ToList()
                    });
                }

                //Get stations data
                var stations = _stationRepository.GetStationsWithPassengers();
                if (stations != null)
                {
                    stations = stations.OrderByDescending(e => e.PassengerJourneyStations.Count).Take(7);

                    model.stationsBarChart.labels = stations.Select(e => e.Name).ToList();
                    model.stationsBarChart.datasets.Add(new BarChartDataSetModel()
                    {
                        label = "Passengers",
                        borderWidth = 1,
                        backgroundColor = ThemeContstants.BlueLight,
                        borderColor = ThemeContstants.BlueStrong,
                        data = stations.Select(e => e.PassengerJourneyStations.Count).ToList()
                    });
                }

                //Get stations data
                var journeys = _journeyRepository.GetJourneysWithPassengers();
                if (journeys != null)
                {
                    journeys = journeys.OrderByDescending(e => e.PassengerJourneyStations.Count).Take(7);

                    model.journeysBarChart.labels = journeys.Select(e => e.Name).ToList();
                    model.journeysBarChart.datasets.Add(new BarChartDataSetModel()
                    {
                        label = "Passengers",
                        borderWidth = 1,
                        backgroundColor = ThemeContstants.PurpleLight,
                        borderColor = ThemeContstants.PurpleStrong,
                        data = journeys.Select(e => e.PassengerJourneyStations.Count).ToList()
                    });
                }


                var journeysRequested = _journeyRepository.GetJourneysWithRequestedTrip();
                if (journeysRequested != null)
                {
                    journeysRequested = journeysRequested.OrderByDescending(e => e.RequestTrips.Count).Take(5);

                    model.journeysRequestedBarChart.labels = journeysRequested.Select(e => e.Name).ToList();
                    model.journeysRequestedBarChart.datasets.Add(new BarChartDataSetModel()
                    {
                        label = "Passengers",
                        borderWidth = 1,
                        backgroundColor = ThemeContstants.OrangeLight,
                        borderColor = ThemeContstants.OrangeStrong,
                        data = journeysRequested.Select(e => e.RequestTrips.Count).ToList()
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
