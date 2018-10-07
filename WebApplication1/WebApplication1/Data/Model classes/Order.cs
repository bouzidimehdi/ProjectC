using System.Collections.Generic;

namespace WebApplication1.Data
{
    public class Order
    {
        public int ID { get; set; }
        public string User_ID { get; set; }
        public int Factuur_ID { get; set; }
        public ApplicationUser User { get; set; }
        public Factuur Factuur { get; set; }
        public List<Orderd_Product> OrderdProducts { get; set; }
    }
}