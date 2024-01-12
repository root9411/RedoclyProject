using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Redocly.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        /// <summary>
        /// This API is for Get the Order
        /// <param name="id">this is the parameter of order API</param>
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        public async Task<IActionResult> Order(int id)
        {

            var order = new Order()
            {
                Id = 1,
                OrderId = 2150,
                OrderValue = "5",
                CustomerName = "Ayan Shah",
                Address = "New Delhi"
            };


            if(order.Id == id)
            {
                return Ok(order);
            }

            return BadRequest();



        }


        /// <summary>
        /// Get an order by Order ID
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns>The order object</returns>
        [HttpGet("GetOrder")]
        [SwaggerOperation(
            Summary = "Get an order by Order ID",
            Description = "Use the endpoint to request an order by it's Order ID.",
            OperationId = "GetOrder",
            Tags = new[] { "Order" })]
        [SwaggerResponse(200, "The requested order", type: typeof(Order))]
        public ActionResult<Order> GetOrder([FromQuery, SwaggerParameter("Order ID", Required = true)] int orderId)
        {
            List<Order> orders = new List<Order>();

            orders.Add(new Order
            {
                Id = 1,
                OrderId = 8427,
                CustomerName = "Christian Schou",
                Address = "Some Address here",
                OrderValue = "87429,8236 DKK"
            });
            orders.Add(new Order
            {
                Id = 1,
                OrderId = 3265,
                CustomerName = "John Doe",
                Address = "Johns address here",
                OrderValue = "236,255 DKK"
            });

            return StatusCode(StatusCodes.Status200OK, orders.FirstOrDefault(x => x.OrderId == orderId));
        }
    }
}
