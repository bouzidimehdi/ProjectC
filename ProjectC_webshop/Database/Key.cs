using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Model {

    public class Key {
        public int ID { get; set; }
        public string License { get; set; }
        public bool Sold { get; set; }
        public int ProductID { get; set; }
        public Product Products { get; set; }
        public List<Orderd_Product> OrderdProducts { get; set; }
        public Factuur_Producten FactuurProducten { get; set; }
    }
}