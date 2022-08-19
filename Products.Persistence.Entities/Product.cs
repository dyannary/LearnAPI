namespace Products.Persistence.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }

        public virtual ICollection<ProductShop> Shops { get; set; }
        public ProductDetail Details { get; set; }
    }
}
