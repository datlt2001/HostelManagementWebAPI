using BusinessObjects.Models;
using DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class AccountDAO
    {
        private static AccountDAO instance = null;
        private static readonly object instanceLock = new object();
        public static AccountDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new AccountDAO();
                    }
                    return instance;
                }
            }
        }
        private AccountDAO() { }
        public async Task AddAccount(Account Account)
        {
            try
            {
                var HostelManagementDBContext = new HostelManagementDBContext();
                HostelManagementDBContext.Attach(Account).State = EntityState.Added;
                await HostelManagementDBContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task DeleteAccount(Account Account)
        {
            try
            {
                var HostelManagementDBContext = new HostelManagementDBContext();
                HostelManagementDBContext.Accounts.Remove(Account);
                await HostelManagementDBContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Account> GetAccountByEmail(string email)
        {
            try
            {
                var HostelManagementDBContext = new HostelManagementDBContext();
                return await HostelManagementDBContext.Accounts
                    .Include(id => id.IdCardNumberNavigation)
                    .Include(id => id.Hostels)
                    .Include(id => id.Rents)
                    .SingleOrDefaultAsync(account => account.UserEmail == email);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Account> GetAccountByID(int id)
        {
            try
            {
                var HostelManagementDBContext = new HostelManagementDBContext();
                return await HostelManagementDBContext.Accounts
                    .Include(id => id.IdCardNumberNavigation)
                    .Include(id => id.Hostels)
                    .Include(id => id.Rents)
                    .SingleOrDefaultAsync(account => account.UserId == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<Account>> GetAccountList()
        {
            try
            {
                var HostelManagementDBContext = new HostelManagementDBContext();
                return await HostelManagementDBContext.Accounts
                    .Include(id => id.IdCardNumberNavigation)
                    .Include(id => id.Hostels)
                    .Include(id => id.Rents)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Account> GetLoginAccount(string email, string password)
        {
            try
            {
                var HostelManagementDBContext = new HostelManagementDBContext();
                return await HostelManagementDBContext.Accounts
                    .Include(id => id.IdCardNumberNavigation)
                    .Include(id => id.Hostels)
                    .Include(id => id.Rents)
                    .SingleOrDefaultAsync(account => account.UserEmail == email && account.UserPassword == password);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task UpdateAccount(Account Account)
        {
            try
            {
                var HostelManagementDBContext = new HostelManagementDBContext();
                HostelManagementDBContext.Attach(Account).State = EntityState.Modified;
                await HostelManagementDBContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException.Message);
            }
        }
        public async Task InactiveUser(int id)
        {
            try
            {
                var HostelManagementDBContext = new HostelManagementDBContext();
                var account = HostelManagementDBContext.Accounts.SingleOrDefault(a => a.UserId.Equals(id));
                HostelManagementDBContext.Accounts.Attach(account);
                account.Status = 0;
                await HostelManagementDBContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task ActivateUser(int id)
        {
            try
            {
                var HostelManagementDBContext = new HostelManagementDBContext();
                var account = HostelManagementDBContext.Accounts.SingleOrDefault(a => a.UserId.Equals(id));
                HostelManagementDBContext.Accounts.Attach(account);
                account.Status = 1;
                await HostelManagementDBContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
