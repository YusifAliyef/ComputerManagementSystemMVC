namespace Computer_Shop.Entities
{
    public class Orders
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public int Quantity { get; set; }
        public int TotalPrice { get; set; }
        public int CustomerId { get; set; }
        public Customers Customers { get; set; }
    }
}
