using AutoMapper;
using Ghostly.Business.Services.Interfaces;
using Ghostly.DAL.SQL;
using Ghostly.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ghostly.Business
{
    public class IngredientsRepository : IIngredientRepository
    {
        private GhostlyXEntities db;

        public IngredientsRepository()
        {
            db = new GhostlyXEntities();
        }

        IEnumerable<IngredientModel> IIngredientRepository.GetAllIngredients()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Ingredient, IngredientModel>();
            });
            var IngredientList = from user in db.Ingredients
                                 select user;
            var ingredient = new List<IngredientModel>();
            if (IngredientList.Any())
            {
                foreach (var Ingredient in IngredientList)
                {
                    IMapper mapper = config.CreateMapper();
                    var source = new Ingredient();
                    var dest = mapper.Map<Ingredient, IngredientModel>(source);
                    IngredientModel ModelIngredient = mapper.Map<Ingredient, IngredientModel>(Ingredient);
                    ingredient.Add(ModelIngredient);
                }
            }
            return ingredient;
            //IEnumerable<IngredientModel> listOfIngredient = (from objIngredient in db.Ingredients
            //                                         select new IngredientModel()
            //                                         {
            //                                             IngredientId = objIngredient.IngredientId,
            //                                             Name = objIngredient.Name,
            //                                             Category = objIngredient.Category,
            //                                             //Type = objIngredient.Type,
            //                                             OperatorId = objIngredient.OperatorId,
            //                                             OperatorLocationId = objIngredient.OperatorLocationId,
            //                                             CommercialIngredientId = objIngredient.CommercialIngredientId,
            //                                             ProductionTimeHours = objIngredient.ProductionTimeHours,
            //                                             ProductionTimeDays = objIngredient.ProductionTimeDays,
            //                                             ProductionTimeMonths = objIngredient.ProductionTimeMonths,
            //                                             PerishabilityIndexHours = objIngredient.PerishabilityIndexHours,
            //                                             PerishabilityIndexDays = objIngredient.PerishabilityIndexDays,
            //                                             PerishabilityIndexMonths = objIngredient.PerishabilityIndexMonths,
            //                                             StorageCapacityInLiquid = objIngredient.StorageCapacityInLiquid,
            //                                             StorageCapacityInVolume = objIngredient.StorageCapacityInVolume,
            //                                             StorageUsedCapacityLiquid = objIngredient.StorageUsedCapacityLiquid,
            //                                             StorageUsedCapacityVolume = objIngredient.StorageUsedCapacityVolume,
            //                                             CurrentPrice = objIngredient.CurrentPrice,
            //                                             LastCost = objIngredient.LastCost,
            //                                             date_creation = objIngredient.date_creation,
            //                                             created_by = objIngredient.created_by,
            //                                             modified_by = objIngredient.modified_by,
            //                                             date_modified = objIngredient.date_modified
            //                                         }).ToList();
            //return listOfIngredient;
        }

        public void AddIngredient(IngredientModel ingredientModel)
        {
            Ingredient objIngredient = new Ingredient()
            {
                
                IngredientId = ingredientModel.IngredientId,
                Name = ingredientModel.Name,
                Category = ingredientModel.Category,
                //Type = ingredientModel.Type,
                OperatorId = ingredientModel.OperatorId,
                OperatorLocationId = ingredientModel.OperatorLocationId,
                CommercialIngredientId = ingredientModel.CommercialIngredientId,
                ProductionTimeHours = ingredientModel.ProductionTimeHours,
                ProductionTimeDays = ingredientModel.ProductionTimeDays,
                ProductionTimeMonths = ingredientModel.ProductionTimeMonths,
                PerishabilityIndexHours = ingredientModel.PerishabilityIndexHours,
                PerishabilityIndexDays = ingredientModel.PerishabilityIndexDays,
                PerishabilityIndexMonths = ingredientModel.PerishabilityIndexMonths,
                StorageCapacityInLiquid = ingredientModel.StorageCapacityInLiquid,
                StorageCapacityInVolume = ingredientModel.StorageCapacityInVolume,
                StorageUsedCapacityLiquid = ingredientModel.StorageUsedCapacityLiquid,
                StorageUsedCapacityVolume = ingredientModel.StorageUsedCapacityVolume,
                CurrentPrice = ingredientModel.CurrentPrice,
                LastCost = ingredientModel.LastCost,
                date_creation = ingredientModel.date_creation,
                created_by = ingredientModel.created_by,
                modified_by = ingredientModel.modified_by,
                date_modified = ingredientModel.date_modified

            };
            db.Ingredients.Add(objIngredient);
            db.SaveChanges();
        }

        public IngredientModel Detail(Guid IngredientId)
        {

            //return db.Recipe.Find(RecipeId);

            var Ingredient = db.Ingredients.Find(IngredientId);

            IngredientModel ingredientModel = new IngredientModel();
            
            ingredientModel.IngredientId = Ingredient.IngredientId;
            ingredientModel.Name = Ingredient.Name;
            ingredientModel.Category = Ingredient.Category;
            //ingredientModel.Type = Ingredient.Type;
            ingredientModel.OperatorId = Ingredient.OperatorId;
            ingredientModel.OperatorLocationId = Ingredient.OperatorLocationId;
            ingredientModel.CommercialIngredientId = Ingredient.CommercialIngredientId;
            ingredientModel.ProductionTimeHours = Ingredient.ProductionTimeHours;
            ingredientModel.ProductionTimeDays = Ingredient.ProductionTimeDays;
            ingredientModel.ProductionTimeMonths = Ingredient.ProductionTimeMonths;
            ingredientModel.PerishabilityIndexHours = Ingredient.PerishabilityIndexHours;
            ingredientModel.PerishabilityIndexDays = Ingredient.PerishabilityIndexDays;
            ingredientModel.PerishabilityIndexMonths = Ingredient.PerishabilityIndexMonths;
            ingredientModel.StorageCapacityInLiquid = Ingredient.StorageCapacityInLiquid;
            ingredientModel.StorageCapacityInVolume = Ingredient.StorageCapacityInVolume;
            ingredientModel.StorageUsedCapacityLiquid = Ingredient.StorageUsedCapacityLiquid;
            ingredientModel.StorageUsedCapacityVolume = Ingredient.StorageUsedCapacityVolume;
            ingredientModel.CurrentPrice = Ingredient.CurrentPrice;
            ingredientModel.LastCost = Ingredient.LastCost;
            ingredientModel.date_creation = Ingredient.date_creation;
            ingredientModel.created_by = Ingredient.created_by;
            ingredientModel.modified_by = Ingredient.modified_by;
            ingredientModel.date_modified = Ingredient.date_modified;

            return ingredientModel;
        }

        public void Delete(Guid? IngredientId)
        {
            var Ingredient = db.Ingredients.Find(IngredientId);
            db.Ingredients.Remove(Ingredient);
            db.SaveChanges();
        }


        public void Update(IngredientModel ingredientModel)
        {
            var Ingredient = db.Ingredients.Find(ingredientModel.IngredientId);
            Ingredient.IngredientId = ingredientModel.IngredientId;
            Ingredient.Name = ingredientModel.Name;
            Ingredient.Category = ingredientModel.Category;
            //Ingredient.Type = ingredientModel.Type;
            Ingredient.OperatorId = ingredientModel.OperatorId;
            Ingredient.OperatorLocationId = ingredientModel.OperatorLocationId;
            Ingredient.CommercialIngredientId = ingredientModel.CommercialIngredientId;
            Ingredient.ProductionTimeHours = ingredientModel.ProductionTimeHours;
            Ingredient.ProductionTimeDays = ingredientModel.ProductionTimeDays;
            Ingredient.ProductionTimeMonths = ingredientModel.ProductionTimeMonths;
            Ingredient.PerishabilityIndexHours = ingredientModel.PerishabilityIndexHours;
            Ingredient.PerishabilityIndexDays = ingredientModel.PerishabilityIndexDays;
            Ingredient.PerishabilityIndexMonths = ingredientModel.PerishabilityIndexMonths;
            Ingredient.StorageCapacityInLiquid = ingredientModel.StorageCapacityInLiquid;
            Ingredient.StorageCapacityInVolume = ingredientModel.StorageCapacityInVolume;
            Ingredient.StorageUsedCapacityLiquid = ingredientModel.StorageUsedCapacityLiquid;
            Ingredient.StorageUsedCapacityVolume = ingredientModel.StorageUsedCapacityVolume;
            Ingredient.CurrentPrice = ingredientModel.CurrentPrice;
            Ingredient.LastCost = ingredientModel.LastCost;
            Ingredient.date_creation = ingredientModel.date_creation;
            Ingredient.created_by = ingredientModel.created_by;
            Ingredient.modified_by = ingredientModel.modified_by;
            Ingredient.date_modified = ingredientModel.date_modified;

            db.Ingredients.Add(Ingredient);
            db.Entry(Ingredient).State = EntityState.Modified;
            db.SaveChanges();
        }

    }
}
