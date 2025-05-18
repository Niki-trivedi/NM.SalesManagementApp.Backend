using NM.SalesManagementApp.Backend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NM.SalesManagementApp.Backend.Repositories
{
    public interface ISalesRepRepository
    {
        Task<IEnumerable<SalesRepresentative>> GetAllAsync();
        Task<SalesRepresentative> GetByIdAsync(int id);
        Task AddAsync(SalesRepresentative rep);
        Task UpdateAsync(SalesRepresentative rep);
        Task DeleteAsync(int id);
    }
}
