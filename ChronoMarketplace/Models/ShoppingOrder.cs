using ChronoMarketplace.Areas.Identity.Data;
using ChronoMarketplace.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChronoMarketplace.Models
{
    public enum Status
    {
        Incompleted,
        InProgress,
        Completed
    }
    public class ShoppingOrder
    {

        [Key]
        [Display(Name = "Shopping Order ID")]
        public int ShoppingOrderId { get; set; } //Primary Key 

        public int CustomerId { get; set; } //Foreign Key to Customers Table

        public int PaymentId { get; set; } //Foreign Key to Payments Table
         
        [Display(Name = "Customer")]
        public string ShoppingFirstName { get; set; }
       
        [Required]
        [DisplayName("Order Date")]
        [DataType(DataType.Date)]
        public DateTime Orderdate { get; set; }

        [Required]
        [DisplayName("Shipment Date")]
        [DataType(DataType.Date)]
        
        public DateTime Shipmentdate { get; set; }

        [Required]
        [DisplayName("Total Price")]
        public int Totalprice { get; set; }

        [DisplayName("Order Status")]
        public Status OrderStatus { get; set; }

        [DisplayName("Items in Cart")]
        public int CartQuantity { get; set; }


        public ICollection<Payment> Payment { get; set; } // Reference navigation to dependent; One to Many Relationship: Multiple payments Associated w/ One Shopping Order.
        public ICollection<ShoppingItem> ShoppingItems { get; set; } // One to Many Relationship: One Shopping Order Associated w/ Many Shopping Items


    }
} 