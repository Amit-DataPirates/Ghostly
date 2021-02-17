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
    public class ModifierController : Controller
    {
        private IModifierRepository modifierRepository;
        public ModifierController(IModifierRepository _modifierRepository) //Constructor Dependency Injection
        {
            modifierRepository = _modifierRepository;
        }
        // GET: Modifier
        public ActionResult GetAllModifiers(string Sorting_Order, string Search_Data, string Filter_Value, int? Page_No)
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
            var modifier = from s in modifierRepository.GetAllModifiers()
                           select s;
            if (!String.IsNullOrEmpty(Search_Data))
            {
                modifier = modifier.Where(s => s.date_creation.ToString().Contains(Search_Data.ToUpper())
                                       || s.Quantity.ToString().Contains(Search_Data.ToUpper()));


            }

            //IEnumerable<ModifierModel> listOfModifiers = modifierRepository.GetAllModifiers();

            int Size_Of_Page = 10;
            int No_Of_Page = (Page_No ?? 1);

            return View(modifier.ToPagedList(No_Of_Page, Size_Of_Page));

        }
        [HttpGet]
        public ActionResult AddModifier()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddModifier(ModifierModel objModifier)
        {
            objModifier.ModifierId = Guid.NewGuid();

            modifierRepository.AddModifier(objModifier);
            return RedirectToAction("GetAllModifiers");

        }
        public ActionResult Update(Guid id)
        {

            return View(modifierRepository.Detail(id));
        }
        [HttpPost]
        public ActionResult Update(ModifierModel modifierModel)
        {
            modifierRepository.Update(modifierModel);
            //var recipieID = modifierRepository.GetModifiersByID();
            return RedirectToAction("GetAllModifiers");

        }
        public ActionResult Detail(Guid id)
        {

            //recipeRepository.Detail(id);
            return View(modifierRepository.Detail(id));
        }

        public ActionResult Delete(Guid? ModifierId)
        {
            return View();
        }
        [HttpPost]
        public ActionResult Delete(Guid id)
        {
            modifierRepository.Delete(id);
            return RedirectToAction("GetAllModifiers");
        }
    }
}