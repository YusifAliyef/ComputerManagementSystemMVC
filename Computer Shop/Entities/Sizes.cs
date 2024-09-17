namespace Computer_Shop.Entities
{
    public class Sizes
    {
        public int Id { get; set; }
        public int Ram { get; set; }
        public int Storage { get; set; }
        public string ScreenSize { get; set; }
        public Computers Computers { get; set; }
    }
}
