using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFNgAppMV.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EFNgAppMV.Controllers
{
    [Route("api/[controller]")]
    public class EmployeeController : Controller
    {
        private readonly EmployeeDataAccessLayer empObject = new EmployeeDataAccessLayer();
        
        [HttpGet]
        [Route("api/Employee/Index")]
        public IEnumerable<TblEmployee> Index()
        {
            return empObject.GetAllEmployees();
        }

        [HttpPost]
        [Route("api/Employee/Create")]
        public int Create([FromBody] TblEmployee emp)
        {
            return empObject.AddEmployee(emp);
        }

        [HttpGet]
        [Route("api/Employee/Details/{id}")]
        public TblEmployee Details(int id)
        {
            return empObject.GetEmployee(id);
        }

        [HttpPut]
        [Route("api/Employee/Edit")]
        public int Edit([FromBody] TblEmployee emp)
        {
            return empObject.UpdateEmployee(emp);
        }

        [HttpDelete]
        [Route("api/Employee/Delete/{id}")]
        public bool Delete(int id)
        {
            return empObject.DeleteEmployee(id);
        }

        [HttpGet]
        [Route("api/Employee/GetCities")]
        public IEnumerable<TblCities> Details()
        {
            return empObject.GetCities();
        }
    }
}
