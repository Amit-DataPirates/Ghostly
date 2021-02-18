using Ghostly.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ghostly.Business.Services.Interfaces
{
     public interface IIngredientRepository
    {
        IEnumerable<IngredientModel> GetAllIngredients();
        void AddIngredient(IngredientModel ingredientModel);
        IngredientModel Detail(Guid IngredientId);
        void Update(IngredientModel ingredientModel);
        void Delete(Guid? IngredientId);
        

        //hye
    }
}
