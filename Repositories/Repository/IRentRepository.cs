using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IRentRepository
    {
        void AddRent(Rent Rent);
        void UpdateRent(Rent Rent);
        IEnumerable<Rent> GetRentListByRoom(int roomId);
        IEnumerable<Rent> GetRentList();
        Rent GetRentByID(int id);
    }
}
