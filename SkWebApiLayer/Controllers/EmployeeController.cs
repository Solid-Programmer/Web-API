using SkSampleContractsLayer.Contracts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using SkWebApiLayer.Controllers.Filters;
using SkSampleDataAccessLayer.Implementations;

namespace SkWebApiLayer.Controllers
{
    [Route("api/employee/")]
    public class EmployeeController : ApiController
    {
        public readonly ISkAppService SkAppservice;

        public EmployeeController(ISkAppService skAppService)
        {
            SkAppservice = skAppService;
        }
        
        [HttpGet]
        public IHttpActionResult GetEmployeeDataByName([FromUri] PagingModel pagingModel, string name)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Please check the parameters");
            }

            var empData = SkAppservice.GetPagedEmployeeDataByName(name, pagingModel.PageSize, pagingModel.PageNo).ToList();

            if (!empData.Any())
            {
                return NotFound();
            }

            return Ok(empData);
        }

        //[Route("api/Employee/{id:int}")]
        //[HttpGet]
        //public IHttpActionResult GetEmployeeDataById([FromUri] PagingModel pagingModel, int id)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest("Please check the parameters");
        //    }

        //    var empData = SkAppservice.GetPagedEmployeeDataById(id, pagingModel.PageSize, pagingModel.PageNo).ToList();

        //    if (!empData.Any())
        //    {
        //        return NotFound();
        //    }

        //    return Ok(empData);
        //}
    }
}
