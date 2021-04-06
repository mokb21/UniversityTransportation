﻿using System;
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

                await _applicationContext.AddAsync(entity);
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