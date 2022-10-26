using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IAccountRepository
    {
        Account GetLoginAccount(string email, string password);
        Account GetAccountByID(int id);
        Account GetAccountByEmail(string email);
        void UpdateAccount(Account Account);
        void DeleteAccount(Account Account);
        void AddAccount(Account Account);
        void ActivateUser(int id);
        void InactivateUser(int id);
        List<Account> GetAccounts();
    }
}
