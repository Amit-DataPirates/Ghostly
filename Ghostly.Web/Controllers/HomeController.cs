using Ghostly.Business;
using Ghostly.Business.Services.Interfaces;
using Ghostly.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;

namespace Ghostly.Web.Controllers
{
    public class HomeController : Controller

    {
        private IRecipeRepository recipeRepository;
        
        public HomeController(IRecipeRepository _recipeRepository) //Constructor Dependency Injection
        {
            recipeRepository = _recipeRepository;
        }
        // GET: Home
        public ActionResult GetAllRecipe(string Sorting_Order, string Search_Data, string Filter_Value, int? Page_No)
        {
            ViewBag.ProductName = Sorting_Order;

            if (Search_Data != null)
            {
                Page_No = 1;
            }
            else
            {
                Search_Data = Filter_Value;
            }

            ViewBag.FilterValue = Search_Data;
            var recipe = from s in recipeRepository.GetAll()
                         select s;
            if (!String.IsNullOrEmpty(Search_Data))
            {
                recipe = recipe.Where(s => s.ProductName.ToUpper().Contains(Search_Data.ToUpper())
                                       || s.date_creation.ToString().Contains(Search_Data.ToUpper())
                                       || s.Variation.ToUpper().Contains(Search_Data.ToUpper()));

            }

            //IEnumerable<RecipeModel> listOfRecipe = recipeRepository.GetAll();

            //if (!String.IsNullOrEmpty(Search_Data))
            //{
            //    var recipes = RecipeModel.Recipe.Where(i => i.ProductName.ToUpper().Contains(Search_Data.ToUpper()));

            //}
            //if (!String.IsNullOrEmpty(Search_Data))
            //       {
            //    //var RecipeModel= recipe.ProductName.Where(recipe=> recipe.)
            //    //RecipeModel = recipe..Where(i => i.Name.ToUpper().Contains(Search_Data.ToUpper())
            //    //   || i.Category.ToUpper().Contains(Search_Data.ToUpper()));
            //    //var RecipeModel= recipe1.Recipes.Where(i=> i.)

            //}
            int Size_Of_Page = 10;
            int No_Of_Page = (Page_No ?? 1);

            return View(recipe.ToPagedList(No_Of_Page, Size_Of_Page));

        }
        [HttpGet]
        public ActionResult AddRecipe()
        {
            return View();
        }
        public ActionResult AddRecipe(RecipeModel objRecipe)
        {
            objRecipe.RecipeId = Guid.NewGuid();

            recipeRepository.AddRecipe(objRecipe);
            return RedirectToAction("GetAllRecipe");

        }
        public ActionResult Update(Guid id)
        {

            return View(recipeRepository.Detail(id));
        }
        [HttpPost]
        public ActionResult Update(RecipeModel recipeModel)
        {
            recipeRepository.Update(recipeModel);
            return RedirectToAction("GetAllRecipe");
        }



        //[HttpPost]
        public ActionResult Detail(Guid id)
        {

            //recipeRepository.Detail(id);
            return View(recipeRepository.Detail(id));
        }

        public ActionResult Delete(Guid? RecipeId)
        {
            return View();
        }
        [HttpPost]
        public ActionResult Delete(Guid id)
        {
            recipeRepository.Delete(id);
            return RedirectToAction("GetAllRecipe");
        }
    }
}