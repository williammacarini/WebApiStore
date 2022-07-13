using Store.Domain.Validations;

namespace Store.Domain.Entities
{
    public class Purchase
    {
        public int PurchaseId { get; private set; }
        public int UserId { get; private set; }
        public int ProductId { get; private set; }
        public DateTime PurchaseDate { get; private set; }
        public User User { get; set; }
        public Product Product { get; set; }

        public Purchase(int productId, int userId)
        {
            Validation(productId, userId);
        }

        public Purchase(int id, int productId, int userId)
        {
            DomainValidationException.When(id <= 0, "Id deve ser maior que zero!");
            PurchaseId = id;
            Validation(productId, userId);
        }

        private void Validation(int productId, int userId)
        {
            DomainValidationException.When(productId <= 0, "Id do produto é um campo obrigatório!");
            DomainValidationException.When(userId <= 0, "Id da pessoa é um campo obrigatório!");

            ProductId = productId;
            UserId = userId;
            PurchaseDate = DateTime.Now;
        }

    }
}
