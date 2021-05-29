using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityTransportation.Data.Models.Journey;

namespace UniversityTransportation.Interfaces.Repository
{
    public interface IJourneyRepository : IRepository<Journey>
    {
        IQueryable<Journey> GetJourneysByDriverId(Guid DriverId);
    }
}
