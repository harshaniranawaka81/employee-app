using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeApi.Contracts.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using EmployeeApi.Entities.Models;
using EmployeeApi.Entities.ViewModels;
using System.Net;
using EmployeeApi.Business.FilterAttributes;

namespace EmployeeApi.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly ILogger<EmployeesController> _logger;

        public EmployeesController(IEmployeeService employeeService, ILogger<EmployeesController> logger)
        {
            _employeeService = employeeService;
            _logger = logger;
        }

        // GET: Employees
        [CustomerHeaderResultFilter]
        public async Task<IActionResult> Index()
        {
            var result = await _employeeService.GetAllEmployeesAsync();

            var employees = result.Value.ToList();

            _logger.LogInformation("Successful: public async Task<IActionResult> Index() No of employees: {0}", employees.Count);

            return result.Key switch
            {
                HttpStatusCode.OK => View(employees),
                HttpStatusCode.NoContent => NoContent(),
                _ => BadRequest(result.Value)
            };


        }

        // GET: Employees/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var result = await _employeeService.GetEmployeeAsync(id);

            return result.Key switch
            {
                HttpStatusCode.OK => View(result.Value),
                HttpStatusCode.NotFound => NotFound(),
                _ => BadRequest(result.Value)
            };
        }

        // GET: Employees/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmployeeId,EmployeeName,Salary")] EmployeeViewModel employee)
        {
            if (ModelState.IsValid)
            {
                var result = await _employeeService.SaveEmployeeAsync(employee);

                return result.Key switch
                {
                    HttpStatusCode.Created => RedirectToAction(nameof(Index)),
                    HttpStatusCode.NoContent => NoContent(),
                    _ => BadRequest(result.Value)
                };
            }

            return View(employee);
        }

        // GET: Employees/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var result = await _employeeService.GetEmployeeAsync(id);

            return result.Key switch
            {
                HttpStatusCode.OK => View(result.Value),
                HttpStatusCode.NotFound => NotFound(),
                _ => BadRequest(result.Value)
            };
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EmployeeId,EmployeeName,Salary")] EmployeeViewModel employee)
        {
            if (ModelState.IsValid)
            {
                var result = await _employeeService.EditEmployeeAsync(employee);

                return result.Key switch
                {
                    HttpStatusCode.Created => RedirectToAction(nameof(Index)),
                    HttpStatusCode.NoContent => NoContent(),
                    _ => BadRequest(result.Value)
                };
            }
            return View(employee);
        }

        // GET: Employees/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _employeeService.GetEmployeeAsync(id);

            return result.Key switch
            {
                HttpStatusCode.OK => View(result.Value),
                HttpStatusCode.NotFound => NotFound(),
                _ => BadRequest(result.Value)
            };
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var result = await _employeeService.DeleteEmployeeAsync(id);

            return result.Key switch
            {
                HttpStatusCode.NoContent => RedirectToAction(nameof(Index)),
                HttpStatusCode.NotFound => NotFound(),
                _ => BadRequest(result.Value)
            };
        }
    }
}
