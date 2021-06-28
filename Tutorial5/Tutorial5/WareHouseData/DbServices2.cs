using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Tutorial5.Models;

namespace Tutorial5.WareHouseData
{
   
    public class DbServices2 : IDbService2
    {
        private readonly string  DataString = "Data Source=db-mssql;Initial Catalog=s20985;Integrated Security=True";
        public async Task<int> PostWarehouseByStoredProcedureAsync(WareHouse wareHouse)
        {
            using var con = new SqlConnection(DataString);
            using var com = new SqlCommand("AddProductToWarehouse", con);
            var trans = (SqlTransaction)await con.BeginTransactionAsync();
            com.Transaction = trans;

            try
            {
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@IdProduct", wareHouse.IdProduct);
                com.Parameters.AddWithValue("@IdWarehouse", wareHouse.IdWarehouse);
                com.Parameters.AddWithValue("@Amount", wareHouse.Amount);
                com.Parameters.AddWithValue("@CreatedAt", wareHouse.CreatedAt);
                await con.OpenAsync();

                int PostProduct = await com.ExecuteNonQueryAsync();

                await trans.CommitAsync();
            }
            catch (Exception)
            {
                await trans.RollbackAsync();
            }

            com.CommandType = CommandType.Text;
            com.CommandText = "select max(idproductwarehouse) from product_warehouse";

            using var dr = await com.ExecuteReaderAsync();

            await dr.ReadAsync();
            int IdProductWarehouse = int.Parse(dr["idproductwarehouse"].ToString());
            await dr.CloseAsync();

            await con.CloseAsync();
            return IdProductWarehouse;

        }
    }
}
