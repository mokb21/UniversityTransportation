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
        public StationRepository(ApplicationContext applicationContext) : base(applicationContext)
        {

        }
    }
}
