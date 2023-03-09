using Microsoft.AspNetCore.Mvc;
using CoreApplication.Models;
namespace CoreApplication.Endpoints
{
    [ApiController]
    [Route("api")]
    public class SalesUpload : ControllerBase
    {
        [HttpPost("uploadsales")]
        public IActionResult Upload([FromBody] SaleModel content, [FromHeader] AuthHeaderModel authentication)
        {
            if(!ApiUserModel.Verify(authentication.Authorization, DateTime.Now)) return Unauthorized("Authentication Failed");
            if(!SaleModel.InsertSale(content.Id, content.Product, content.Amount, content.SoldAt, content.AddedBy)) return BadRequest("Failed to upload");
            return Ok();
        }
        public class AuthHeaderModel
        {
            public string? Authorization { get; set; }
        }
    }

}