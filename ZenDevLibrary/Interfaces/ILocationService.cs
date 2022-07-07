using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ZenDevLibrary.DbModels;

namespace ZenDevLibrary.Interfaces
{
    public interface ILocationService
    {
        Task<List<Location>> GetAll();
        void Insert(Location request);
        void Delete(int ID);
    }
}
