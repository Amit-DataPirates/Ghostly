using Ghostly.Business.Services.Interfaces;
using Ghostly.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;

namespace Ghostly.Web.Controllers
{
    public class IngredientController : Controller
    {
        private IIngredientRepository ingredientRepository;

        public IngredientController(IIngredientRepository _ingredientRepository)
        {
            ingredientRepository = _ingredientRepository;
        }
        // GET: Ingredient
        public ActionResult GetAllIngredients(string Sorting_Order, string Search_Data, string Filter_Value, int? Page_No)
        {
            
            ViewBag.Name = Sorting_Order;

            if (Search_Data != null)
            {
                Page_No = 1;
            }
            else
            {
                Search_Data = Filter_Value;
            }

            ViewBag.FilterValue = Search_Data;
            var ingredients = ingredientRepository.GetAllIngredients();           
            if (!String.IsNullOrEmpty(Search_Data))
            {
                ingredients = ingredients.Where(x => !string.IsNullOrEmpty(x.Category) && x.Category.ToLower().Contains(Search_Data.Trim().ToLower()));
            }

            int Size_Of_Page = 10;
            int No_Of_Page = (Page_No ?? 1);

            return View(ingredients.ToPagedList( No_Of_Page, Size_Of_Page));
            
        }

        [HttpGet]
        public ActionResult AddIngredient()
        {
            return View();
        }
        public ActionResult AddIngredient(IngredientModel objIngredient)
        {
            objIngredient.IngredientId = Guid.NewGuid();

            ingredientRepository.AddIngredient(objIngredient);
            return RedirectToAction("GetAllIngredients");

        }
        public ActionResult Update(Guid id)
        {
            return View(ingredientRepository.Detail(id));
        }
        [HttpPost]
        public ActionResult Update(IngredientModel ingredientModel)
        {
            ingredientRepository.Update(ingredientModel);
            return RedirectToAction("GetAllIngredients");
        }

        //[HttpPost]
        public ActionResult Detail(Guid id)
        {
            return View(ingredientRepository.Detail(id));
        }

        public ActionResult Delete(Guid? IngredientId)
        {
            return View();
        }
        [HttpPost]
        public ActionResult Delete(Guid id)
        {
            ingredientRepository.Delete(id);
            return RedirectToAction("GetAllIngredients");
        }
    }
}