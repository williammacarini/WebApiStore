using Store.Domain.Validations;

namespace Store.Domain.Entities
{
    public class Product
    {
        public int ProductId { get; private set; }
        public string Name { get; private set; }
        public string Code { get; private set; }
        public decimal Price { get; private set; }
        public ICollection<Purchase> Purchases { get; set; }

        public Product(string name, string code, decimal price)
        {
            Validation(name, code, price);
            Purchases = new List<Purchase>();
        }

        public Product(int id, string name, string code, decimal price)
        {
            DomainValidationException.When(id < 0, "Id deve ser maior que zero!");
            ProductId = id;
            Validation(name, code, price);
            Purchases = new List<Purchase>();
        }

        private void Validation(string name, string code, decimal price)
        {
            DomainValidationException.When(string.IsNullOrEmpty(name), "Nome é um campo obrigatório!");
            DomainValidationException.When(string.IsNullOrEmpty(code), "Código é um campo obrigatório!");
            DomainValidationException.When(price < 0, "O valor deve ser maior que zero!");

            Name = name;
            Code = code;
            Price = price;
        }
    }
}
