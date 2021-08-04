using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TESODEV.BusinessLayer.Abstract;
using TESODEV.DataTransferObject;

namespace TESODEV.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private ICustomerBl customerBl;

        public CustomerController(ICustomerBl customerBl)
        {
            this.customerBl = customerBl;
        }

        [HttpPost]
        [Route("Create")]
        public IActionResult Create([FromBody] CustomerDto model)
        {
            return new JsonResult(customerBl.Create(model));
        }

        [HttpPut]
        [Route("Update")]
        public IActionResult Update([FromBody] CustomerDto model)
        {
            return new JsonResult(customerBl.Update(model));
        }

        [HttpDelete]
        [Route("Delete")]
        public IActionResult Delete([FromQuery] Guid id)
        {
            return new JsonResult(customerBl.Delete(id));
        }

        [HttpGet]
        public IActionResult Get()
        {
            return new JsonResult(customerBl.Get());
        }

        [HttpGet]
        [Route("GetById")]
        public IActionResult GetById([FromQuery] Guid id)
        {
            return new JsonResult(customerBl.GetById(id));
        }

        [HttpGet]
        [Route("Validate")]
        public IActionResult Validate([FromQuery] Guid id)
        {
            return new JsonResult(customerBl.Validate(id));
        }
    }
}
