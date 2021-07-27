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
    public class TripRepository : Repository<Trip>, ITripRepository
    {
        private readonly ApplicationContext _applicationContext;

        public TripRepository(ApplicationContext applicationContext) : base(applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public async Task<Trip> StartTripAsync(Guid journeyId)
        {
            var transaction = await _applicationContext.Database.BeginTransactionAsync();
            try
            {
                var journey = _applicationContext.Journeys.Find(journeyId);
                if (journey == null)
                {
                    throw new ArgumentNullException($"{nameof(StartTripAsync)} journey must not be null");
                }

                journey.IsStarted = true;

                var trip = await _applicationContext.AddAsync(new Trip()
                {
                    Id = Guid.NewGuid(),
                    JourneyId = journeyId,
                    StartDate = DateTime.Now,
                    EndDate = null
                });


                await _applicationContext.SaveChangesAsync();
                await transaction.CommitAsync();

                return trip.Entity;
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                throw new Exception($"{nameof(StartTripAsync)} could not be saved: {ex.Message}");
            }
        }

        public async Task<Trip> EndTripAsync(Guid journeyId)
        {
            var transaction = await _applicationContext.Database.BeginTransactionAsync();
            try
            {
                var journey = _applicationContext.Journeys
                    .Include(e => e.Trips)
                    .FirstOrDefault(e => e.Id == journeyId);
                if (journey == null)
                {
                    throw new ArgumentNullException($"{nameof(EndTripAsync)} journey must not be null");
                }

                journey.IsStarted = false;

                var trip = journey.Trips.OrderByDescending(e => e.StartDate).FirstOrDefault();
                if (trip == null)
                {
                    throw new ArgumentNullException($"{nameof(EndTripAsync)} trip must not be null");
                }

                trip.EndDate = DateTime.Now;

                await _applicationContext.SaveChangesAsync();
                await transaction.CommitAsync();

                return trip;
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                throw new Exception($"{nameof(EndTripAsync)} could not be saved: {ex.Message}");
            }
        }
    }
}
