namespace Computer_Shop.Models
{
    public class OrderModel
    {
       
        public DateTime OrderDate { get; set; }
        public int Quantity { get; set; }
        public int TotalPrice { get; set; }
        public int CustomerId { get; set; }
    }
}
