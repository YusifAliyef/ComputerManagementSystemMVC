namespace Computer_Shop.Entities
{
    public class Computers
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public int Price  { get; set; }
        public bool InStock { get; set; }
        public string Storagetype { get; set; }
        public string Processor { get; set; }
        public int SizeId { get; set; }
        public Sizes Sizes { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
