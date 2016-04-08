using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
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
        List<Product> listProduct = new List<Product>();
        Product ProductObject;
        Connect connect = new Connect();

        //hämtar alla produkter från databasen
        public List<Product> GetAllProduct() {
            return GetPlural("SELECT id, categoryId, price, popularity, sale, name, description, imageurl FROM Product");
        }

        //hämtar de 10 mest populära produkterna
        public List<Product> GetPopular() {
            return GetPlural("SELECT TOP 10 id, categoryId, price, popularity, sale, name, description, imageurl FROM Product ORDER BY popularity DESC");
        }

        //hämtar alla produkter där Sale inte är 0/tom
        public List<Product> GetAllSaleProduct() {
            return GetPlural("SELECT id, categoryId, price, popularity, sale, name, description, imageurl FROM Product WHERE sale > 0.00");
        }

        //hämtar alla produkter för en viss kategori
        public List<Product> GetProductByCategoryId(int categoryId) {
            return GetPlural("SELECT id, categoryId, price, popularity, sale, name, description, imageurl FROM Product WHERE categoryId=" + categoryId);
        }

        //hämtar en produkt på id
        public Product GetProductById(int id) {
            return GetSingular("SELECT id, categoryId, price, popularity, sale, name, description, imageurl FROM Product WHERE id = " + id);
        }

        public List<CategoryProduct> GetCategoryProduct() {
            
            
            CategoryModel categoryModel = new CategoryModel();
            var listCategory = categoryModel.GetAllCategory(); //hämta alla kategorier
            List<CategoryProduct> listReturn = new List<CategoryProduct>();
            foreach (Category category in listCategory) { //loopa in kategorier och produkter för varje kategori
                Debug.WriteLine("------------------" + category.Name);
                
                listReturn.Add(new CategoryProduct(category, GetProductByCategoryId(category.Id)));
            }
            
            
            return listReturn;
        }

        //klass som förenklar uthämtning av FLER ÄN EN produkt (i plural)
        public List<Product> GetPlural(string query) {
            
            List<Product> listPlural = new List<Product>();

            using (SqlConnection connection = new SqlConnection(connect.getConnectionString()))
            {
                SqlCommand command = new SqlCommand(query, connection);
                try {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read()) {
                    Debug.WriteLine(reader.GetString(5));
                    listPlural.Add(new Product(reader.GetInt32(0),
                                                reader.GetInt32(1),
                                                Convert.ToDecimal(reader[2]),
                                                reader.GetInt32(3),
                                                reader.GetDecimal(4),
                                                reader.GetString(5),
                                                reader.GetString(6),
                                                reader.GetString(7)));
                }
                reader.Close();
                }
                catch (Exception ex) {
                    Console.WriteLine(ex.Message);
                }
            } //end connection

            return listPlural;
        }

        public Product GetSingular(string query) {
            Product product = null;

            using (SqlConnection connection = new SqlConnection(connect.getConnectionString())){
                SqlCommand command = new SqlCommand(query, connection);
                try{
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    reader.Read();
                    Debug.WriteLine(reader.GetString(5));
                    product = new Product(reader.GetInt32(0),
                                            reader.GetInt32(1),
                                            Convert.ToDecimal(reader[2]),
                                            reader.GetInt32(3),
                                            reader.GetDecimal(4),
                                            reader.GetString(5),
                                            reader.GetString(6),
                                            reader.GetString(7));
                    
                    reader.Close();
                }
                catch (Exception ex) {
                    Console.WriteLine(ex.Message);
                }
            } //end connection

            return product;
        }
    }

    //klass för att skapa och hantera produktobjekt
    public class Product {

        public Product(int id, int categoryId, decimal price, int popularity, decimal sale, string name, string description, string imageurl) {
            Id = id;
            CategoryId = categoryId;
            Price = price;
            Popularity = popularity;
            Sale = sale;
            Name = name;
            Description = description;
            Imageurl = imageurl;
        }

        public int Id { get; set; }
        public int CategoryId { get; set; }
        public decimal Price { get; set; }
        public int Popularity { get; set; }
        public decimal Sale { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Imageurl { get; set; }
    }

    

    public class CategoryProduct
    {
        public CategoryProduct(Category cat, List<Product> listProduct)
        {
            Cat = cat;
            ListProduct = listProduct;
        }

        public Category Cat { get; set; }
        public List<Product> ListProduct { get; set; }
    }
}