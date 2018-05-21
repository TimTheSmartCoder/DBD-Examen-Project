using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Domain.Entities;
using Remotion.Linq.Clauses;

namespace Infrastructure.Dapper.Repositories
{
    public class CustomerDapperRepository : 
        IRepository<Customer>
    {
        private readonly string ConstString;

        public CustomerDapperRepository()
        {
            this.ConstString = @"Server=LAPTOP-EBCC42AV;Database=DapperBase;Trusted_Connection=True;";
        }

        public async Task<Customer> Create(Customer entity)
        {
            using (IDbConnection db = new SqlConnection(this.ConstString))
            {
                string sqlquery =
                    "INSERT INTO Customer" +
                    " VALUES(@FirstName, @LastName, @Email, @PhoneNumber)" +
                    " SELECT CAST(SCOPE_IDENTITY() as int)";
                
                    var id = await db.QueryAsync<int>(sqlquery, entity);
                    entity.Id = id.First();

                return entity;
            }
        }

        public async Task<Customer> Update(Customer entity)
        {
            using (IDbConnection db = new SqlConnection(this.ConstString))
            {
                string sqlquery =
                    "UPDATE Customer" +
                    " SET FirstName = @FirstName, LastName = @LastName, Email = @Email, PhoneNumber = @PhoneNumber" +
                    " WHERE ID = @id";
                
                int rowsAffected = db.Execute(sqlquery, entity);
                
                return entity;
            }
        }

        public async Task<Customer> Delete(Customer entity)
        {
            using (IDbConnection db = new SqlConnection(this.ConstString))
            {
                string sqlquery =
                    "DELETE FROM Customer" +                   
                    " WHERE ID = @id";

                int rowsAffected = db.Execute(sqlquery, entity);

                return entity;
            }
        }

        public async Task<Customer> Get(int id)
        {           
            using (IDbConnection db = new SqlConnection(this.ConstString))
            {         
                var result = await db.QueryFirstAsync<Customer>("Select *  From Customer Where ID = @id", new {id});

                return result;
            }
        }
        
        public async Task<List<Customer>> All()
        {
            using (IDbConnection db = new SqlConnection(this.ConstString))
            {
                var result = await db.QueryAsync<Customer>("Select *  From Customer");

                return result.ToList();
            }
        }
    }
}
