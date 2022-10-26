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
        public static List<Account> GetAccountList()
        {
            var listAccounts = new List<Account>();
            try
            {
                using (var context = new HostelManagementDBContext())
                {
                    listAccounts = context.Accounts.ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return listAccounts;
        }

        public static void AddAccount(Account Account)
        {
            try
            {
                using (var context = new HostelManagementDBContext())
                {
                    context.Attach(Account).State = EntityState.Added;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void DeleteAccount(Account Account)
        {
            try
            {
                using (var context = new HostelManagementDBContext())
                {
                    var acc = context.Accounts.SingleOrDefault(a => a.UserId == Account.UserId);
                    context.Accounts.Remove(acc);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static Account GetAccountByEmail(string email)
        {
            var acc = new Account();
            try
            {
                using (var context = new HostelManagementDBContext())
                {
                    acc = context.Accounts
                        .Include(id => id.IdCardNumberNavigation)
                        .Include(id => id.Hostels)
                        .Include(id => id.Rents)
                        .SingleOrDefault(account => account.UserEmail == email);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return acc;
        }

        public static Account GetAccountByID(int id)
        {
            var acc = new Account();
            try
            {
                using (var context = new HostelManagementDBContext())
                {
                    acc = context.Accounts
                        .Include(id => id.IdCardNumberNavigation)
                        .Include(id => id.Hostels)
                        .Include(id => id.Rents)
                        .SingleOrDefault(account => account.UserId == id);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return acc;
        }

        public static Account GetLoginAccount(string email, string password)
        {
            var acc = new Account();
            try
            {
                using (var context = new HostelManagementDBContext())
                {
                    acc = context.Accounts
                        .Include(id => id.IdCardNumberNavigation)
                        .Include(id => id.Hostels)
                        .Include(id => id.Rents)
                        .SingleOrDefault(account => account.UserEmail == email && account.UserPassword == password);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return acc;
        }

        public static void UpdateAccount(Account Account)
        {
            try
            {
                using (var context = new HostelManagementDBContext())
                {
                    context.Attach(Account).State = EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static void InactiveUser(int id)
        {
            try
            {
                using (var context = new HostelManagementDBContext())
                {
                    var account = context.Accounts.SingleOrDefault(a => a.UserId.Equals(id));
                    context.Attach(account).State = EntityState.Modified;
                    account.Status = 0;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void ActivateUser(int id)
        {
            try
            {
                using (var context = new HostelManagementDBContext())
                {
                    var account = context.Accounts.SingleOrDefault(a => a.UserId.Equals(id));
                    context.Attach(account).State = EntityState.Modified;
                    account.Status = 1;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
