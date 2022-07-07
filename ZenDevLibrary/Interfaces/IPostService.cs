using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ZenDevLibrary.DbModels;

namespace ZenDevLibrary.Interfaces
{
    public interface IPostService
    {
       public Task<List<Post>> GetAllApproved();
       public Task<List<Post>> GetAllNotApproved();
       public void Insert(Post model);
        public void Delete(int ID);
        public void Update(int ID, bool isApproved);

    }
}
