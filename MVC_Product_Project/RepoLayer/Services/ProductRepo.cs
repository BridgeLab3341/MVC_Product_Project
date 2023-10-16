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
        //Summary
        //Method for Adding Products.
        //AddDetails Method calling from the DbContext to Add the Products into Database
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
        //Summary
        //Fetching All the Data from the DataBase using FromSqlRaw
        //We are Using Stored procedure for Fetching the Data 
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
        //Summary
        //Delete the Product By Id 
        //Fetching Product ID by using the Context and Entity Model and
        //Deleting the Product .
        public bool DeleteProduct(int productId)
        {
            try
            {
                //RemoveProduct method is fetching from DbContext file to Delete
                bool result = dbContext.RemoveProduct(productId);

                return true;
            }
            catch (Exception)
            {
                throw new Exception("Excption Thrwoing while Deleting");
            }
        }
        public string UpdateProduct(ProductModel product)
        {
            // Retrieve the existing product from the database
            var existingProduct = dbContext.UserProducts.FirstOrDefault(p => p.ProductId == product.ProductId);

            // If the existing product is found, update its properties
            if (existingProduct != null)
            {
                existingProduct.Code = product.Code;
                existingProduct.Name = product.Name;
                existingProduct.Description = product.Description;
                existingProduct.ExpiryDate = product.ExpiryDate;
                existingProduct.Category = product.Category;
                existingProduct.Image = product.Image;
                existingProduct.Status = product.Status;
                existingProduct.CreationDate = product.CreationDate;

                // Save changes to the database
                dbContext.SaveChanges();
                return "Updated Successfully";
            }
            else
            {
                // Handle the case where the product is not found (optional)
                throw new Exception("Product not found");
            }
        }
    }
}
