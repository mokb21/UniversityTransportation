using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityTransportation.DTO.Journey;
using UniversityTransportation.Interfaces.Repository;
using UniversityTransportation.Interfaces.Services;
using UniversityTransportation.Services.AutoMapper;

namespace UniversityTransportation.Services
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _roomRepository;
        private readonly IMapper _mapper;

        public RoomService(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;

            var mapperConfiguration = new AutoMapperConfiguration();
            _mapper = mapperConfiguration.configuration.CreateMapper();
        }

        public async Task<Room> AddRoomAsync(Room room)
        {
            try
            {
                room.Id = Guid.NewGuid();
                var result = await _roomRepository.AddAsync(_mapper.Map<Room, Data.Models.Journey.Room>(room));
                return _mapper.Map<Data.Models.Journey.Room, Room>(result);
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(room)} could not be saved: {ex.Message}");
            }
        }

        public void DeleteRoom(Guid Id)
        {
            try
            {
                _roomRepository.Delete(Id);
            }
            catch (Exception ex)
            {
                throw new Exception($"could not delete entity: {ex.Message}");
            }
        }

        public List<Room> GetAllRooms()
        {
            try
            {
                var results = _roomRepository.GetAll().ToList();
                return _mapper.Map<List<Data.Models.Journey.Room>, List<Room>>(results);
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't retrieve entities: {ex.Message}");
            }
        }

        public Room GetRoom(Guid Id)
        {
            try
            {
                var results = _roomRepository.Get(Id);
                return _mapper.Map<Data.Models.Journey.Room, Room>(results);
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't retrieve entity: {ex.Message}");
            }
        }

        public async Task<Room> UpdateRoomAsync(Room room)
        {
            try
            {
                var result = await _roomRepository.UpdateAsync(_mapper.Map<Room, Data.Models.Journey.Room>(room));
                return _mapper.Map<Data.Models.Journey.Room, Room>(result);
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(room)} could not be saved: {ex.Message}");

            }
        }
    }
}
