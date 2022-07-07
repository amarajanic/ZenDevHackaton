using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ZenDevLibrary.DbModels;
using ZenDevLibrary.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ZenDevLibrary.Services
{
    public class PostService : IPostService
    {
        ZenDbContext _db;

        public PostService(ZenDbContext db)
        {
            _db = db;
        }
        public async Task<List<Post>> GetAllApproved()
        {
            var models = await _db.Posts.Where(x => x.IsApproved).OrderByDescending(x=> x.ID).ToListAsync();

            return models;
        }

        public async Task<List<Post>> GetAllNotApproved()
        {
            var models = await _db.Posts.Where(x => x.IsApproved == false).OrderByDescending(x => x.ID).ToListAsync();

            return models;
        }

        public void Insert(Post model)
        {
            _db.Posts.Add(model);
            _db.SaveChanges();
        }

        public void Delete(int ID)
        {
            Post post = new Post() { ID = ID };
            _db.Posts.Attach(post);
            _db.Posts.Remove(post);
            _db.SaveChanges();
        }

        public void Update(int ID, bool isApproved)
        {
            var model = _db.Posts.Where(x => x.ID == ID).FirstOrDefault();

            model.IsApproved = isApproved;

            _db.Posts.Update(model);
            _db.SaveChanges();
        }
    }
}
