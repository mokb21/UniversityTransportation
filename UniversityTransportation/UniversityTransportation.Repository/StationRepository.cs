using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityTransportation.Data;
using UniversityTransportation.Data.Models.Journey;
using UniversityTransportation.Interfaces.Repository;

namespace UniversityTransportation.Repository
{
    public class StationRepository : Repository<Station>, IStationRepository
    {
        private readonly ApplicationContext _applicationContext;

        public StationRepository(ApplicationContext applicationContext) : base(applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public IQueryable<JourneyStation> GetDetailedStationsByJourneyId(Guid JourneyId)
        {
            try
            {
                return _applicationContext.JourneyStations.Include(e => e.Station).Where(e => e.JourneyId == JourneyId);
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't retrieve entities: {ex.Message}");
            }
        }
    }
}
