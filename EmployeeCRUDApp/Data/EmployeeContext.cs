using EmployeeCRUDApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeCRUDApp.Data
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext(DbContextOptions<EmployeeContext> options) : base(options){ }

        //indicate  public DbSet<ModelClass> TanleNameInDataBase
        //if need to add new set for work with another table we need to write like below and indicate which model will be use and with which tablename
        public DbSet<Employee> EMPLOYEES { get; set; }
    }

}
