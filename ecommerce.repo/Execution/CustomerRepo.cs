using Dapper;
using ecommerce.data.DTOs;
using ecommerce.data.Model;
using ecommerce.repo.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.repo.Execution
{
    public class CustomerRepo : BaseRepo, ICustomerRepo
    {
        private string dbConnection = string.Empty;

        public CustomerRepo()
        {
            dbConnection = DBConnection;
        }

        private string Address(string address)
        {
            string addrid = GenerateId();
            try
            {
                using (var connection = new SqlConnection(dbConnection))
                {
                    connection.Open();
                    var insertAddress = @"INSERT INTO tblAddress(AddressId,Address) VALUES (@AddressId,@Address)";
                    var t = connection.Execute(insertAddress, new { AddressId = addrid, Address = address });
                    connection.Close();
                }
                return addrid;
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        private int DeleteAddr(string uid)
        {
            int i = 0;
            try
            {
                using (var con = new SqlConnection(dbConnection))
                {
                    con.Open();
                    string queryDelete = @"Delete from tblAddress where AddressId = @AddressId";
                    i = con.Execute(queryDelete, new { AddressId = uid });
                    con.Close();
                }
                return i;
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public async Task<string> AddCustomerData(CustomerModelDto customer)
        {
            try
            {
                var addr_fk = Address(customer.Address);
                var cust_Id = GenerateId();
                using (var connection = new SqlConnection(dbConnection))
                {
                    await connection.OpenAsync();
                    string insertCustomer = @"INSERT INTO tblCustomer (CustomerId, Name, Age, AddressId) 
                                            VALUES (@CustomerId, @Name, @Age, @AddressId)";
                    await connection.ExecuteAsync(insertCustomer, new
                    {
                        CustomerId = cust_Id,
                        Name = customer.Name,
                        Age = customer.Age,
                        AddressId = addr_fk
                    });

                    await connection.CloseAsync();
                }

                return cust_Id;
            }
            catch (Exception)
            {

                throw;
            }
            
        }
        public async Task<IEnumerable<CustomerModel>> GetCustomerData()
        {
            try
            {
                IEnumerable<CustomerModel> custerModel = null;
                using (var connection = new SqlConnection(dbConnection))
                {
                    await connection.OpenAsync();
                    var getCustomersQuery = @"Select c.CustomerId, c.Name, c.Age, c.AddressId, a.Address from tblCustomer c 
                                            join tblAddress a on c.AddressId = a.AddressId ";
                    custerModel = await connection.QueryAsync<CustomerModel>(getCustomersQuery);
                    await connection.CloseAsync();
                }
                return custerModel;
            }
            catch (Exception)
            {

                throw;
            }
           
        }

        public async Task<CustomerModel> GetById(string uid)
        {
            try
            {
                CustomerModel customer = null;
                using (var con = new SqlConnection(dbConnection))
                {
                    await con.OpenAsync();
                    string getqueryById = @"Select c.CustomerId, c.Name, c.Age, c.AddressId, a.Address from tblCustomer c 
                                            join tblAddress a on c.AddressId = a.AddressId where c.CustomerId = @CustomerId";

                    customer = await con.QuerySingleAsync<CustomerModel>(getqueryById, new { CustomerId = uid });
                    await con.CloseAsync();
                }

                return customer;
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public async Task<bool> Delete(string uid)
        {
            try
            {
                CustomerModel customer = GetById(uid).GetAwaiter().GetResult();

                int r = 0;
                using (var con = new SqlConnection(dbConnection))
                {
                    await con.OpenAsync();
                    var deleteQuery = @"Delete from tblCustomer where CustomerId = @CustomerId";
                    r = await con.ExecuteAsync(deleteQuery, new { CustomerId = uid });
                    await con.CloseAsync();
                }
                if (r >= 1)
                {
                    int i = DeleteAddr(customer.AddressId);
                    if (i >= 1)
                        return true;
                    else
                        return false;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                throw;
            }
            
        }
    }
}
