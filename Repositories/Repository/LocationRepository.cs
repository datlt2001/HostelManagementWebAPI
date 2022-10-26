using BusinessObjects.Models;
using DataAccess.DAO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class LocationRepository : ILocationRepository
    {
        public void AddLocation(Location Location) =>  LocationDAO.AddLocation(Location);
        public Location GetLocationByID(int id) =>  LocationDAO.GetLocationByID(id);

        public IEnumerable<Location> GetLocationsList() =>  LocationDAO.GetLocationsList();

        public void UpdateLocation(Location location) =>  LocationDAO.UpdateLocation(location);
    }
}
