using System.Collections;
using System.Collections.Generic;

namespace Belatrix.WebApi.Models
{
    public class Product
    {
        public Product()
        {
            OrderItemsNavigation = new HashSet<OrderItem>();
        }
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int SupplierId { get; set; }
        public decimal? UnitPrice { get; set; }
        public string Package { get; set; }
        public bool IsDiscontinued { get; set; }

        public ICollection<OrderItem> OrderItemsNavigation { get; set; }
        public Supplier SupplierNavigation { get; set; }
    }
}
