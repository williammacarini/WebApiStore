using Store.Domain.Repositories;

namespace Store.Domain.FilterDB
{
    public class UserFilterDb : PagedBaseRequest
    {
        public string? Name { get; set; }
    }
}
