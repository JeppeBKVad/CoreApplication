using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CoreApplication.Models;

namespace CoreApplication.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {

        return View();
    }
    public List<SaleModel> SearchProductByName(string productName)
    {
        var returndata = new List<SaleModel>();
        var data = SaleModel.findSales(productName);
        foreach (var item in data)
        {
            var productsbyname = new SaleModel();
            productsbyname.Id = item.Id;
            productsbyname.SoldAt = item.SoldAt;
            productsbyname.Amount = item.Amount;
            returndata.Add(productsbyname);
        }

        return returndata;
    }
    public List<DaySales> TotalNetto()
    {
        var sales = SaleModel.getTotal();
        var productData = ProductModel.getTotal();

        var salesByDay = from sale in sales
        join product in productData on sale.Product equals product.Id
        group new { Sale = sale, Product = product } by sale.SoldAt.Date into salesByDate
        select new DaySales
        {
            Date = salesByDate.Key,
            TotalAmountSold = salesByDate.Sum(sale => sale.Sale.Amount * sale.Product.Price)
        };

        List<DaySales> salesByDayList = salesByDay.ToList();
        return salesByDayList;
    }
    public class DaySales
    {
        public DateTime Date { get; set; }
        public float TotalAmountSold { get; set; }
    }
    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
