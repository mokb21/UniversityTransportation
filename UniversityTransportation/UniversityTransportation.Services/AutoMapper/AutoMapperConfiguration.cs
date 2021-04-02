using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            });
        }
    }
}
