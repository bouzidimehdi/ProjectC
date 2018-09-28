using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Model {

    public class User_wishlist {
        public int User_ID { get; set; }
        public int Product_ID { get; set; }
        public Product Product { get; set; }
        public Users User { get; set; }
    }
}