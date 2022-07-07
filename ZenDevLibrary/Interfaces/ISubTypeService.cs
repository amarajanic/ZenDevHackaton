using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ZenDevLibrary.DbModels;

namespace ZenDevLibrary.Interfaces
{
    public interface ISubTypeService
    {
        Task<List<SubType>> GetAll();
        Task<SubType> GetByID(int ID);
        void Insert(SubType request);
        void Update(int ID, SubType request);
        void  Delete(int ID);
    }
}
