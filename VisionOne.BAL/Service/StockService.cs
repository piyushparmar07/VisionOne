using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisionOne.BAL.Service.Interface;
using VisionOne.Core.Domain;
using VisionOne.DAL.Repository;
using VisionOne.DAL.Repository.Interface;

namespace VisionOne.BAL.Service
{
    public class StockService : IStockService
    {
        private readonly IStockRepository _stockRepository;
        public StockService(IStockRepository stockRepository)
        {
            _stockRepository = stockRepository;
        }

        public IEnumerable<Stock> GetAllStocks()
        {
            return _stockRepository.FindListAsync<Stock>(expression: m => m.Id > 0).Result;
        }
        public Stock GetStockById(int Id)
        {
            return _stockRepository.GetById<Stock>(Id).Result;
        }
        public bool DeleteStockById(int Id)
        {
            var obj = _stockRepository.GetById<Stock>(Id).Result;
            if (obj != null)
            {
                CancellationTokenSource cancelTokenSource = new();
                _stockRepository.Delete<Stock>(obj, cancelTokenSource.Token);
                return true;
            }
            else
                return false;
        }

        public void AddStock(Stock stock)
        {
            CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
            _stockRepository.Add<Stock>(stock, cancelTokenSource.Token);
        }

        public void UdateStock(Stock stock)
        {
            CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
            _stockRepository.Update<Stock>(stock, cancelTokenSource.Token);
        }
    }
}
