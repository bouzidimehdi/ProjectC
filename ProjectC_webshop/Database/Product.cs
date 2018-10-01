using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Model {
    public class Product {
        public int ID { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public List<Key> Keys { get; set; }
        public List<User_wishlist> Wishlists { get; set; }
        public List<Builder_Product> BuilderProducts { get; set; }
        public List<Shopping_card_Product> ShoppingCardProducts { get; set; }
    }
}