using CommonLayer.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using RepoLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepoLayer.Context
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> option) : base(option)
        {

        }
        public DbSet<UserProductEntity> UserProducts { get; set; }
        public void AddDetails(ProductModel model)
        {
            Database.ExecuteSqlRaw("EXEC Sp_InsertProduct @Code,@Name,@Description,@ExpiryDate,@Category,@Image,@Status",                
                new SqlParameter("@Code", model.Code),
                new SqlParameter("@Name", model.Name),
                new SqlParameter("@Description", model.Description),
                new SqlParameter("@ExpiryDate", model.ExpiryDate),
                new SqlParameter("@Category", model.Category),
                new SqlParameter("@Image", model.Image),
                new SqlParameter("@Status", model.Status),
                new SqlParameter("@CreationDate", model.CreationDate));
        }

        public bool RemoveProduct(int productId)
        {
            Database.ExecuteSqlRaw("sp_deleteproduct @productid",
                new SqlParameter("@productid", productId)
               );
            return true;
        }
    }
}
