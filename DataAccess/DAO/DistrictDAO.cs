using BusinessObjects.Models;
using DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class DistrictDAO
    {
        public static IEnumerable<District> GetDistrictListByProvinceId(int ProvinceId)
        {
            var listDistricts = new List<District>();
            try
            {
                using (var context = new HostelManagementDBContext())
                {
                    listDistricts = context.Districts.Where(d => d.ProvinceId == ProvinceId).OrderBy(d => d.DistrictName).ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return listDistricts;
        }
    }
}