using CommonLayer.Models;
using RepoLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepoLayer.Interface
{
    public interface IProductRepo
    {
        public string AddProduct(ProductModel models);
        public List<UserProductEntity> GetAllProducts();
        public bool DeleteProduct(int productId);
    }
}
