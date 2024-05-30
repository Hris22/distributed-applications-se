using CryptoTrader.Data;
using CryptoTrader.Models.DTOs;
using CryptoTrader.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CryptoTrader.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CryptoDataController : ControllerBase
    {

        private readonly CryptoDbContext cryptoDbContext;

        public CryptoDataController(CryptoDbContext cryptoDbContext)
        {
            this.cryptoDbContext = cryptoDbContext;
        }
        [HttpGet]
        public IActionResult GetAllCryptoData()
        {
            var result = cryptoDbContext.CryptoDatas.ToList();
            return Ok(result);
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetCryptoDataById(int id)
        {
            var result = cryptoDbContext.CryptoDatas.Find(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddCryptoData(CryptoDTO cryptoDTO)
        {
            var cryptoEntity = new CryptoData()
            {
                Name = cryptoDTO.Name,
                Value = cryptoDTO.Value,
                CreatedOn = DateTime.Now,
                UpdatedOn = DateTime.Now
            };
            cryptoDbContext.CryptoDatas.Add(cryptoEntity);
            cryptoDbContext.SaveChanges();
            return Ok(cryptoEntity);
        }

        [HttpPut]
        [Route("{id:int}")]
        public IActionResult UpdateCryptoData(int id, UpdateCryptoDataDTO updateCryptoDataDTO)
        {
            var cryptoEntity = cryptoDbContext.CryptoDatas.Find(id);
            if (cryptoEntity == null)
            {
                return NotFound();
            }
            cryptoEntity.Name = updateCryptoDataDTO.Name;
            cryptoEntity.Value = updateCryptoDataDTO.Value;
            cryptoEntity.UpdatedOn = DateTime.Now;

            cryptoDbContext.SaveChanges();
            return Ok(cryptoEntity);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult DeleteCryptoData(int id)
        {
            var result = cryptoDbContext.CryptoDatas.Find(id);
            if (result is null)
            {
                return NotFound();
            }
            cryptoDbContext.CryptoDatas.Remove(result);
            cryptoDbContext.SaveChanges();
            return Ok("Deleted");
        }

       
    }
}
