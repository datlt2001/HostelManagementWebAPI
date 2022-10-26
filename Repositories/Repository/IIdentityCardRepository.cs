using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects.Models;

namespace DataAccess.Repository
{
    public interface IIdentityCardRepository
    {
        void AddIdCard(IdentityCard idCard);
        void DeleteIdCard(IdentityCard idCard);
        void UpdateIdCard(IdentityCard idCard);
        IdentityCard GetIdentityCardByID(string id);
    }
}
