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
    public class JourneyRepository : Repository<Journey>, IJourneyRepository
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
                return _applicationContext.Journeys
                    .Include(e => e.JourneyStations).ThenInclude(e => e.Station)
                    .Include(e => e.Driver).ThenInclude(e => e.ApplicationUser);
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
                return _applicationContext.Journeys
                    .Include(e => e.JourneyStations).ThenInclude(e => e.Station)
                    .Include(e => e.Driver).ThenInclude(e => e.ApplicationUser)
                    .FirstOrDefault(e => e.Id == Id);
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
            var transaction = await _applicationContext.Database.BeginTransactionAsync();
            try
            {

                _applicationContext.JourneyStations.RemoveRange(_applicationContext.JourneyStations.Where(e => e.JourneyId == entity.Id));
                await _applicationContext.SaveChangesAsync();


                _applicationContext.JourneyStations.AddRange(entity.JourneyStations);
                _applicationContext.Update(entity);

                await _applicationContext.SaveChangesAsync();
                await transaction.CommitAsync();

                return entity;
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                throw new Exception($"{nameof(entity)} could not be saved: {ex.Message}");
            }
        }

        public IQueryable<Journey> GetJourneysByDriverId(Guid DriverId)
        {
            try
            {
                return _applicationContext.Journeys.Include(e => e.JourneyStations).Where(e => e.DriverId == DriverId);
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't retrieve entities: {ex.Message}");
            }
        }
    }
}
