using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ghostly.Models
{
    public class IngredientModel
    {
        public System.Guid IngredientId { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public Nullable<System.Guid> Type { get; set; }
        public Nullable<System.Guid> OperatorId { get; set; }
        public Nullable<System.Guid> OperatorLocationId { get; set; }
        public Nullable<System.Guid> CommercialIngredientId { get; set; }
        public Nullable<decimal> ProductionTimeHours { get; set; }
        public Nullable<decimal> ProductionTimeDays { get; set; }
        public Nullable<decimal> ProductionTimeMonths { get; set; }
        public Nullable<decimal> PerishabilityIndexHours { get; set; }
        public Nullable<decimal> PerishabilityIndexDays { get; set; }
        public string PerishabilityIndexMonths { get; set; }
        public Nullable<decimal> StorageCapacityInLiquid { get; set; }
        public Nullable<decimal> StorageCapacityInVolume { get; set; }
        public Nullable<decimal> StorageUsedCapacityLiquid { get; set; }
        public Nullable<decimal> StorageUsedCapacityVolume { get; set; }
        public Nullable<decimal> CurrentPrice { get; set; }
        public Nullable<decimal> LastCost { get; set; }
        public Nullable<System.DateTime> date_creation { get; set; }
        public Nullable<System.Guid> created_by { get; set; }
        public Nullable<System.Guid> modified_by { get; set; }
        public Nullable<System.DateTime> date_modified { get; set; }

        [MetadataType(typeof(IngredientModel))]
        public partial class Ingredient
        {

        }
    }
}
