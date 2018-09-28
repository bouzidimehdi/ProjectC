using System.Collections.Generic;

namespace Model
{
    public class Builder_Product
    {
        public int Builder_ID { get; set; }
        public int Product_ID { get; set; }
        public Product Product { get; set; }
        public Builder Builder { get; set; }
    }
}