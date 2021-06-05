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
        Task<Guid> AddCustomerData(CustomerModelDto model);
        Task<IEnumerable<CustomerModelDto>> GetAllCustomer();
        Task<CustomerModelDto> GetById(Guid guid);
        Task<Boolean> Delete(Guid guid);
    }
}
