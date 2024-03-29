﻿using Store.Domain.Entities;
using Store.Domain.FilterDB;

namespace Store.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetByIdAsync(int id);
        Task<ICollection<User>> GetPeopleAsync();
        Task<User> CreateUserAsync(User user);
        Task UpdateAsync(User user);
        Task DeleteAsync(User user);
        Task<int> GetIdByDocumentAsync(string document);
        Task<PagedBaseResponse<User>> GetPagedUserAsync(UserFilterDb request);
    }
}
