using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechademyEMS.Models;

namespace TechademyEMS.Data
{
    public class EmployeeContext :DbContext
    {
        public EmployeeContext(DbContextOptions options)
           : base(options)
        {
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeDesignation> EmployeeDesignation { get; set; }
       
        }
    }

