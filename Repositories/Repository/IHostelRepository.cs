using BusinessObjects.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IHostelRepository
    {
        Hostel GetHostelByID(int id);
        void UpdateHostel(Hostel hostel);
        void DeleteHostel(Hostel hostel);
        void AddHostel(Hostel hostel);
        IEnumerable<Hostel> GetHostelsList();
        IEnumerable<Hostel> GetHostelsOfAnOwner(int id);
        void DeactivateHostel(int id);
        void ActivateHostel(int id);
        void DenyHostel(int id);
    }
}
