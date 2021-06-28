using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tutorial5.Models;

namespace Tutorial5.WareHouseData
{
    public interface IDBServices
    {
        Task<int> PostWarehouseAsync(WareHouse wareHouse);
    }
}
