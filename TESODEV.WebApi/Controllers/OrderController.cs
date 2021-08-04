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
    public class OrderController : ControllerBase
    {
        private IOrderBl orderBl;

        public OrderController(IOrderBl orderBl)
        {
            this.orderBl = orderBl;
        }

        [HttpPost]
        [Route("Create")]
        public IActionResult Create([FromBody] OrderDto model)
        {
            return new JsonResult(orderBl.Create(model));
        }

        [HttpPut]
        [Route("Update")]
        public IActionResult Update([FromBody] OrderDto model)
        {
            return new JsonResult(orderBl.Update(model));
        }

        [HttpDelete]
        [Route("Delete")]
        public IActionResult Delete([FromQuery] Guid id)
        {
            return new JsonResult(orderBl.Delete(id));
        }

        [HttpGet]
        public IActionResult Get()
        {
            return new JsonResult(orderBl.Get());
        }

        [HttpGet]
        [Route("GetArrayById")]
        public IActionResult GetArrayById([FromQuery] Guid id)
        {
            return new JsonResult(orderBl.GetArrayById(id));
        }

        [HttpGet]
        [Route("GetById")]
        public IActionResult GetById([FromQuery] Guid id)
        {
            return new JsonResult(orderBl.GetById(id));
        }

        [HttpGet]
        [Route("ChangeStatus")]
        public IActionResult ChangeStatus([FromQuery] Guid id, [FromQuery] string status)
        {
            return new JsonResult(orderBl.ChangeStatus(id, status));
        }
    }
}
