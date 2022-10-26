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
        public static void AddIdCard(IdentityCard idCard)
        {
            try
            {
                using (var context = new HostelManagementDBContext())
                {
                    context.Attach(idCard).State = EntityState.Added;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void DeleteIdCard(IdentityCard idCard)
        {
            try
            {
                using (var context = new HostelManagementDBContext())
                {
                    context.IdentityCards.Remove(idCard);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static void UpdateIdCard(IdentityCard idCard)
        {

            try
            {
                using (var context = new HostelManagementDBContext())
                {
                    context.Attach(idCard).State = EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static IdentityCard GetIdentityCardByID(string id)
        {
            var acc = new IdentityCard();
            try
            {
                using (var context = new HostelManagementDBContext())
                {
                    acc = context.IdentityCards
                    .Include(h => h.Accounts)
                    .FirstOrDefault(idC => idC.IdCardNumber == id);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return acc;
        }
    }
}