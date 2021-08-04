using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityTransportation.Data.Models.Accounts;
using UniversityTransportation.Data.Models.Journey;
using UniversityTransportation.Data.Models.Trip;

namespace UniversityTransportation.Services.AutoMapper
{
    public class AutoMapperConfiguration
    {
        public MapperConfiguration configuration;

        public AutoMapperConfiguration()
        {
            configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Station, DTO.Journey.Station>()
                    .ReverseMap();

                cfg.CreateMap<Driver, DTO.Accounts.Driver>()
                    .ForMember(dst => dst.Id, opt => opt.MapFrom(srs => srs.ApplicationUser.DriverId))
                    .ForMember(dst => dst.UserName, opt => opt.MapFrom(srs => srs.ApplicationUser.UserName))
                    .ForMember(dst => dst.Email, opt => opt.MapFrom(srs => srs.ApplicationUser.Email))
                    .ForMember(dst => dst.Phone, opt => opt.MapFrom(srs => srs.ApplicationUser.PhoneNumber))
                    .ReverseMap();

                cfg.CreateMap<Passenger, DTO.Accounts.Passenger>()
                    .ForMember(dst => dst.Id, opt => opt.MapFrom(srs => srs.ApplicationUser.PassengerId))
                    .ForMember(dst => dst.UserName, opt => opt.MapFrom(srs => srs.ApplicationUser.UserName))
                    .ForMember(dst => dst.Email, opt => opt.MapFrom(srs => srs.ApplicationUser.Email))
                    .ForMember(dst => dst.Phone, opt => opt.MapFrom(srs => srs.ApplicationUser.PhoneNumber))
                    .ReverseMap();

                cfg.CreateMap<Journey, DTO.Journey.Journey>()
                    .ReverseMap();

                cfg.CreateMap<JourneyStation, DTO.Journey.JourneyStation>()
                    .ReverseMap();

                cfg.CreateMap<Room, DTO.Journey.Room>()
                    .ForMember(dst => dst.PassengersCount, opt => opt.MapFrom(srs => srs.Passengers.Count))
                    .ReverseMap();

                cfg.CreateMap<RequestTrip, DTO.Trip.RequestTrip>()
                   .ReverseMap();

                cfg.CreateMap<JourneyStation, Models.DetailedJourneyStationModel>()
                    .ForMember(dst => dst.Id, opt => opt.MapFrom(srs => srs.Station.Id))
                    .ForMember(dst => dst.Name, opt => opt.MapFrom(srs => srs.Station.Name))
                    .ForMember(dst => dst.CreateDate, opt => opt.MapFrom(srs => srs.Station.CreateDate))
                    .ForMember(dst => dst.LastUpdateDate, opt => opt.MapFrom(srs => srs.Station.LastUpdateDate))
                    .ForMember(dst => dst.Longitude, opt => opt.MapFrom(srs => srs.Station.Longitude))
                    .ForMember(dst => dst.Latitude, opt => opt.MapFrom(srs => srs.Station.Latitude))
                    .ForMember(dst => dst.ArrivalDate, opt => opt.MapFrom(srs => srs.ArrivalDate))
                    .ReverseMap();

                cfg.CreateMap<Trip, DTO.Trip.Trip>()
                   .ReverseMap();

                cfg.CreateMap<PassengerJourneyStation, DTO.Journey.PassengerJourneyStation>()
                  .ReverseMap();
            });
        }

    }
}
