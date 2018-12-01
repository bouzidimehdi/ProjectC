using System.Collections.Generic;

namespace WebApplication1.Data
{
    public class Key
    {
        public int ID { get; set; }
        public string License { get; set; }
        public bool Sold { get; set; }
        public int ProductID { get; set; }
        public string UserID { get; set; }
        public Product Products { get; set; }
        public List<Orderd_Product> OrderdProducts { get; set; }
        public Factuur_Producten FactuurProducten { get; set; }
    }
}