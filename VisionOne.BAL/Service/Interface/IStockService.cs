using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisionOne.Core.Domain;
using VisionOne.DAL.Infrastructure;

namespace VisionOne.BAL.Service.Interface
{
    public interface IStockService
    {
        IEnumerable<Stock> GetAllStocks();
        Stock GetStockById(int Id);
        bool DeleteStockById(int Id);
        void AddStock(Stock stock);
        void UdateStock(Stock stock);
    }
}
