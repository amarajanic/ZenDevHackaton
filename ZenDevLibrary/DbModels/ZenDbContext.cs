using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ZenDevLibrary.DbModels
{
    public class ZenDbContext : DbContext
    {
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<SubType> SubTypes { get; set; }
        public DbSet<Type> Type { get; set; }
        public DbSet<Location> Location { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.;Database=ZenDevDB;Trusted_Connection=True;");
        }
    }
}
