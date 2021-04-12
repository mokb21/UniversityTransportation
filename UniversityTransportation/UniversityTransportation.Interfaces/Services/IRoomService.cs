using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityTransportation.DTO.Journey;

namespace UniversityTransportation.Interfaces.Services
{
    public interface IRoomService
    {
        Task<Room> AddRoomAsync(Room room);

        Task<Room> UpdateRoomAsync(Room room);

        List<Room> GetAllRooms();

        Room GetRoom(Guid Id);

        void DeleteRoom(Guid Id);
    }
}
