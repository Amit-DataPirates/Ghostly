using Ghostly.Business.Services.Interfaces;
using Ghostly.DAL.SQL;
using Ghostly.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Recipe = Ghostly.DAL.SQL.Recipe;

namespace Ghostly.Business
{
    public class RecipeRepository : IRecipeRepository
    {
        private GhostlyXEntities1 db;

        public RecipeRepository()
        {
            db = new GhostlyXEntities1();
        }
        IEnumerable<RecipeModel> IRecipeRepository.GetAll()
        {
            IEnumerable<RecipeModel> listOfRecipe = (from objRecipe in db.Recipes
                                                     select new RecipeModel()
                                                     {
                                                         RecipeId = objRecipe.RecipeId,
                                                         ProductName = objRecipe.ProductName,
                                                         Variation = objRecipe.Variation,
                                                         CurrentPrice = objRecipe.CurrentPrice,
                                                         LastCost = objRecipe.LastCost,
                                                         Description = objRecipe.Description,
                                                         StandardRecipeId = objRecipe.StandardRecipeId,
                                                         OperatorId = objRecipe.OperatorId,
                                                         OperatorLocationId = objRecipe.OperatorLocationId,
                                                         date_creation = objRecipe.date_creation,
                                                         created_by = objRecipe.created_by,
                                                         modified_by = objRecipe.modified_by,
                                                         date_modified = objRecipe.date_modified
                                                     }).ToList();
            return listOfRecipe;
        }
        public void AddRecipe(RecipeModel recipeModel)
        {
            Recipe objRecipe = new Recipe()
            {
                RecipeId = recipeModel.RecipeId,
                ProductName = recipeModel.ProductName,
                Variation = recipeModel.Variation,
                CurrentPrice = recipeModel.CurrentPrice,
                LastCost = recipeModel.LastCost,
                Description = recipeModel.Description,
                StandardRecipeId = recipeModel.StandardRecipeId,
                OperatorId = recipeModel.OperatorId,
                OperatorLocationId = recipeModel.OperatorLocationId,
                date_creation = recipeModel.date_creation,
                created_by = recipeModel.created_by,
                modified_by = recipeModel.modified_by,
                date_modified = recipeModel.date_modified
            };
            db.Recipes.Add(objRecipe);
            db.SaveChanges();
        }
         public RecipeModel Detail(Guid RecipeId)
        {
         
            //return db.Recipe.Find(RecipeId);

            var objRecipe = db.Recipes.Find(RecipeId);
            
            RecipeModel recipeModel = new RecipeModel();
            recipeModel.RecipeId = objRecipe.RecipeId;
            recipeModel.ProductName = objRecipe.ProductName;
            recipeModel.Variation = objRecipe.Variation;
            recipeModel.CurrentPrice = objRecipe.CurrentPrice;
            recipeModel.LastCost = objRecipe.LastCost;
            recipeModel.Description = objRecipe.Description;
            recipeModel.StandardRecipeId = objRecipe.StandardRecipeId;
            recipeModel.OperatorId = objRecipe.OperatorId;
            recipeModel.OperatorLocationId = objRecipe.OperatorLocationId;
            recipeModel.date_creation = objRecipe.date_creation;
            recipeModel.created_by = objRecipe.created_by;
            recipeModel.modified_by = objRecipe.modified_by;
            recipeModel.date_modified = objRecipe.date_modified;
            
            
            return recipeModel;
        }
        public void Delete(Guid? RecipeId)
        {
            var objRecipe = db.Recipes.Find(RecipeId);
            db.Recipes.Remove(objRecipe);
            db.SaveChanges();
        }

      
        public void Update(RecipeModel recipeModel)
        {
            var objRecipe = db.Recipes.Find(recipeModel.RecipeId);
            objRecipe.ProductName = recipeModel.ProductName;
            objRecipe.Variation = recipeModel.Variation;
            objRecipe.CurrentPrice = recipeModel.CurrentPrice;
            objRecipe.LastCost = recipeModel.LastCost;
            objRecipe.Description = recipeModel.Description;
            objRecipe.StandardRecipeId = recipeModel.StandardRecipeId;
            objRecipe.OperatorId = recipeModel.OperatorId;
            objRecipe.OperatorLocationId = recipeModel.OperatorLocationId;
            objRecipe.date_creation = recipeModel.date_creation;
            objRecipe.created_by = recipeModel.created_by;
            objRecipe.modified_by = recipeModel.modified_by;
            objRecipe.date_modified = recipeModel.date_modified;
            db.Recipes.Add(objRecipe);
            db.Entry(objRecipe).State = EntityState.Modified;
            db.SaveChanges();
        }
    } 
}
