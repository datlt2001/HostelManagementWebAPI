using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface ILocationRepository
    {
        Location GetLocationByID(int id);
        void UpdateLocation(Location Location);
        void AddLocation(Location Location);
        IEnumerable<Location> GetLocationsList();
    }
}
