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
    public class StockRepository : RepositoryBase, IStockRepository
    {
        private readonly VisionOneDataContext _dbContext;
        public StockRepository(VisionOneDataContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
