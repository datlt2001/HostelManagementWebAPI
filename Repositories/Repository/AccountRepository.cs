using BusinessObjects.Models;
using DataAccess.DAO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class AccountRepository : IAccountRepository
    {
        public void AddAccount(Account Account) => AccountDAO.AddAccount(Account);

        public void DeleteAccount(Account Account) =>  AccountDAO.DeleteAccount(Account);

        public Account GetAccountByEmail(string email) =>  AccountDAO.GetAccountByEmail(email);

        public Account GetAccountByID(int id) =>  AccountDAO.GetAccountByID(id);

        public Account GetLoginAccount(string email, string password) =>  AccountDAO.GetLoginAccount(email, password);

        public void UpdateAccount(Account Account) =>  AccountDAO.UpdateAccount(Account);
        public void ActivateUser(int id) =>  AccountDAO.ActivateUser(id);
        public void InactivateUser(int id) =>  AccountDAO.InactiveUser(id);
        public List<Account> GetAccounts() => AccountDAO.GetAccountList();
    }
}
