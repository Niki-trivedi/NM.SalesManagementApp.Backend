using NM.SalesManagementApp.Backend.Data;
using NM.SalesManagementApp.Backend.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace NM.SalesManagementApp.Backend.Repositories
{
    public class SalesRepRepository : ISalesRepRepository
    {
        private readonly AppDbContext _context;
        public SalesRepRepository(AppDbContext context) => _context = context;

        /// <summary>
        /// get all sales Representative data
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<SalesRepresentative>> GetAllAsync()
        {
            var result = _context.SalesRepresentatives.ToList();
            return Task.FromResult(result.AsEnumerable());
        }

        /// <summary>
        /// get sales Representative by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<SalesRepresentative> GetByIdAsync(int id)
        {
            var result = _context.SalesRepresentatives.Find(id);
            return Task.FromResult(result);
        }

        /// <summary>
        /// add sales Representative
        /// </summary>
        /// <param name="rep"></param>
        /// <returns></returns>
        public async Task AddAsync(SalesRepresentative rep)
        {
            rep.LastUpdated = DateTime.UtcNow;
            await _context.SalesRepresentatives.AddAsync(rep);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// update sales Representative
        /// </summary>
        /// <param name="rep"></param>
        /// <returns></returns>
        public async Task UpdateAsync(SalesRepresentative rep)
        {
            rep.LastUpdated = DateTime.UtcNow;
            _context.SalesRepresentatives.Update(rep);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// delete sales Representative by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteAsync(int id)
        {
            var rep = await GetByIdAsync(id);
            if (rep != null)
            {
                _context.SalesRepresentatives.Remove(rep);
                await _context.SaveChangesAsync();
            }
        }
    }
}
