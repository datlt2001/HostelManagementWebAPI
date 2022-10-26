using BusinessObjects.Models;
using DataAccess.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class RentRepository : IRentRepository
    {
        public void AddRent(Rent Rent) =>  RentDAO.AddRent(Rent);
        public void UpdateRent(Rent Rent) =>  RentDAO.UpdateRent(Rent);
        public IEnumerable<Rent> GetRentListByRoom(int roomId) =>  RentDAO.GetRentListByRoom(roomId);
        public IEnumerable<Rent> GetRentList() =>  RentDAO.GetRentList();
        public Rent GetRentByID(int id) =>  RentDAO.GetRentByID(id);
    }
}
