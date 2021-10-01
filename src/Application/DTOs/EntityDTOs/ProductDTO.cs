namespace Application.DTOs.EntityDTOs
{
    public class ProductDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Thumbnail { get; set; }
        public string Images { get; set; }
        public string AdditionalFields { get; set; }
        public int CategoryId { get; set; }
        public int BrandId { get; set; }
    }
}
