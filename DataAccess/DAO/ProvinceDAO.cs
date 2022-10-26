using BusinessObjects.Models;
using DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class ProvinceDAO
    {
        public static IEnumerable<Province> GetProvincesList()
        {
            var listHostels = new List<Province>();
            try
            {
                using (var context = new HostelManagementDBContext())
                {
                    listHostels = context.Provinces.OrderBy(p => p.ProvinceName)
                    .ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return listHostels;
        }
    }
}
