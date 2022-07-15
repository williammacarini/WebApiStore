using Store.Domain.Validations;

namespace Store.Domain.Entities
{
    public class UserAuthentication
    {
        public int Id { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }

        public UserAuthentication(int id, string email, string password)
        {
            DomainValidationException.When(id <= 0, "Id deve ser informado!");
            Validation(email, password);
        }

        private void Validation(string email, string password)
        {
            DomainValidationException.When(string.IsNullOrEmpty(email), "Email deve ser informado!");
            DomainValidationException.When(string.IsNullOrEmpty(password), "Senha deve ser informada!");

            Email = email;
            Password = password;
        }
    }
}
