using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Authentication;

namespace Model {
    public class Users {
        public int ID { get; set; }
        public string E_mail { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public string Name { get; set; } 
        public string Surname { get; set; }
        public string City { get; set; } 
        public string Zip_code { get; set; }
        public string Country { get; set; }
        public string Date_of_birth { get; set; }
        public string Street { get; set; }
        public int Building_nummer { get; set; }
        public Role Roles { get; set; }
        public List<User_wishlist> Wishlists { get; set; }
        public Shopping_card ShoppingCard { get; set; }
        public List<Order> Orders { get; set; }
    }
}