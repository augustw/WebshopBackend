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

        [Route("~/api/getallproduct")]
        public List<Product> GetAllProduct()
        {
            return model.GetAllProduct();
        }

        [Route("~/api/getallsaleproduct")]
        public List<Product> GetAllSaleProduct() {
            return model.GetAllSaleProduct();
        }

        [Route("~/api/getproductbycategory/{categoryId}")]
        public List<Product> GetProductByCategory(int categoryId)
        {
            return model.GetProductByCategory(categoryId);
        }

        [Route("~/api/getproductbyid/{productId}")]
        public Product GetProductById(int productId) {
            return model.GetProductById(productId);
        }

    }
}
