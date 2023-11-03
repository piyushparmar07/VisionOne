using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using VisionOne.BAL.Domain;
using VisionOne.DAL.Configuration;

namespace VisionOne.DAL.Data
{
    public class VisionOneDataContext : DbContext
    {
        public VisionOneDataContext(DbContextOptions<VisionOneDataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new UserConfiguration(modelBuilder.Entity<User>());
            new RoleConfiguration(modelBuilder.Entity<Role>());
        }
    }
}
