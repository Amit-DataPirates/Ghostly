//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Ghostly.DAL.SQL
{
    using System;
    using System.Collections.Generic;
    
    public partial class PriceCostVariation
    {
        public long PriceCostVarId { get; set; }
        public Nullable<System.Guid> ProcessIngredientId { get; set; }
        public Nullable<System.Guid> IngredientId { get; set; }
        public Nullable<System.Guid> RecipeIngredientId { get; set; }
        public Nullable<System.Guid> RecipeId { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<decimal> Cost { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public Nullable<System.Guid> POIid { get; set; }
    
        public virtual Ingredient Ingredient { get; set; }
        public virtual ProcessIngredient ProcessIngredient { get; set; }
        public virtual PurchaseOrderInvoice PurchaseOrderInvoice { get; set; }
        public virtual Recipe Recipe { get; set; }
        public virtual RecipesIngredient RecipesIngredient { get; set; }
    }
}
