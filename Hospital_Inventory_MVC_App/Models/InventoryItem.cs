using System.ComponentModel.DataAnnotations;

namespace Hospital_Inventory_MVC_App.Models
{   public class InventoryItem
    {
        // Primary Key
        public int Id { get; set; }

        // Required Attributes
        [Required]
        [StringLength(100, ErrorMessage = "Department cannot be longer than 100 characters.")]
        public string Department { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "Name cannot be longer than 100 characters.")]
        public string Name { get; set; }
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Quantity cannot be negative.")]
        public int Quantity { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "UnitOfMeasure cannot be longer than 100 characters.")]
        public string UnitOfMeasure { get; set; }
        [Required]
        [Range(0.0, double.MaxValue, ErrorMessage = "PricePerUnit cannot be negative.")]
        public double PricePerUnit { get; set; }
        [Required]
        public double TotalPrice
        {
            get { return PricePerUnit * Quantity; }
        }
        [Required]
        public DateTime LastUpdated { get; set; } = DateTime.Now;
    }
}
  