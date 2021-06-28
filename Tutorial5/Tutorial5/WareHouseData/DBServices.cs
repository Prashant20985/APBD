using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Tutorial5.Models;

namespace Tutorial5.WareHouseData
{
    public class DBServices : IDBServices
    {
        private readonly string DataString = "Data Source=db-mssql;Initial Catalog=s20985;Integrated Security=True";

        public async Task<int> PostWarehouseAsync(WareHouse wareHouse)
        {
            using var con = new SqlConnection(DataString);
            using var com = new SqlCommand();

            com.Connection = con;

            await con.OpenAsync();

            com.CommandText = $"select top 1 o.IdOrder from order o " +
                "Join Product_Warehouse pw ON o.IdOrder = pw.IdOrder " +
                "where o.IdProuct = @IdProduct " +
                "And o.Amount = @Amount " +
                "And pw.IdProductWarehouse = null " +
                "And o.CretedAt < @CreatedAt";

            com.Parameters.AddWithValue("@Amount", wareHouse.Amount);
            com.Parameters.AddWithValue("@IdProduct", wareHouse.IdProduct);
            com.Parameters.AddWithValue("@CreatedAt", wareHouse.CreatedAt);

            var dr = await com.ExecuteReaderAsync();

            if (!dr.HasRows) throw new Exception("INVALID PARAMETER!");

            await dr.ReadAsync();
            int Id_Order = int.Parse(dr["IdOrder"].ToString());
            await dr.CloseAsync();
            com.Parameters.Clear();


            com.CommandText = "Select price From Product where idProduct = @IdPoduct ";
            com.Parameters.AddWithValue("@idProduct", wareHouse.IdProduct);

            dr = await com.ExecuteReaderAsync();
            if (!dr.HasRows) throw new Exception("INVALID PARAMETER! : GIVEN IDPRODUCT NOT FOUND");

            await dr.ReadAsync();
            double price = double.Parse(dr["price"].ToString());
            await dr.CloseAsync();

            com.Parameters.Clear();


            var trans = (SqlTransaction) await con.BeginTransactionAsync();
            com.Transaction = trans;

            try
            {
                com.CommandText = $"update order SET FulfilledAt = @CreatedAt Where Idorder = @IdOrder ";
                com.Parameters.AddWithValue("@CreatedAt", wareHouse.CreatedAt);
                com.Parameters.AddWithValue("@IdOrder", Id_Order);

                int update = await com.ExecuteNonQueryAsync();

                com.Parameters.Clear();

                com.CommandText = $"Insert Into Product_Warehouse(IdWarehouse,IdProduct,IdOrder,Amount, Price, CreatedAt) " +
                    "Values (@IdWarehouse,@IdProduct,@IdOrder,@Amount, @Amount*{price}, @CreatedAt)  ";

                com.Parameters.AddWithValue("@IdWarehouse", wareHouse.IdWarehouse);
                com.Parameters.AddWithValue("@IdProduct", wareHouse.IdProduct);
                com.Parameters.AddWithValue("@IdOrder", Id_Order);
                com.Parameters.AddWithValue("@Amount", wareHouse.Amount);
                com.Parameters.AddWithValue("@CreatedAt", wareHouse.CreatedAt);

                int insert = await com.ExecuteNonQueryAsync();

                await trans.CommitAsync();
            }
            catch (Exception)
            {
                await trans.RollbackAsync();
            }
            com.Parameters.Clear();

            com.CommandText = "Select Max(IdProductWarehouse) from Product_Warehouse ";
            dr = await com.ExecuteReaderAsync();

            await dr.ReadAsync();
            int IdProductWarehouse = int.Parse(dr["IdProductWarehouse"].ToString());
            await dr.CloseAsync();
            await con.CloseAsync();

            return IdProductWarehouse;

        }
    }
}
