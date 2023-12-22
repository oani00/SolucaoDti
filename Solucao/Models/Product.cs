namespace Solucao.Models
{
    public class Product
    {
        public readonly int Id;
        public readonly int Quantity;
        public readonly string Name;

        public Product(int id, int quantity, string name)
        {
            Id = id;
            Quantity = quantity;
            Name = name;
        }
    }
}