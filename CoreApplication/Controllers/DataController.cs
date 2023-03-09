using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CoreApplication.Models;

namespace CoreApplication.Controllers;
public class DataController : Controller
{
    public IActionResult GetSpecificProduct(string productName, DateTime startDate, DateTime endDate)
    {
        var data = SaleModel.findSales(productName);
        return Ok(data);
    }
}