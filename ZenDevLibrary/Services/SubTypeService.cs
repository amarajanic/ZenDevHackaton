using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ZenDevLibrary.DbModels;
using ZenDevLibrary.Interfaces;

namespace ZenDevLibrary.Services
{
    public class SubTypeService : ISubTypeService
    {
        public ZenDbContext _Context { get; set; }
        public SubTypeService(ZenDbContext context)
        {
            _Context = context;
        }
        public void Delete(int ID)
        {
            var subType =  _Context.SubTypes.Where(x => x.ID == ID).FirstOrDefault();
            if(subType != null)
            {
                _Context.SubTypes.Remove(subType);
                _Context.SaveChanges();
            }
        }

        public async Task<List<SubType>> GetAll()
        {
            var models = await _Context.SubTypes.ToListAsync();
            return models;
        }

        public async Task<SubType> GetByID(int ID)
        {
            var model = await _Context.SubTypes.Where(x=> x.ID == ID).FirstOrDefaultAsync();
            return model;
        }

        public void Insert(SubType request)
        {
            _Context.SubTypes.Add(request);
            _Context.SaveChanges();
        }

        public void Update(int ID, SubType request)
        {
            SubType subType = new SubType()
            {
                ID = ID,
                Name = request.Name,
                TypeID = request.TypeID
            };
            _Context.SubTypes.Update(subType);
            _Context.SaveChanges();
        }
    }
}
