using AutoMapper;
using ecommerce.data.DTOs;
using ecommerce.data.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ecommerce.data.CustomerMapper
{
    public class CustomerMapping:Profile
    {
        public CustomerMapping()
        {
            CreateMap<CustomerModel, CustomerModelDto>().ReverseMap();
        }
    }
}
    