using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tutorial5.Models;
using Tutorial5.WareHouseData;

namespace Tutorial5.Controllers
{
    public class WarehouseController : ControllerBase
    {
        private readonly IDBServices _dbService;

        public WarehouseController(IDBServices _dbService)
        {
            this._dbService = _dbService;
        }

        [HttpPost]
        public async Task<IActionResult> PostWarehouseAsync(WareHouse wareHouse)
        {
            int IdProductWarehouse;
            try
            {
                IdProductWarehouse = await _dbService.PostWarehouseAsync(wareHouse);
            }
            catch (Exception)
            {
                return BadRequest("Enterd Data is not Valid");
            }
            return Ok("Succsesfull!");

        }
        
    }
}
