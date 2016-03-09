using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace WebshopBackend.Models
{
    /**
    *  List<> GetAllCategories()
    *  Category GetCategory(int id)
    */

    
    public class CategoryModel
    {
        public List<Category> GetAllCategory() {
            List<Category> ListCategories = new List<Category>();

            //hämta från databas
            //spara ner i ListCategories

            for (int i = 0; i <= 10; i++) {
                ListCategories.Add(new Category(i, "namn" + i, "beskrivning" + i));
            }

            return ListCategories;
        }

        public Category GetCategoryById(int id) {
            Category CategoryObject = new Category(1, "Byxor", "Mjukisbyxor, jeans osv");

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