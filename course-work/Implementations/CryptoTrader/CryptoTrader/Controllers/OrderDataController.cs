using CryptoTrader.Data;
using CryptoTrader.Models.DTOs;
using CryptoTrader.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CryptoTrader.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDataController : ControllerBase
    {
        private readonly CryptoDbContext cryptoDbContext;

        public OrderDataController(CryptoDbContext cryptoDbContext)
        {
            this.cryptoDbContext = cryptoDbContext;
        }

        [HttpGet]
        public IActionResult GetAllOrderData()
        {
            var result = cryptoDbContext.OrderDatas.ToList();
            return Ok(result);
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetOrderDataById(int id)
        {
            var result = cryptoDbContext.OrderDatas.Find(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddOrderData(OrderDTO orderDTO)
        {
            var traderIdFind = orderDTO.TraderId;
            var result = cryptoDbContext.TraderDatas.Find(traderIdFind);
            if (result == null) { return NotFound("Wrong TraderId"); }

            var cryptoIdFind = orderDTO.CryptoId;
            var result2 = cryptoDbContext.CryptoDatas.Find(cryptoIdFind);
            if (result2 == null) { return NotFound("Wrong CryptoId"); }

            var orderEntity = new OrderData()
            {
                Title = orderDTO.Title,
                Description = orderDTO.Description,
                TraderId = orderDTO.TraderId,
                CryptoId = orderDTO.CryptoId,
                ValueSum = orderDTO.Value,
                CreatedOn = DateTime.Now,
            };
            cryptoDbContext.OrderDatas.Add(orderEntity);
            cryptoDbContext.SaveChanges();
            return Ok(orderEntity);
        }


        [HttpPut]
        [Route("{id:int}")]
        public IActionResult UpdateOrderData(int id, UpdateOrderDataDTO updateOrderDataDTO)
        {
            var orderEntity = cryptoDbContext.OrderDatas.Find(id);
            if (orderEntity == null)
            {
                return NotFound();
            }
            orderEntity.Title = updateOrderDataDTO.Title;
            orderEntity.Description = updateOrderDataDTO.Description;
            orderEntity.TraderId = updateOrderDataDTO.TraderId;
            orderEntity.CryptoId = updateOrderDataDTO.CryptoId;
            orderEntity.CryptoId = updateOrderDataDTO.CryptoId;
            orderEntity.ValueSum = updateOrderDataDTO.Value;
            orderEntity.UpdatedOn = DateTime.Now;

            cryptoDbContext.SaveChanges();
            return Ok(orderEntity);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult DeleteOrderData(int id)
        {
            var result = cryptoDbContext.OrderDatas.Find(id);
            if (result is null)
            {
                return NotFound();
            }
            cryptoDbContext.OrderDatas.Remove(result);
            cryptoDbContext.SaveChanges();
            return Ok("Deleted");
        }
    }

}