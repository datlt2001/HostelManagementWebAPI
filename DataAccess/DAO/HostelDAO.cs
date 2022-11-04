﻿using BusinessObjects.Models;
using DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class HostelDAO
    {
        private static HostelDAO instance = null;
        private static readonly object instanceLock = new object();
        public static HostelDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new HostelDAO();
                    }
                    return instance;
                }
            }
        }
        public async Task AddHostel(Hostel hostel)
        {
            try
            {
                var HostelManagementDBContext = new HostelManagementDBContext();
                HostelManagementDBContext.Attach(hostel).State = EntityState.Added;
                await HostelManagementDBContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task DeleteHostel(Hostel hostel)
        {
            throw new NotImplementedException();
        }

        public async Task<Hostel> GetHostelByID(int id)
        {
            try
            {
                var HostelManagementDBContext = new HostelManagementDBContext();
                return await HostelManagementDBContext.Hostels
                    //.Include(h => h.Rooms)
                    //    .ThenInclude(h => h.RoomPics)
                    //.Include(h => h.Category)
                    //.Include(h => h.HostelOwnerEmailNavigation)
                    //.Include(h => h.Location)
                    //    .ThenInclude(h => h.Ward)
                    //        .ThenInclude(h => h.District)
                    //            .ThenInclude(h => h.Province)
                    //.Include(h => h.HostelPics)
                    .FirstOrDefaultAsync(hostel => hostel.HostelId == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<Hostel>> GetHostelsList()
        {
            try
            {
                var HostelManagementDBContext = new HostelManagementDBContext();
                return await HostelManagementDBContext.Hostels
                    //.Include(h => h.Rooms)
                    //.Include(h => h.Category)
                    //.Include(h => h.Location)
                    //    .ThenInclude(h => h.Ward)
                    //        .ThenInclude(h => h.District)
                    //            .ThenInclude(h => h.Province)
                    //.Include(h => h.HostelPics)
                    //.Include(h => h.HostelOwnerEmailNavigation)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task UpdateHostel(Hostel hostel)
        {
            try
            {
                var HostelManagementDBContext = new HostelManagementDBContext();
                HostelManagementDBContext.Attach(hostel).State = EntityState.Modified;
                await HostelManagementDBContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<Hostel>> GetHostelsOfAnOwner(int id)
        {
            try
            {
                var HostelManagementDBContext = new HostelManagementDBContext();
                return await HostelManagementDBContext.Hostels
                    //.Include(h => h.Rooms)
                    //.Include(h => h.Category)
                    //.Include(h => h.Location)
                    //    .ThenInclude(h => h.Ward)
                    //        .ThenInclude(h => h.District)
                    //            .ThenInclude(h => h.Province)
                    //.Include(h => h.HostelPics)
                    //.Include(h => h.HostelOwnerEmailNavigation)
                    //.ThenInclude(h => h.UserId)
                    .Where(h => h.HostelOwnerEmailNavigation.UserId == id)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task DeactivateHostel(int id)
        {
            try
            {
                var HostelManagementDBContext = new HostelManagementDBContext();
                var hostel = HostelManagementDBContext.Hostels.SingleOrDefault(h => h.HostelId.Equals(id));
                HostelManagementDBContext.Hostels.Attach(hostel);
                hostel.Status = 2;
                await HostelManagementDBContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task ActivateHostel(int id)
        {
            try
            {
                var HostelManagementDBContext = new HostelManagementDBContext();
                var hostel = HostelManagementDBContext.Hostels.SingleOrDefault(h => h.HostelId.Equals(id));
                HostelManagementDBContext.Hostels.Attach(hostel);
                hostel.Status = 1;
                await HostelManagementDBContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task DenyHostel(int id)
        {
            try
            {
                var HostelManagementDBContext = new HostelManagementDBContext();
                var hostel = HostelManagementDBContext.Hostels.SingleOrDefault(h => h.HostelId.Equals(id));
                HostelManagementDBContext.Hostels.Attach(hostel);
                hostel.Status = 3;
                await HostelManagementDBContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
