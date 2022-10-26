using BusinessObjects.Models;
using DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class WardDAO
    {
        public static IEnumerable<Ward> GetWardListByDistrictId(int DistrictId)
        {
            var listHostels = new List<Ward>();
            try
            {
                using (var context = new HostelManagementDBContext())
                {
                    listHostels = context.Wards.Where(d => d.DistrictId == DistrictId).OrderBy(w => w.WardName)
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
