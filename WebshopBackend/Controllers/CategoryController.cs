using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebshopBackend.Models;

namespace WebshopBackend.Controllers
{
    public class CategoryController : ApiController
    {
        private CategoryModel model = new CategoryModel();

        //gets all categories
        public List<Category> GetAll() {
            List<Category> AllCategories = model.GetAllCategory();
            return AllCategories;
        }

        //gets one category by id
        public Category GetById(int id) {
            return model.GetCategoryById(id);
        }

       
    }
}
