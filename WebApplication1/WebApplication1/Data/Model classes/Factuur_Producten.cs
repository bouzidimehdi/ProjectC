namespace WebApplication1.Data
{
    public class Factuur_Producten
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public int Key_ID { get; set; }
        public int Factuur_ID { get; set; }
        public Factuur Factuur { get; set; }
        public Key Key { get; set; }
    }
}