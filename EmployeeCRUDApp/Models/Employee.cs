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
    //after migration is complete with succes should write command: update-database
    public class Employee
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "First Name is required")]
        [MaxLength(50, ErrorMessage = "First Name should contain maximum fifty characters")]
        public string FIRSTNAME { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        [MaxLength(50, ErrorMessage = "Last Name should contain maximum fifty characters")]
        public string LASTNAME { get; set; }

        public string MOBILENUMBER { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string EMAIL { get; set; }

        [MaxLength(50, ErrorMessage = "ADDRESSLINE1 should contain maximum fifty characters")]
        public string ADDRESSLINE1 { get; set; }

        [MaxLength(50, ErrorMessage = "ADDRESSLINE2 should contain maximum fifty characters")]
        public string ADDRESSLINE2 { get; set; }

        [MaxLength(50, ErrorMessage = "CITY should contain maximum fifty characters")]
        public string CITY { get; set; }

        [MaxLength(50, ErrorMessage = "COUNTRY should contain maximum fifty characters")]
        public string COUNTRY { get; set; }
    }
}
