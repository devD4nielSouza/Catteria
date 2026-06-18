using Catteria.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
namespace Catteria.Domain.Interfaces
{

    public interface IUserRepository
    {
        Task AddAsync(User user);

        Task UpdateAsync(User user);

        Task DeleteAsync(int id);
    }
}
