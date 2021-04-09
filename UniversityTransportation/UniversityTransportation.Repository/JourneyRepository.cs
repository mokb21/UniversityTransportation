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
    public class JourneyRepository : Repository<Data.Models.Journey.Journey>, IJourneyRepository
    {
        private readonly ApplicationContext _applicationContext;
        public JourneyRepository(ApplicationContext applicationContext) : base(applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public override IQueryable<Journey> GetAll()
        {
            try
            {
                return _applicationContext.Journeys.Include(e => e.JourneyStations);
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't retrieve entities: {ex.Message}");
            }
        }

        public override Journey Get(Guid Id)
        {
            try
            {
                return _applicationContext.Journeys.Include(e => e.JourneyStations).FirstOrDefault(e => e.Id == Id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't retrieve entities: {ex.Message}");
            }
        }

        public override async Task<Journey> UpdateAsync(Journey entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(AddAsync)} entity must not be null");
            }

            try
            {
                _applicationContext.Attach(entity);
                _applicationContext.Entry(entity).State = EntityState.Modified;

                _applicationContext.Journeys.Update(entity);
                await _applicationContext.SaveChangesAsync();

                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entity)} could not be saved: {ex.Message}");
            }
        }
    }
}
