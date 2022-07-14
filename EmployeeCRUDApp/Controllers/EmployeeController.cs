using EmployeeCRUDApp.Data;
using EmployeeCRUDApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks; 

namespace EmployeeCRUDApp.Controllers
{
    public class EmployeeController : Controller
    {
        //injection connection string which is specificated in EmployeeContext
        private readonly EmployeeContext _context;
        EmployeeStoredProcedures emp = new EmployeeStoredProcedures();
        


        public EmployeeController(EmployeeContext context)
        {
            _context = context; 
        }
         
        public async Task<IActionResult> ListOfEmployees()//Index
        {
            //create a var for list of employees and get from data base from tablename and Cast to list and then communicate in View this list
            var employees = await _context.EMPLOYEES.ToListAsync();
            return View(employees);
        }
        public IActionResult CreateCreateEmployee()//Create
        {
            //this action result is just for show page with form, and we don't need to use async and don't need to connect to data base, just show a form with wanted model
            //a simple View page which we create on base of our model 
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateCreateEmployee(Employee employee)//method except a model with data from form, when we press Create button
        {
            if (ModelState.IsValid)
            {
                //_context.EMPLOYEES.Add(employee);//adres to the data base, select table name and Add a model 
                //await _context.SaveChangesAsync();//save changes
                //return RedirectToAction("ListOfEmployees") //also work good
                //return RedirectToAction(nameof(ListOfEmployees)); //redirect to action(page) namePage = nameAction

                
                var result_registration = await emp.Add_new_userAsync(employee);
                ErrorList er = new ErrorList();
                er.message_error = result_registration;
                return RedirectToAction(nameof(Result_registration), er);
            }
            //if anythings will hapen will return a simple view
            return View(employee);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            //check if passed id is not null or zero
            if (id == null || id <= 0)
            {
                return BadRequest();
            }
            //search in data base with passed id 
            var employeeinDb = await _context.EMPLOYEES.FirstOrDefaultAsync(e => e.ID == id);
            //check the result of search, it shouldn't be null
            if (employeeinDb == null)
            {
                return NotFound();
            }
            return View(employeeinDb);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return View(employee);
            }
            //were are two ways to update data
            //_context.Entry(employee).State = EntityState.Modified;
            //_context.EMPLOYEES.Update(employee);
            _context.EMPLOYEES.Update(employee);
            await _context.SaveChangesAsync();

            return RedirectToAction("ListOfEmployees");
        }

        public async Task<IActionResult> Delete(int? id)
        {
            //check if passed id is not null or zero
            if (id == null || id <= 0)
            {
                return BadRequest();
            }
            //search in data base with passed id 
            var employeeinDb = await _context.EMPLOYEES.FirstOrDefaultAsync(e => e.ID == id);
            //check the result of search, it shouldn't be null
            if(employeeinDb == null)
            {
                return NotFound();
            }
            //if the result of search was found then delete him
            _context.EMPLOYEES.Remove(employeeinDb);
            //after delete need to save changes
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(ListOfEmployees));
        }

        //for show view with operation result status
        public IActionResult Result_registration(ErrorList error)
        {
            return View(error);
        }
    }
}
