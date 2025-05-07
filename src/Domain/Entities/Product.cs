namespace Domain.Entities
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;
        public string Slug { get; set; } = default!;
        public string? ShortDescription { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public decimal DiscountPrice { get; set; }
        public string Currency { get; set; } = "USD";
        public string? SKU { get; set; }
        public string? Barcode { get; set; }
        public int StockQuantity { get; set; }
        public bool IsInStock { get; set; }
        public bool IsActive { get; set; }
        public bool IsFeatured { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }


    }
}
