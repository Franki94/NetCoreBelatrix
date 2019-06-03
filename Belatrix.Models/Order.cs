using System;
using System.Collections;
using System.Collections.Generic;

namespace Belatrix.WebApi.Models
{
    public class Order
    {
        public Order()
        {
            OrderItemsNavigation = new HashSet<OrderItem>();
        }
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public string OrderNumber { get; set; }
        public int CustomerId { get; set; }
        public decimal? TotalAmount { get; set; }

        public Customer CustomerNavigation { get; set; }
        public ICollection<OrderItem> OrderItemsNavigation { get; set; }
    }
}
