using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisionOne.DAL.Data;
using VisionOne.DAL.Infrastructure;
using VisionOne.DAL.Repository.Interface;

namespace VisionOne.DAL.Repository
{
    public class UserRepository: RepositoryBase, IUserRepository
    {
        private readonly VisionOneDataContext _dbContext;
        public UserRepository(VisionOneDataContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
