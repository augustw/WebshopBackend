using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using System.Data.SqlClient;

namespace WebshopBackend.Models
{
    /**
    *  List<> GetAllCategories()
    *  Category GetCategory(int id)
    */

    
    public class CategoryModel
    {
        Connect connect = new Connect();
        //hämtar alla kategorier från databas
        public List<Category> GetAllCategory() {
            List<Category> ListCategories = new List<Category>();
            
            //hämta från databas
            string query = "SELECT id, name, description FROM Category";

            using (SqlConnection connection = new SqlConnection(connect.getConnectionString())) {
                SqlCommand command = new SqlCommand(query, connection);
                try {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read()) {
                        ListCategories.Add(new Category(reader.GetInt32(0), reader.GetString(1), reader.GetString(2)));
                    }
                    reader.Close();
                }
                catch (Exception ex) {
                    Console.WriteLine(ex.Message);
                }
            } //end connection
              //spara ner i ListCategories


            return ListCategories;
        }

        public Category GetCategoryById(int id) {
            Category CategoryObject = null;

            //hämta från databas
            string query = "SELECT name, description FROM Category WHERE id=" + id;

            using (SqlConnection connection = new SqlConnection(connect.getConnectionString()))
            {
                SqlCommand command = new SqlCommand(query, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    CategoryObject = new Category(id, reader.GetString(0), reader.GetString(1));
                    
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            } //end connection
              //spara ner i ListCategories

            return CategoryObject;
        }

        
    }

    public class Category {
        public Category(int id, string name, string description) {
            Id = id;
            Name = name;
            Description = description;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}