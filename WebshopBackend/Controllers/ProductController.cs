using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebshopBackend.Models;

namespace WebshopBackend.Controllers
{
    public class ProductController : ApiController
    {
        ProductModel model = new ProductModel();

        
        public List<Product> GetAll() {
            return model.GetAllProduct();
        }

        public List<Product> GetPopular() {
            return model.GetPopular();
        }
        public List<Product> GetAllSale() {
            return model.GetAllSaleProduct();
        }

        public List<CategoryProduct> GetCategoryProduct() {
            return model.GetCategoryProduct();
        }

        public List<Product> GetByCategoryId(int id) {
            return model.GetProductByCategoryId(id);
        }

        public Product GetById(int id) {
            return model.GetProductById(id);
        }

    }
}
