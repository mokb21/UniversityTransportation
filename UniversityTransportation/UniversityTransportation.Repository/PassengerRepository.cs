using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityTransportation.Data;
using UniversityTransportation.Data.Models.Accounts;
using UniversityTransportation.Interfaces.Repository;

namespace UniversityTransportation.Repository
{
    public class PassengerRepository : Repository<Passenger>, IPassengerRepository
    {
        private readonly ApplicationContext _applicationContext;
        public PassengerRepository(ApplicationContext applicationContext) : base(applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public override async Task<Passenger> AddAsync(Passenger entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(AddAsync)} entity must not be null");
            }

            try
            {
                if (_applicationContext.Passengers.Any(e => e.UniversityId == entity.UniversityId))
                    throw new Exception($"University Id must be Unique");

                if (_applicationContext.Passengers.Any(e => e.QRCode == entity.QRCode))
                    throw new Exception($"QR Code must be Unique");

                await _applicationContext.AddAsync(entity);
                await _applicationContext.SaveChangesAsync();

                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entity)} could not be saved: {ex.Message}");
            }
        }

        public override Passenger Get(Guid Id)
        {
            try
            {
                return _applicationContext.Passengers.Include(e => e.ApplicationUser).FirstOrDefault(e => e.Id == Id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't retrieve entities: {ex.Message}");
            }
        }

        public override IQueryable<Passenger> GetAll()
        {
            try
            {
                return _applicationContext.Passengers.Include(e => e.ApplicationUser);
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't retrieve entities: {ex.Message}");
            }
        }

        public override void Delete(Guid Id)
        {
            try
            {
                var entity = _applicationContext.Passengers.Find(Id);

                if (entity == null)
                {
                    throw new ArgumentNullException($"{nameof(AddAsync)} entity must not be null");
                }

                var user = _applicationContext.Users.FirstOrDefault(e => e.PassengerId == Id);
                _applicationContext.Users.Remove(user);

                _applicationContext.Passengers.Remove(entity);
                _applicationContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't retrieve entities: {ex.Message}");
            }
        }
    }
}
