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
        [Route("~/api/getallcategory")]
        public List<Category> Get() {
            List<Category> AllCategories = model.GetAllCategory();
            return AllCategories;
        }

        //gets one category by id
        [Route("~/api/getcategorybyid")]
        public Category Get(int id) {
            return model.GetCategoryById(id);
        }

       
    }
}
