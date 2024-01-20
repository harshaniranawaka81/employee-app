﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeApi.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeApi
{
    public class EmployeeApiDbContext : DbContext
    {
        public EmployeeApiDbContext (DbContextOptions<EmployeeApiDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
	        modelBuilder.Entity<Employee>().HasData(new Employee
			{
		        EmployeeId = 1,
		        EmployeeName = "Harshani",
		        Salary = 5000
			}, new Employee
            {
				EmployeeId = 2,
				EmployeeName = "Viraj",
				Salary = 2000
			}, new Employee
            {
		        EmployeeId = 3,
		        EmployeeName = "Sampath",
		        Salary = 4000
	        });

            base.OnModelCreating(modelBuilder);

        }

        public DbSet<Employee> Employee { get; set; } = default!;
    }
}
