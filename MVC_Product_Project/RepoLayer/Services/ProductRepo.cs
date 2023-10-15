using CommonLayer.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using RepoLayer.Context;
using RepoLayer.Entities;
using RepoLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RepoLayer.Services
{
    public class ProductRepo : IProductRepo
    {
        private readonly ProductDbContext dbContext;
        public ProductRepo(ProductDbContext context)
        {
            this.dbContext = context;
        }

        //Method for Adding Products  
        public string AddProduct(ProductModel models)
        {
            try
            {
                this.dbContext.AddDetails(models);
                this.dbContext.SaveChanges();
                return "Excution Done";
            }
            catch (Exception)
            {
                throw new Exception("Error while Adding");
            }
        }

        public List<UserProductEntity> GetAllProducts()
        {
            try
            {
                List<UserProductEntity> allUsers = this.dbContext.UserProducts.FromSqlRaw("EXEC Sp_GetAllProducts").ToList();
                return allUsers;
            }
            catch (Exception)
            {
                throw new Exception("Exception Occurred while Fetching All User Data");
            }
        }
        public bool DeleteProduct(int productId)
        {
            try
            {
                bool result = dbContext.RemoveProduct(productId);

                return true;
            }
            catch (Exception)
            {
                throw new Exception("Excption Thrwoing while Deleting");
            }
        }
    }
}
