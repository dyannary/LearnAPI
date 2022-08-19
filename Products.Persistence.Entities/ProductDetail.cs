namespace Products.Persistence.Entities
{
    public class ProductDetail
    {
        public int Id { get; set; }

        public int Calorie { get; set; }
        public DateTime DataExpirare { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
