namespace Computer_Shop.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public ICollection<Computers> Computers { get; set; }
    }
}
