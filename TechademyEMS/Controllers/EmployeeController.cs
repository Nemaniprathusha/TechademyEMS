using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using TechademyEMS.Models;
using TechademyEMS.Repository.Interface;



namespace TechademyEMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IDataRepository<Employee> _dataRepository;
        public EmployeeController(IDataRepository<Employee> dataRepository)
        {
            _dataRepository = dataRepository;
        }
        [HttpPost]
        [Route("AddEmployee")]
        public IActionResult Post([FromBody] Employee employee)
        {
            try
            {
                if (employee == null)
                {
                    return BadRequest("Employee is null.");
                }
                else {
                    _dataRepository.Add(employee);
                    return Ok(employee);
                }
            }
            catch (Exception)
            {
                throw new Exception("Bad Request");
            }
    }
        [HttpPut]
        [Route("PutEmployee")]
        public IActionResult Put(int id, [FromBody] Employee employee)
        {
            try
            {
                if (employee == null)
                {
                    return BadRequest("Employee is null.");
                }
                else
                {
                    Employee employeeToUpdate = _dataRepository.Get(id);
                    if (employeeToUpdate == null)
                    {
                        return NotFound("The Employee record couldn't be found.");
                    }
                    _dataRepository.Update(employeeToUpdate, employee);
                    return NoContent();
                }
            }
            catch (Exception)
            {
                throw new Exception("Bad Request");
            }
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                Employee employee = _dataRepository.Get(id);
                if (employee == null)
                {
                    return NotFound("The Employee record couldn't be found.");
                }
                else {
                    _dataRepository.Delete(employee);
                    return NoContent();
                }
            }
            catch (Exception)
            {
                throw new Exception("Bad Request");
            }
        }
        [HttpGet]
        [Route("ShowallEmployees")]
        public IActionResult Get()
        {                                                              
            IEnumerable<Employee> employees = _dataRepository.GetAll();
            return Ok(employees);
        }
        [HttpGet]
        [Route("ShowEmployeeByID")]
        public IActionResult Get(int id)
        {
            Employee employee = _dataRepository.Get(id);
            try
            {
                if (employee == null)
                {
                    return NotFound("The Employee record couldn't be found.");
                }
                return Ok(employee);
            }
            catch (Exception)
            {
                throw new Exception("Bad Request");
            }
        }

    }
}

