using ecommerce.data.DTOs;
using ecommerce.data.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.repo.Interface
{
    public interface ICustomerRepo
    {
        Task<IEnumerable<CustomerModel>> GetCustomerData();
        Task<string> AddCustomerData(CustomerModelDto model);
        Task<CustomerModel> GetById(string uid);
        Task<Boolean> Delete(string uid);
    }
}
