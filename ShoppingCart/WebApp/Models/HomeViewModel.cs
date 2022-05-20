namespace WebApp.Models
{
    public class HomeViewModel
    {
        public List<Product> NewArrivals { get; set; } = null!;
        public ShoppingCart ShoppingCart { get; set; } = null!;
    }
}
