using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EFCore.Repositories
{
    public class CustomerRepository
        : IRepository<Customer>
    {
        private readonly DbSet<Customer> _customers;

        private readonly DbContext _dbContext;

        public CustomerRepository(DbContext dbContext)
        {
            if (dbContext == null)
                throw new ArgumentNullException(nameof(dbContext));

            this._dbContext = dbContext;
            this._customers = dbContext.Set<Customer>();
        }

        public async Task<List<Customer>> All()
        {
            return await this._customers.ToListAsync();
        }

        public async Task<Customer> Create(Customer entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            var customer = this._customers.Add(entity).Entity;

            await this._dbContext.SaveChangesAsync();

            return customer;
        }

        public async Task<Customer> Delete(Customer entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            this._customers.Remove(entity);

            await this._dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task<Customer> Get(int id)
        {
            return await this._customers.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Customer> Update(Customer entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            var customer = this._customers.Update(entity).Entity;

            await this._dbContext.SaveChangesAsync();

            return customer;
        }
        
    }
}
