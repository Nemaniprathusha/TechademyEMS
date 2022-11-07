using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;

namespace TechademyEMS.Models
{
    public class EmployeeDesignation
    {

       [Key]
        public int EmployeeId { get; set; }
        
        
        public string DesignationName { get; set; }

       public string RoleName { get; set; }
        public string DepartmentName { get; set; }
    }
}
