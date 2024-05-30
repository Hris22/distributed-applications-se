using CryptoTrader.Data;
using CryptoTrader.Models.DTOs;
using CryptoTrader.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CryptoTrader.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TraderDataController : ControllerBase
    {
        private readonly CryptoDbContext cryptoDbContext;

        public TraderDataController(CryptoDbContext cryptoDbContext)
        {
            this.cryptoDbContext = cryptoDbContext;
        }

        [HttpGet]
        public IActionResult GetAllTraderData()
        {
            var result = cryptoDbContext.TraderDatas.ToList();
            return Ok(result);
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetTraderDataById(int id)
        {
            var result = cryptoDbContext.TraderDatas.Find(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddTraderData(TraderDTO traderDTO)
        {
            var traderEntity = new TraderData()
            {
                First_Name = traderDTO.First_Name,
                Last_Name = traderDTO.Last_Name,
                Age = traderDTO.Age,
                Nationality = traderDTO.Nationality,
                CreatedOn = DateTime.Now,
                UpdatedOn = DateTime.Now
            };
            cryptoDbContext.TraderDatas.Add(traderEntity);
            cryptoDbContext.SaveChanges();
            return Ok(traderEntity);
        }

        [HttpPut]
        [Route("{id:int}")]
        public IActionResult UpdateTraderData(int id, UpdateTraderDataDTO updateTraderDataDTO)
        {
            var traderEntity = cryptoDbContext.TraderDatas.Find(id);
            if (traderEntity == null)
            {
                return NotFound();
            }
            traderEntity.First_Name = updateTraderDataDTO.First_Name;
            traderEntity.Last_Name = updateTraderDataDTO.Last_Name;
            traderEntity.Age = updateTraderDataDTO.Age;
            traderEntity.Nationality = updateTraderDataDTO.Nationality;
            traderEntity.UpdatedOn = DateTime.Now;

            cryptoDbContext.SaveChanges();
            return Ok(traderEntity);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult DeleteTraderData(int id)
        {
            var result = cryptoDbContext.TraderDatas.Find(id);
            if (result is null)
            {
                return NotFound();
            }
            cryptoDbContext.TraderDatas.Remove(result);
            cryptoDbContext.SaveChanges();
            return Ok("Deleted");
        }
    }
}
