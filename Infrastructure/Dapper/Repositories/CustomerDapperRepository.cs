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
using Microsoft.EntityFrameworkCore;
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
                db.Open();
                using (var trans = db.BeginTransaction())
                {
                    string addresquery = "INSERT INTO Address" +
                                         " VALUES(@Street, @ZipCode, @City)" +
                                         " SELECT CAST(SCOPE_IDENTITY() as int)";

                    var addressID = await db.QueryAsync<int>(addresquery, entity.Address, trans);
                    var ID = addressID.First();
                    entity.Address.Id = ID;
                    entity.AddressId = ID;

                    string customerquery =
                        "INSERT INTO Customer" +
                        " VALUES(@AddressId ,@FirstName, @LastName, @Email, @PhoneNumber)" +
                        " SELECT CAST(SCOPE_IDENTITY() as int)";

                    var customerID = await db.QueryAsync<int>(customerquery, entity, trans);
                    entity.Id = customerID.First();

                    trans.Commit();

                    return entity;
                }                
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
                var sql = "Select * " +
                          "From Customer " +
                          "Join [Address] on [Address].ID = Customer.AddressID " +
                          "Where Customer.ID = @id "; 
                
                var result =
                    await db.QueryAsync<Customer, Address, Customer>(sql,
                        (customer, address) =>
                        {
                            customer.Address = address;
                            return customer;
                        },
                        new { id }
                        );
                    

               return result.ElementAt(0);
            }
        }
        
        public async Task<List<Customer>> All()
        {
            using (IDbConnection db = new SqlConnection(this.ConstString))
            {
                var sql = "Select * " +
                          "From Customer " +
                          "Join [Address] on [Address].ID = Customer.AddressID ";
                          

                var result = await db.QueryAsync<Customer, Address, Customer>(sql,
                                (customer, address) =>
                                {
                                    customer.Address = address;
                                    return customer;
                                }
                            );

                return result.ToList();
            }
        }       
    }
}
