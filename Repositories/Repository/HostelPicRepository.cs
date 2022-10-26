using BusinessObjects.Models;
using DataAccess.DAO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class HostelPicRepository : IHostelPicRepository
    {
        public void AddHostelPic(HostelPic hostelPic) => HostelPicDAO.AddHostelPic(hostelPic);
        public void DeleteHostelPic(HostelPic hostelPic) => HostelPicDAO.DeleteHostelPic(hostelPic);
        public IEnumerable<HostelPic> GetHostelPicsOfAHostel(int hostelId) => HostelPicDAO.GetHostelPicsOfAHostel(hostelId);
        public HostelPic GetHostelPic(int id) => HostelPicDAO.GetHostelPic(id);
    }
}
