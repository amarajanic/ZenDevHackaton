using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ZenDevLibrary.DbModels;
using ZenDevLibrary.Interfaces;

namespace ZenDevLibrary.Services
{
    public class LocationService : ILocationService
    {
        public ZenDbContext _Context { get; set; }
        public LocationService(ZenDbContext context)
        {
            _Context = context;
        }
        public void Delete(int ID)
        {
            var model = _Context.Location.Find(ID);
            _Context.Location.Remove(model);
            _Context.SaveChanges();
        }

        public async Task<List<Location>> GetAll()
        {
            var model = await _Context.Location.ToListAsync();
            return model;
        }

        public void Insert(Location request)
        {
            _Context.Add(request);
            _Context.SaveChanges();
        }
    }
}
