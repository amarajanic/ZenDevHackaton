using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ZenDevLibrary.Interfaces
{
    public interface ITypeService
    {
        Task<List<DbModels.Type>> Get();
        void Delete(int ID);

        Task<DbModels.Type> GetByID(int ID);
        void Insert(DbModels.Type request);
        void Update(int ID, DbModels.Type request);
       

    }
}
