using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Tutorial5.Models;
using Tutorial5.WareHouseData;

namespace Tutorial5.Controllers
{
    [Route("Api/[controller]")]
    [ApiController]
    public class WareHouse2Controller : ControllerBase
    {
        private readonly IDbService2 _dbService2;

        public WareHouse2Controller(IDbService2 dbService2)
        {
            _dbService2 = dbService2;
        }

        [HttpPost]
        public async Task<IActionResult> PostWarehouseByStoredProcedureAsync(WareHouse wh)
        {
            int IdProductWarehouse;
            try
            {
                IdProductWarehouse = await _dbService2.PostWarehouseByStoredProcedureAsync(wh);
            }
            catch (Exception ) { 
                return BadRequest("Enterd Data is not Valid"); 
            }
            return Ok("Succsesfull!");
        }
    } 
  
}
