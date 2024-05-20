﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ChronoMarketplace.Models
{
    public class Payment
    {

        public int payment_ID { get; set; }

        [Required]
        [DisplayName("Customer ID")]
        public int customer_ID { get; set; }

        [Required]
        [DisplayName("Amount to Pay")]
        public int pay_amount { get; set; }

        [Required]
        [DisplayName("Payment Method")]
        public string pay_method { get; set; }

        [Required]
        [DisplayName("Payemnt Date")]
        [DataType(DataType.Date)]
       
    }
}