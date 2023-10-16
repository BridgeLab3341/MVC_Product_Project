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
using MVC_Product_Project.Models;

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
        //Summary
        //In Index View we Fetching all Data from Database
        //Sorting,Searching by Filter method
        //Pagination for a pages
        public  IActionResult Index(string searchstring, string sorting, int pageNumer=1)
            {
            List<UserProductEntity> products = productRepo.GetAllProducts();

            //ViewData["CurrentSort"] = sorting;

            ////Search
            //if (!string.IsNullOrEmpty(searchstring))
            //{
            //    DateTime searchDate;
            //    if (DateTime.TryParse(searchstring, out searchDate))
            //    {
            //        products = products.Where(p => p.CreationDate.Date == searchDate.Date || p.ExpiryDate.Date == searchDate.Date).ToList();
            //    }
            //    else
            //    {
            //        products= products.Where(p => p.Code.Contains(searchstring)|| p.Name.Contains(searchstring) || p.Description.Contains(searchstring) || p.Category.Contains(searchstring)|| p.Status.Contains(searchstring)).ToList();
            //    }

            //}

            ////Sorting date 
            //switch (sorting)
            //{
            //    case "desc":
            //        products = products.OrderByDescending(p => p.CreationDate).ToList();
            //        break;
            //    case "asc":
            //        products = products.OrderBy(p => p.CreationDate).ToList();
            //        break;
            //    default:
            //        products = products.OrderByDescending(p => p.CreationDate).ToList();
            //        break;
            //}

            //pagination
            //int pageSize = 10;
            //int totalItems=products.Count();
            //int pageIndex = page ?? 1;
            ////creating pagination list
            //var paginatedProducts=PaginatedList<UserProductEntity>.Create(products.AsQueryable(), pageIndex, pageSize);

            return View(products);
            //return View(PaginatedList<UserProductEntity>.Create(products.AsQueryable(),pageNumer,5));
        }
        //Summary 
        //Add and Edit is Performing in only one Page by adding condition accroding to the code.
        //Fetching the Product data if it is present and Edit if not view new page to add Products.
        public IActionResult AddEdit(string code)
        {
           List<UserProductEntity> product = this.productRepo.GetAllProducts().ToList();
            UserProductEntity entity=product.SingleOrDefault(e=>e.Code== code);

            if (entity != null)
            {
                ProductModel model = new ProductModel
                {
                    ProductId = entity.ProductId,
                    Code = entity.Code,
                    Name = entity.Name,
                    Description = entity.Description,
                    ExpiryDate = entity.ExpiryDate,
                    Category = entity.Category,
                    Image = entity.Image,
                    Status = entity.Status,
                    CreationDate = entity.CreationDate
                };
                return View(model);
            }
            return View();
        }
        //Summary
        //Adding the Product Data into Add page and Fetching data added in to Index Page by Redirecting to Index Page
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
        //Summary
        //Delete the Product Data By using the Delete Method.
        //By Fetching the Data from UserEntity by ProductID and Deleting the Product.
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
