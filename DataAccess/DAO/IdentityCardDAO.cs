using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects.Models;
using DataAccess.Data;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.DAO
{
    public class IdentityCardDAO
    {
        private static IdentityCardDAO instance = null;
        private static readonly object instanceLock = new object();
        public static IdentityCardDAO Instance
        {
            get
            {
                lock(instanceLock)
                {
                    if (instance == null)
                        instance = new IdentityCardDAO();
                    return instance;
                }
            }
        }
        private IdentityCardDAO() { }
        public async Task AddIdCard(IdentityCard idCard)
        {
            try
            {
                var HostelManagementDBContext = new HostelManagementDBContext();
                HostelManagementDBContext.Attach(idCard).State = EntityState.Added;
                await HostelManagementDBContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task DeleteIdCard(IdentityCard idCard)
        {
            try
            {
                var HostelManagementDBContext = new HostelManagementDBContext();
                HostelManagementDBContext.IdentityCards.Remove(idCard);
                await HostelManagementDBContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task UpdateIdCard(IdentityCard idCard)
        {
            try
            {
                var HostelManagementDBContext = new HostelManagementDBContext();
                HostelManagementDBContext.Attach(idCard).State = EntityState.Modified;
                await HostelManagementDBContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IdentityCard> GetIdentityCardByID(string id)
        {
            try
            {
                var HostelManagementDBContext = new HostelManagementDBContext();
                return await HostelManagementDBContext.IdentityCards
                    .Include(h => h.Accounts)
                    .FirstOrDefaultAsync(idC => idC.IdCardNumber == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
