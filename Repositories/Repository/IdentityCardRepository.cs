using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects.Models;
using DataAccess.DAO;

namespace DataAccess.Repository
{
    public class IdentityCardRepository : IIdentityCardRepository
    {
        public void AddIdCard(IdentityCard idCard) => IdentityCardDAO.AddIdCard(idCard);
        public void DeleteIdCard(IdentityCard idCard) => IdentityCardDAO.DeleteIdCard(idCard);
        public void UpdateIdCard(IdentityCard idCard) => IdentityCardDAO.UpdateIdCard(idCard);
        public IdentityCard GetIdentityCardByID(string id) => IdentityCardDAO.GetIdentityCardByID(id);
    }
}
