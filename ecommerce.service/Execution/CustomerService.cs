using AutoMapper;
using ecommerce.data.DTOs;
using ecommerce.data.Model;
using ecommerce.repo.Interface;
using ecommerce.service.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.service.Execution
{
    public class CustomerService:BaseService,ICustomerService
    {
        ICustomerRepo _customerRepo;
        private readonly IMapper _mapper;
        public CustomerService(ICustomerRepo customerRepo,IMapper mapper)
        {
            _customerRepo = customerRepo;
            _mapper = mapper;
        }

        public async Task<Guid> AddCustomerData(CustomerModelDto customerModel)
        {
            return await _customerRepo.AddCustomerData(customerModel);
        }

        public async Task<IEnumerable<CustomerModelDto>> GetAllCustomer()
        {
            var objcust = await _customerRepo.GetCustomerData();

            var objdto = new List<CustomerModelDto>();
            foreach (var item in objcust)
            {
                objdto.Add(_mapper.Map<CustomerModelDto>(item));
            }
            return objdto;
        }

        public async Task<CustomerModelDto> GetById(Guid guid)
        {
            var custObj = await _customerRepo.GetById(guid);
            var objDto = new CustomerModelDto();
            objDto = _mapper.Map<CustomerModelDto>(custObj);
            return objDto;
        }

        public Task<bool> Delete(Guid guid)
        {
            return _customerRepo.Delete(guid);
        }
    }
}
