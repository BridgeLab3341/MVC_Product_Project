using CommonLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RepoLayer.Context;
using RepoLayer.Entities;
using RepoLayer.Interface;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using PagedList;
using PagedList.Mvc;
using Microsoft.Data.SqlClient;
using System.Threading.Tasks;

namespace MVC_Product_Project.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepo productRepo;
        private readonly ProductDbContext productDbContext;
        public ProductController(IProductRepo productRepo,ProductDbContext dbContext)
        {
            this.productRepo = productRepo;
            this.productDbContext = dbContext;
        }
        public  IActionResult Index(string searchstring, string sorting, int pg=1)
            {
            List<UserProductEntity> products = productRepo.GetAllProducts();

            ViewData["CurrentSort"] = sorting;
            //if(searchstring != null)
            //{
            //    pageNumber = 1;
            //}
            //else
            //{
            //    searchstring = currentFilter;   
            //}

            //Search
            if (!string.IsNullOrEmpty(searchstring))
            {
                DateTime searchDate;
                if (DateTime.TryParse(searchstring, out searchDate))
                {
                    products = products.Where(p => p.CreationDate.Date == searchDate.Date || p.ExpiryDate.Date == searchDate.Date).ToList();
                }
                else
                {
                    products= products.Where(p => p.Code.Contains(searchstring)|| p.Name.Contains(searchstring) || p.Description.Contains(searchstring) || p.Category.Contains(searchstring)|| p.Status.Contains(searchstring)).ToList();
                }

            }

            //Sorting date 
            switch (sorting)
            {
                case "desc":
                    products = products.OrderByDescending(p => p.CreationDate).ToList();
                    break;
                case "asc":
                    products = products.OrderBy(p => p.CreationDate).ToList();
                    break;
                default:
                    products = products.OrderByDescending(p => p.CreationDate).ToList();
                    break;
            }
            // Convert ProductEntity objects to ProductModel objects
            
            var userProducts = products.Select(ProductEntity => new ProductModel
            {
                //ProductId = ProductEntity.ProductId,
                Code = ProductEntity.Code,
                Name = ProductEntity.Name,
                Description = ProductEntity.Description,
                ExpiryDate = ProductEntity.ExpiryDate,
                Category = ProductEntity.Category,
                Image = ProductEntity.Image,
                Status = ProductEntity.Status,
                CreationDate = ProductEntity.CreationDate
            }).ToList();

            //pagination
            const int pageSize = 10;
            if(pg < 1)
                pg = 1;
            int recsCount = userProducts.Count();
            var pager =new PaginatedList(recsCount,pg,pageSize);
            int recSkip=(pg-1) * pageSize;
            this.ViewBag.PaginatedList = pager;
            var paginatedProducts = userProducts.Skip(recSkip).Take(pager.PageSize).ToList();

            //int pageSize = 10;
            //int pageNumberValue = pageNumber ?? 1;

            //var paginatedProducts = PaginatedList<ProductModel>.Create(userProducts.AsQueryable(), pageNumberValue, pageSize);

            //return View(paginatedProducts);

            return View(products);
        }
        public IActionResult AddEdit(string code)
        {
            UserProductEntity product = this.productRepo.GetAllProducts().FirstOrDefault(x=> x.Code == code);
           

            if(product != null)
            {
                return View(product);
            }
            return View();
        }
        [HttpPost]
        public IActionResult AddEdit(ProductModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    productRepo.AddProduct(model);
                    return RedirectToAction("Index");
                }
                return View(model);
            }
            catch
            {
                throw;
            }   
        }
        [HttpGet]
        public IActionResult Delete(int productId)
        {
            try
            {
                var productToDelete = productRepo.GetAllProducts().FirstOrDefault(x => x.ProductId == productId);
                if (productToDelete != null)
                {
                    var productRemove = productRepo.DeleteProduct(productToDelete.ProductId);
                }
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
              throw new Exception("Delete failed");
            }
        }
    }
}
