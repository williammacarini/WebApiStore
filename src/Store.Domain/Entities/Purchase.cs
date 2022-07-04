using Store.Domain.Validations;

namespace Store.Domain.Entities
{
    public class Purchase
    {
        public int Id { get; private set; }
        public int UserId { get; private set; }
        public int ProductId { get; private set; }
        public DateTime PurchaseDate { get; private set; }
        public User User { get; set; }
        public Product Product { get; set; }

        public Purchase(int productId, int personId, DateTime? purchaseDate)
        {
            Validation(productId, personId, purchaseDate);
        }

        public Purchase(int id, int productId, int personId, DateTime? purchaseDate)
        {
            DomainValidationException.When(id < 0, "Id deve ser maior que zero!");
            Id = id;
            Validation(productId, personId, purchaseDate);
        }

        private void Validation(int productId, int userId, DateTime? purchaseDate)
        {
            DomainValidationException.When(productId < 0, "Id do produto é um campo obrigatório!");
            DomainValidationException.When(userId < 0, "Id da pessoa é um campo obrigatório!");
            DomainValidationException.When(purchaseDate.HasValue, "Data da compra é um campo obrigatório!");

            ProductId = productId;
            UserId = userId;
            PurchaseDate = purchaseDate.Value;
        }

    }
}
