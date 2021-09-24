using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PharmacyAPI.Helper;
using PharmacyAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyAPI.Controllers
{
    [ApiController]
    [Route("api/v1/ilaclar")]

    public class MedicineController : ControllerBase
    {
        private List<Medicine> _list = FakeDb.GetList();

        [HttpPost]
        public IActionResult Add([FromBody] Medicine medicine)
        {
            if (ModelState.IsValid) // Aslında controller ApiController attribute'una sahip olduğu için kontrolleri otomatik yapıyor yani tekrar kontrol etmemize gerek yok.
            {
                _list.Add(medicine);
                return CreatedAtAction("Get", new { id = medicine.Id }, medicine);
            }
            return BadRequest(ModelState);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Medicine result = _list.FirstOrDefault(m => m.Id == id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }


        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Medicine medicine)
        {
            Medicine result = _list.FirstOrDefault(m => m.Id == id);
            if (result != null)
            {
                result.Name = medicine.Name;
                result.Company = medicine.Company;
                result.UnitPrice = medicine.UnitPrice;
                result.UnitsInStock = medicine.UnitsInStock;
                result.ExpirationDate = medicine.ExpirationDate;
                result.Details = medicine.Details;
                return Ok(result);
            }

            return NotFound();

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Medicine result = _list.FirstOrDefault(m => m.Id == id);
            if (result != null)
            {
                _list.Remove(result);
                return NoContent();
            }

            return NotFound();
        }

        [HttpGet]
        [Route("[action]")] //  api/v1/ilaclar/List?list=Company="Y"
        public async Task<IActionResult> List([FromQuery] string list)
        {
            var data = _list.AsQueryable();
            data = data.FilterSource(list);
            return await Task.FromResult(Ok(data));
        }

        [HttpGet]
        [Route("[action]")] // /api/v1/ilaclar/Sort?sort=name
        public async Task<IActionResult> Sort([FromQuery] string sort)
        {
            var data = _list.AsQueryable();
            data = data.SortSource(sort);
            return await Task.FromResult(Ok(data));
        }

        //Sort ve List actionlarında var olmayan bir field yollandığında oluşan hatayı nasıl handle edebileceğimi bulamadığım için 500 döndürüyor.
    }
}
