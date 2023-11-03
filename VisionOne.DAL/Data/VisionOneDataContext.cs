using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace VisionOne.DAL.Data
{
    public class VisionOneDataContext : DbContext, IDbContext
    {
        public VisionOneDataContext(DbContextOptions<VisionOneDataContext> options) : base(options)
        {
        }


        public string GetConnectionString()
        {
            return "VisionOneDataContext";
        }
        //public VisionOneDataContext() : base("VisionOneDataContext")
        //{

        //}
        //public VisionOneDataContext(string nameOrConnectionString) : base(nameOrConnectionString)
        //{

        //}


        public bool ProxyCreationEnabled { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool AutoDetectChangesEnabled { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void Detach(object entity)
        {
            throw new NotImplementedException();
        }

        public int ExecuteSqlCommand(string sql, bool doNotEnsureTransaction = false, int? timeout = null, params object[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<TEntity> ExecuteStoredProcedureList<TEntity>(string commandText, params object[] parameters) where TEntity : class, new()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TElement> SqlQuery<TElement>(string sql, params object[] parameters)
        {
            throw new NotImplementedException();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //new StudentMap(modelBuilder.Entity<Student>());
        }

        public virtual void Commit()
        {
            base.SaveChanges();
        }
    }
}
