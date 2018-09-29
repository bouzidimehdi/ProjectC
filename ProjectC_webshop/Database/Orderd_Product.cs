using System;
using System.Collections.Generic;

namespace Model
{
    public class Orderd_Product
    {
        public int ID { get; set; }
        public int Key_ID { get; set; }
        public int Order_ID { get; set; }
        public Order Order { get; set; }
        public Key Key { get; set; }
    }
}
