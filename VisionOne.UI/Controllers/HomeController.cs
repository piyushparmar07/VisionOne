using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using VisionOne.BAL.Service.Interface;
using VisionOne.Core.Domain;
using VisionOne.UI.Models;

namespace VisionOne.UI.Controllers
{
    //[Authorize]
    public class HomeController : Controller
    {
        private readonly IStockService _stockService;

        public HomeController(IStockService stockService)
        {
            _stockService = stockService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ShowGrid()
        {
            return View();
        }

        public IActionResult LoadData()
        {
            try
            {
                var draw = HttpContext.Request.Form["draw"].FirstOrDefault();
                // Skiping number of Rows count  
                var start = Request.Form["start"].FirstOrDefault();
                // Paging Length 10,20  
                var length = Request.Form["length"].FirstOrDefault();
                // Sort Column Name  
                var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault();
                // Sort Column Direction ( asc ,desc)  
                var sortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault();
                // Search Value from (Search box)  
                var searchValue = Request.Form["search[value]"].FirstOrDefault();

                //Paging Size (10,20,50,100)  
                int pageSize = length != null ? Convert.ToInt32(length) : 0;
                int skip = start != null ? Convert.ToInt32(start) : 0;
                int recordsTotal = 0;

                // Getting all Customer data  
                var stockData = _stockService.GetAllStocks();

                //Sorting  
                //if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
                //{
                //    //stockData = stockData.OrderBy(sortColumn + " " + sortColumnDirection);

                //    bool ascending = sortColumnDirection == "asc";
                //    switch (sortColumn)
                //    {
                //        case "Code":
                //            stockData = QueryableExtensions.OrderBy(stockData, ascending);
                //            break;
                //        case "Location":
                //            stockData = stockData.OrderBy(p => p.Location, ascending);
                //            break;
                //        //case "":
                //        //    stockData = stockData.OrderBy(p => p.ExchangeMarket.Name, ascending);
                //        //    break;
                //        default:
                //            stockData = stockData.OrderBy(p => p.Id, true);
                //            break;
                //    }

                //}
                //Search  
                if (!string.IsNullOrEmpty(searchValue))
                {
                    stockData = stockData.Where(m => m.Code.ToLower().Contains(searchValue.ToLower()) || m.Location.ToLower().Contains(searchValue.ToLower()) || m.ContainerNumber.ToLower().Contains(searchValue.ToLower()) 
                    || m.GroupName.ToLower().Contains(searchValue.ToLower()));
                }

                //total number of rows count   
                recordsTotal = stockData.Count();
                //Paging   
                var data = stockData.Skip(skip).Take(pageSize).ToList();
                //Returning Json Data  
                return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data });

            }
            catch (Exception)
            {
                throw;
            }

        }

        public IActionResult DeleteStock(int Id)
        {
            if (_stockService.DeleteStockById(Id))
                return Json(new { draw = true, });
            else
                return Json(null);
        }

        [HttpGet]
        public IActionResult AddEditStock(int Id)
        {
            Stock objStock = new();
            if (Id > 0)
            {
                objStock = _stockService.GetStockById(Id);
            }
            return View(objStock);
        }

        [HttpPost]
        public IActionResult AddEditStock([Bind] Stock stock)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (stock.Id > 0)
                        _stockService.UdateStock(stock);
                    else
                        _stockService.AddStock(stock);
                    TempData["msg"] = "Record saved successfully";
                }
            }
            catch (Exception ex)
            {
                TempData["msg"] = ex.Message;
            }
            return View();
        }
    }
}