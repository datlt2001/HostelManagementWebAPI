using BusinessObjects.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IHostelPicRepository
    {
        void AddHostelPic(HostelPic hostelPic);
        IEnumerable<HostelPic> GetHostelPicsOfAHostel(int hostelId);
        void DeleteHostelPic(HostelPic hostelPic);
        HostelPic GetHostelPic(int id);
    }
}
