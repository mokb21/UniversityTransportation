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
    }
}
