using System.Collections.Generic;

namespace Model
{
    public class Order
    {
        public int ID { get; set; }
        public int User_ID { get; set; }
        public int Factuur_ID { get; set; }
        public Users User { get; set; }
        public Factuur Factuur { get; set; }
        public List<Orderd_Product> OrderdProducts { get; set; }
    }
}