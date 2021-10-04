using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace WAAPI.Models
{
    public class Order
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime DeliveredAt { get; set; }
        public string Address { get; set; }
        public Team Team { get; set; }
        public virtual List<Product> Products { get; set; }
        //public Product Product { get; set; }
    }
}