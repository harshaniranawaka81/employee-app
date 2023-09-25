using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeApi.Contracts.Repository;
using EmployeeApi.Entities.Models;
using Moq;

namespace EmployeeApi.Tests.MockObjects
{
    public static class MockIEmployeeRepository
    {
        public static Mock<IEmployeeRepository> GetMock()
        {
            var mock = new Mock<IEmployeeRepository>();

            var employees = new List<Employee>()
            {
                new Employee()
                {
                    EmployeeId = 1,
                    EmployeeName = "Harshani",
                    Salary = 5000
                },
                new Employee()
                {
                    EmployeeId = 2,
                    EmployeeName = "Viraj",
                    Salary = 2500
                },
                new Employee()
                {
                    EmployeeId = 3,
                    EmployeeName = "Pubudu",
                    Salary = 1500
                }
            };

            mock.Setup(m => m.GetAllEmployeesAsync())
                .ReturnsAsync(() => employees);
            mock.Setup(m => m.GetEmployeeByIdAsync(It.IsAny<int>()))
                .ReturnsAsync((int id) => employees.FirstOrDefault(e=>e.EmployeeId == id));

            return mock;
        }
    }
}
