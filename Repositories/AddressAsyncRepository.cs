using MeFitCase_Assignment.Models.Context;
using MeFitCase_Assignment.Models.Domain;
using MeFitCase_Assignment.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MeFitCase_Assignment.Repositories
{
    public class AddressAsyncRepository : IAddressAsyncRepository
    {
        private readonly MeFitPostgreSqlContext _context;

        public AddressAsyncRepository(MeFitPostgreSqlContext context)
        {
            _context = context;
        }

        public Task<Address?> AddAsync(Address entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> ExistsWithIdAsync(string id)
        {
            return await _context.Addresses.AnyAsync(a => a.Id == int.Parse(id));
        }

        public Task<IEnumerable<Address?>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Address?> GetByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(Address address)
        {
            _context.Entry(address).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
