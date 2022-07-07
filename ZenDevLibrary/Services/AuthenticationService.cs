using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZenDevLibrary.DbModels;

namespace ZenDevLibrary.Services
{
   public class AuthenticationService
    {
        ZenDbContext _db = new ZenDbContext();
        public bool ProvjeriLogin(string user, string pass)
        {
            var model = _db.Admins.Where(x => user == x.Username && pass == x.Password).FirstOrDefault();

            if (model == null)
                return false;
            else
                return true;
        }
    }
}
