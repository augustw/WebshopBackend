using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebshopBackend.Models
{
    /**
    *  List<Product> GetAllProduct()
    *  List<Product> GetSaleProduct()
    *  List<Product> GetProductByCategory(int categoryID)
    *  Product GetProductById(int id)
    */
    public class ProductModel {
        List<Product> ListProduct = new List<Product>();
        Product ProductObject;

        //hämtar alla produkter från databasen
        public List<Product> GetAllProduct() {
            //do something
            ProductObject = new Product(1, 1, 500, 5, 6, "getallproductss", "hej");
            ListProduct.Add(ProductObject);
            return ListProduct;
        }

        //hämtar alla produkter där Sale inte är 0/tom
        public List<Product> GetAllSaleProduct() {
            //do something
            ProductObject = new Product(1, 1, 500, 5, 6, "saleee", "hej");
            ListProduct.Add(ProductObject);
            return ListProduct;
        }

        //hämtar alla produkter för en viss kategori
        public List<Product> GetProductByCategory(int categoryId) {
            //do something
            ProductObject = new Product(1, 1, 500, 5, 6, "bycategory", "hej");
            ListProduct.Add(ProductObject);
            return ListProduct;
        }

        //hämtar en produkt på id
        public Product GetProductById(int id) {
            //do something
            ProductObject = new Product(1, 1, 500, 5, 6, "byiiiddd", "hej");
            ListProduct.Add(ProductObject);

            return ProductObject;
        }
    }

    //klass för att skapa och hantera produktobjekt
    public class Product {

        public Product(int id, int categoryId, int price, int popularity, double sale, string name, string description) {
            Id = id;
            CategoryId = categoryId;
            Price = price;
            Popularity = popularity;
            Sale = sale;
            Name = name;
            Description = description;
        }

        public int Id { get; set; }
        public int CategoryId { get; set; }
        public double Price { get; set; }
        public int Popularity { get; set; }
        public double Sale { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}