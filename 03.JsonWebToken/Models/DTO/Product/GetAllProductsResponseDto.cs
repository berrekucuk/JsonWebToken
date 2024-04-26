namespace _03.JsonWebToken.Models.DTO.Product
{
    public class GetAllProductsResponseDto
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal UnitPrice { get; set; }
        public int Stock { get; set; }
    }
}
