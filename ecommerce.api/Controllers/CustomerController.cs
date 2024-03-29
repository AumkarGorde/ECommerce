﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ecommerce.data.DTOs;
using ecommerce.data.Model;
using ecommerce.service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ecommerce.api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        /// <summary>
        /// Get all details of Customer
        /// </summary>
        /// <returns></returns>
        /// 

        [HttpGet("Get")]
        public async Task<ActionResult> CustomerGet()
        {
            var result = await _customerService.GetAllCustomer();
            return Ok(result);
        }

        //[Authorize(Roles = "Admin")]
        //[HttpPost("Post")]
        //public async Task<ActionResult> CustomerAdd(CustomerModelDto customer)
        //{
        //    var data = await _customerService.AddCustomerData(customer);
        //    return Ok(data);
        //}

        [Authorize(Roles = "Admin")]
        [HttpGet("Get/{id}")]
        public async Task<ActionResult> GetById(string id)
        {
            var result = await _customerService.GetById(id);
            return Ok(result);

        }

        [Authorize(Roles = "Admin")]
        [HttpDelete]
        public async Task<ActionResult> Delete(string guid)
        {
            var result = await _customerService.Delete(guid);
            return Ok(result);
        }
    }
}
