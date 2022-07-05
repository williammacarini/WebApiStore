using Store.Domain.Validations;

namespace Store.Domain.Entities
{
    public class User
    {
        public int UserId { get; private set; }
        public string Name { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public ICollection<Purchase> Purchases { get; set; }

        public User(string name, string lastName, string email)
        {
            Validation(name, lastName, email);
            Purchases = new List<Purchase>();
        }

        public User(int id, string name, string lastName, string email)
        {
            DomainValidationException.When(id < 0, "Id deve ser maior que zero!");
            UserId = id;
            Validation(name, lastName, email);
            Purchases = new List<Purchase>();
        }

        private void Validation(string name, string lastName, string email)
        {
            DomainValidationException.When(string.IsNullOrEmpty(name), "Nome é um campo obrigatório!");
            DomainValidationException.When(string.IsNullOrEmpty(lastName), "Sobrenome é um campo obrigatório!");
            DomainValidationException.When(string.IsNullOrEmpty(email), "Email é um campo obrigatório!");

            Name = name;
            LastName = lastName;
            Email = email;  
        }
    }
}
