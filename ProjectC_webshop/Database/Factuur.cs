using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Model
{
    public class Factuur
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string City { get; set; }
        public string Streetname { get; set; }
        public string Zip_Code { get; set; }
        public int Building_nummer { get; set; }
        public string E_mail { get; set; }
        public bool Payed { get; set; }
        public Order Order { get; set; }
        public List<Factuur_Producten> FactuurProductens { get; set; }
    }
}