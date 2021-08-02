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
    public class PassengerJourneyStationRepository : Repository<PassengerJourneyStation>, IPassengerJourneyStationRepository
    {
        private readonly ApplicationContext _applicationContext;
        public PassengerJourneyStationRepository(ApplicationContext applicationContext) : base(applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public override IQueryable<PassengerJourneyStation> GetAll()
        {
            try
            {
                return _applicationContext.PassengerJourneyStations.Where(e => !e.IsDeleted);
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't retrieve entities: {ex.Message}");
            }
        }

        public override PassengerJourneyStation Get(Guid Id)
        {
            try
            {
                return _applicationContext.PassengerJourneyStations
                    .Where(e => e.PassengerId == Id && !e.IsDeleted).OrderByDescending(e => e.RegistrationDate)
                    .FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't retrieve entities: {ex.Message}");
            }
        }
    }
}
