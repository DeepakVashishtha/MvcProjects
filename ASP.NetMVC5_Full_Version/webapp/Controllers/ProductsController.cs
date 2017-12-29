using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartAdminMvc.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
       
        public ActionResult categories()
        {
            using (var context = new Models.DbEntity.GreenFieldEntities())
            {
                var listAllCategories = context.USP_Categories_All().ToList();
                return View(listAllCategories);
            }
        }

        public ActionResult add_categories()
        {
            Models.DbEntity.Category category = new Models.DbEntity.Category();
            return View(category);
        }
        [HttpPost]
        public ActionResult add_categories(Models.DbEntity.Category category,string btnText)
        {
            ObjectParameter CategoryID = new ObjectParameter("CategoryID", typeof(global::System.Int32));
            using (var context = new Models.DbEntity.GreenFieldEntities())
            {
                context.USP_Categories_Insert(category.CategoryName, category.Description, CategoryID);
            }
            TempData["CategoryID"] = CategoryID.Value;
            if (TempData["CategoryID"] != null)
            {
                TempData["Message"] = "Save Successfully.";
            }
            else
            {
                TempData["Message"] = "Error Occured!!";
            }
            if (btnText == "Save")
            {
                return RedirectToAction("categories");
            }
            else if (btnText == "SaveAddMore")
            {
                return RedirectToAction("add_categories");
            }
            return View();

        }
        public ActionResult edit_categories(int id)
        {
            using (var context = new Models.DbEntity.GreenFieldEntities())
            {
                var category = context.USP_Categories_Get(id).SingleOrDefault();
                return View(category);
            }
        }
        [HttpPost]
        public ActionResult edit_categories(Models.DbEntity.Category category)
        {
            using (var context = new Models.DbEntity.GreenFieldEntities())
            {
                context.USP_Categories_Update(category.CategoryID, category.CategoryName, category.Description);
                TempData["Message"] = "Update Successfully.";
                return RedirectToAction("categories");
            }
        }

        public ActionResult delete_categories(int id)
        {
            using (var context = new Models.DbEntity.GreenFieldEntities())
            {
                context.USP_Categories_Delete(id);
                TempData["Message"] = "Delete Successfully.";
                return RedirectToAction("categories");
            }
        }
    }
}