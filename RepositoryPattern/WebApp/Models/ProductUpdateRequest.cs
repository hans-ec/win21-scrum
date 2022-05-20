namespace WebApp.Models
{
    public class ProductUpdateRequest
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public DateTime Modified { get; set; } = DateTime.Now;
    }
}
