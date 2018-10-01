using System.Collections.Generic;

namespace Model
{
    public class Shopping_card
    {
        public int ID { get; set; }
        public int User_ID { get; set; }
        public Users User { get; set; }
        public List<Shopping_card_Product> ShoppingCardProducts { get; set; }
    }
}