using ecommerce.data.DTOs;
using ecommerce.data.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.service.Interface
{
    public interface ICustomerService
    {
        Task<string> AddCustomerData(CustomerModelDto model);
        Task<IEnumerable<CustomerModelDto>> GetAllCustomer();
        Task<CustomerModelDto> GetById(string uid);
        Task<Boolean> Delete(string uid);
    }
}
