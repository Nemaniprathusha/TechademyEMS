using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechademyEMS.Models;
using TechademyEMS.Repository.Interface;

namespace TechademyEMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeDesignationController : ControllerBase
    {
        private readonly IDataRepository<EmployeeDesignation> _db;

        public EmployeeDesignationController(IDataRepository<EmployeeDesignation> db)
        {
            _db = db;
        }
        [HttpPost]
        [Route("AddDesignation")]
        public IActionResult Post([FromBody] EmployeeDesignation designation)
        {
            try
            {
                if (designation == null)
                {
                    return BadRequest("Designation is null.");
                }
                else
                {
                    _db.Add(designation);
                    return Ok(designation);
                }
            }
            catch (Exception)
            {
                throw new Exception("Bad Request");
            }
        }
        [HttpPut]
        [Route("PutDesignation")]
        public IActionResult Put(int id, [FromBody] EmployeeDesignation designation)
        {
            try
            {
                if (designation == null)
                {
                    return BadRequest("Designation is null.");
                }
                else
                {
                    EmployeeDesignation EmployeeDesignationToUpdate = _db.Get(id);
                    if (EmployeeDesignationToUpdate == null)
                    {
                        return NotFound("The designation record couldn't be found.");
                    }
                    _db.Update(EmployeeDesignationToUpdate, designation);
                    return NoContent();
                }
            }
            catch (Exception)
            {
                throw new Exception("Bad Request");
            }
        }
        [HttpDelete]
        [Route("DeleteDesignation")]
        public IActionResult Delete(int id)
        {
            try
            {
                
                
                    EmployeeDesignation employee = _db.Get(id);
                    if (employee == null)
                    {
                        return NotFound("The designation record couldn't be found.");
                    }
                    else
                    {
                        _db.Delete(employee);
                        return NoContent();
                    }
                
               
            }
            catch (Exception)
            {
                throw new Exception("Bad Request");
            }
        }
        [HttpGet]
        [Route("ShowallDesignation")]
        public IActionResult Get()
        {
            IEnumerable<EmployeeDesignation> employees = _db.GetAll();
            return Ok(employees);
        }
        [HttpGet]
        [Route("ShowDesignationByID")]
        public IActionResult Get(int id)
        {
            EmployeeDesignation employee = _db.Get(id);
            try
            {
                if (employee == null)
                {
                    return NotFound("The designation record couldn't be found.");
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
