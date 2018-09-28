using System.Collections.Generic;

namespace Model
{
    public class Builder
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Logo { get; set; } // Verwijst naar de locatie op de server waar het logo staat.
        public List<Builder_Product> BuilderProducts { get; set; }
    }
}