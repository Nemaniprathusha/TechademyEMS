using System.Collections.Generic;
using System.Linq;
using TechademyEMS.Data;
using TechademyEMS.Models;
using TechademyEMS.Repository.Interface;

namespace TechademyEMS.Repository.DataManager
{
    public class EmployeeDesignationRepository : IEmployeeDesignationRepository<EmployeeDesignation>
    {
        readonly EmployeeContext _employeeContext;

        public EmployeeDesignationRepository(EmployeeContext employeeContext)
        {
            _employeeContext = employeeContext;
        }
        public IEnumerable<EmployeeDesignation> GetAll()
        {
            return _employeeContext.EmployeeDesignation.ToList();
        }
        public EmployeeDesignation Get(int id)
        {
            return _employeeContext.EmployeeDesignation
                  .FirstOrDefault(e => e.EmployeeId == id);
        }
         public void Update(EmployeeDesignation employee, EmployeeDesignation entity)
        {
            employee.DesignationName = entity.DesignationName;

            _employeeContext.SaveChanges();
        }
        public void Delete(EmployeeDesignation employee)
        {
            _employeeContext.EmployeeDesignation.Remove(employee);
            _employeeContext.SaveChanges();
        }
        public void Add(EmployeeDesignation entity)
        {
            _employeeContext.EmployeeDesignation.Add(entity);
            _employeeContext.SaveChanges();
        }
    }
}
