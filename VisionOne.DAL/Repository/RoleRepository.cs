using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using VisionOne.Core.Domain;
using VisionOne.DAL.Data;
using VisionOne.DAL.Infrastructure;
using VisionOne.DAL.Repository.Interface;

namespace VisionOne.DAL.Repository
{
    public class RoleRepository : RepositoryBase, IRoleRepository
    {
        //private readonly IMainDbContext _dbContext;
        //public RoleRepository(IMainDbContext dbContext) : base(dbContext)
        //{
        //    _dbContext = dbContext;
        //}

        private readonly VisionOneDataContext _dbContext;
        public RoleRepository(VisionOneDataContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        //public string GetRoleById(int Id)
        //{
        //    var obj = _dbContext.Roles.Where(m=>m.Id== Id).FirstOrDefault();
        //    if (obj != null)
        //        return obj.Name;
        //    else
        //        return string.Empty;
        //}
    }
}
