using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityTransportation.Data;
using UniversityTransportation.Data.Models.Trip;
using UniversityTransportation.Interfaces.Repository;

namespace UniversityTransportation.Repository
{
    public class RequestTripRepository : Repository<RequestTrip>, IRequestTripRepository
    {
        private readonly ApplicationContext _applicationContext;

        public RequestTripRepository(ApplicationContext applicationContext) : base(applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public override RequestTrip Get(Guid Id)
        {
            try
            {
                return _applicationContext.RequestTrips
                    .Include(e => e.Journey)
                    .Include(e => e.Passenger).ThenInclude(e => e.ApplicationUser)
                    .FirstOrDefault(e => e.Id == Id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't retrieve entities: {ex.Message}");
            }
        }

        public override IQueryable<RequestTrip> GetAll()
        {
            try
            {
                return _applicationContext.RequestTrips
                    .Include(e => e.Journey)
                    .Include(e => e.Passenger).ThenInclude(e => e.ApplicationUser);
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't retrieve entities: {ex.Message}");
            }
        }
    }
}
