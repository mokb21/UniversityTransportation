using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityTransportation.Data.Models.Accounts;
using UniversityTransportation.Models;

namespace UniversityTransportation.Interfaces.Repository
{
    public interface IPassengerRepository : IRepository<Passenger>
    {
        Task<int> VoteRoomAsync(VoteRoomModel voteRoom);
    }
}
