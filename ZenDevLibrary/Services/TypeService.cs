using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZenDevLibrary.DbModels;
using ZenDevLibrary.Interfaces;

namespace ZenDevLibrary.Services
{
    public class TypeService : ITypeService
    {

        ZenDbContext _db;

        public TypeService(ZenDbContext db)
        {
            _db = db;
        }

        public void Delete(int ID)
        {
            var type = _db.Type.Where(x => x.ID == ID).FirstOrDefault();
            if (type != null)
            {
                _db.Type.Remove(type);
                _db.SaveChanges();
            }
        }

        public async Task<List<DbModels.Type>> Get()
        {
            var models = await _db.Type.ToListAsync();

            return models;
        }

        public async Task<DbModels.Type> GetByID(int ID)
        {
            var model = await _db.Type.Where(x => x.ID == ID).FirstOrDefaultAsync();
            return model;
        }

    

        public void Insert(DbModels.Type request)
        {
            _db.Type.Add(request);
            _db.SaveChanges();
        }

        public void Update(int ID, DbModels.Type request)
        {
            var type = new DbModels.Type()
            {
                ID = ID,
                Name = request.Name
            };
            _db.Type.Update(type);
            _db.SaveChanges();
        }
    }
}
