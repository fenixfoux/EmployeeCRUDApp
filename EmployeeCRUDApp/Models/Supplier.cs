using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeCRUDApp.Models
{
    //after create a model and dbcontext(for connect to database), is possible to create data migration, for create table in data base in coincidence with other model
    //Tools - NuggetPacket Manager - Package Manager Console 
    //and write a command:
    //add-migration MigrationName -o Data\Migrations  
    //where MigrationName is name which indicate what did you do(for example AddedDataAnnotationsToEmployeeModel)
    //and after -o you select Address where (preferable to be in folder with dbcontext class where you connect database)
    //AND 
    //after migration is complete with succes should write command: update-database  -Context StoreContext (-Context if there are more than one DbContext classes)
    public class Supplier
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "The Name is required")]
        [Display(Name = "Supplier name")]
        public string Name { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Address { get; set; } 
    }
}
