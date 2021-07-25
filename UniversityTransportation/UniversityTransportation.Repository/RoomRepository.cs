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
    public class RoomRepository : Repository<Room>, IRoomRepository
    {
        private readonly ApplicationContext _applicationContext;
        public RoomRepository(ApplicationContext applicationContext) : base(applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public override Room Get(Guid Id)
        {
            try
            {
                return _applicationContext.Rooms
                    .Include(e => e.Journey)
                    .Include(e => e.Passengers).ThenInclude(e => e.ApplicationUser).FirstOrDefault(e => e.Id == Id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't retrieve entities: {ex.Message}");
            }
        }

        public override IQueryable<Room> GetAll()
        {
            try
            {
                return _applicationContext.Rooms
                    .Include(e => e.Journey)
                    .Include(e => e.Passengers).ThenInclude(e => e.ApplicationUser);
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't retrieve entities: {ex.Message}");
            }
        }
    }
}