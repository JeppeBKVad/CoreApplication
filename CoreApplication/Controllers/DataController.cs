// using System.Diagnostics;
// using Microsoft.AspNetCore.Mvc;
// using CoreApplication.Models;

// namespace CoreApplication.Controllers;
// public class DataController : Controller
// {
//     public IActionResult GetSpecificProduct(string productName, DateTime startDate, DateTime endDate)
//     {
//         var data = SaleModel.findSales(productName);
//         return Ok(data);
//     }

//     public List<DaySales> TotalNetto()
//     {
//         var sales = SaleModel.getTotal();
//         var productData = ProductModel.getTotal();

//         var salesByDay = from sale in sales
//         join product in productData on sale.Product equals product.Id
//         group new { Sale = sale, Product = product } by sale.SoldAt.Date into salesByDate
//         select new DaySales
//         {
//             Date = salesByDate.Key,
//             TotalAmountSold = salesByDate.Sum(sale => sale.Sale.Amount * sale.Product.Price)
//         };

//         List<DaySales> salesByDayList = salesByDay.ToList();
//         return salesByDayList;
//     }
//     class DaySales
//     {
//         public DateTime Date { get; set; }
//         public float TotalAmountSold { get; set; }
//     }
// }