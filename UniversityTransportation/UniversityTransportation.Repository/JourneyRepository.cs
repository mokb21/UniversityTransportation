using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityTransportation.Data;
using UniversityTransportation.Interfaces.Repository;

namespace UniversityTransportation.Repository
{
    public class JourneyRepository : Repository<Data.Models.Journey.Journey>, IJourneyRepository
    {
        private readonly ApplicationContext _applicationContext;
        public JourneyRepository(ApplicationContext applicationContext) : base(applicationContext)
        {
            _applicationContext = applicationContext;
        }
    }
}
