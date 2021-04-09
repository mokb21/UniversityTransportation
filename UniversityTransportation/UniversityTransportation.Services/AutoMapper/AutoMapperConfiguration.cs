using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityTransportation.Data.Models.Accounts;
using UniversityTransportation.Data.Models.Journey;

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
            });
        }

    }
}
