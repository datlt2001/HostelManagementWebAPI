using BusinessObjects.Models;
using DataAccess.DAO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class HostelRepository : IHostelRepository
    {
        public void AddHostel(Hostel hostel) =>  HostelDAO.AddHostel(hostel);
        public void DeleteHostel(Hostel hostel) =>  HostelDAO.DeleteHostel(hostel);

        public Hostel GetHostelByID(int id) =>  HostelDAO.GetHostelByID(id);

        public IEnumerable<Hostel> GetHostelsList() =>  HostelDAO.GetHostelsList();
        public IEnumerable<Hostel> GetHostelsOfAnOwner(int id) =>  HostelDAO.GetHostelsOfAnOwner(id);

        public void UpdateHostel(Hostel hostel) =>  HostelDAO.UpdateHostel(hostel);

        public void DeactivateHostel(int id) =>  HostelDAO.DeactivateHostel(id);

        public void ActivateHostel(int id) =>  HostelDAO.ActivateHostel(id);

        public void DenyHostel(int id) =>  HostelDAO.DenyHostel(id);
    }
}
