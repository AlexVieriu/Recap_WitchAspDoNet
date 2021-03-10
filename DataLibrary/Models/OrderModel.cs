using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DataLibrary.Models
{
    public class OrderModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 3, ErrorMessage ="Number o characters must be between 3 and 20")]
        [DisplayName("Order Name")]
        public string OrderName { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;

        [Required]
        [Range(1, Int16.MaxValue, ErrorMessage = "You need to select a meal from the list")]
        public int FoodId { get; set; }

        [Required]
        [Range(1,10, ErrorMessage ="Pick a number between 1 and 10")]
        public int Quantity { get; set; }
        public decimal Total { get; set; }
    }
}
