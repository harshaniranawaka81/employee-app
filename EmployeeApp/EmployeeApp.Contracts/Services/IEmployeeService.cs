﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using EmployeeApp.Entities.Models;
using EmployeeApp.Entities.ViewModels;

namespace EmployeeApp.Contracts.Services
{
    public interface IEmployeeService
    {
        Task<KeyValuePair<HttpStatusCode, IEnumerable<EmployeeViewModel>>> GetAllEmployeesAsync();

        Task<KeyValuePair<HttpStatusCode, EmployeeViewModel?>> GetEmployeeAsync(int id);

        Task<KeyValuePair<HttpStatusCode, bool>> SaveEmployeeAsync(EmployeeViewModel Employee);

        Task<KeyValuePair<HttpStatusCode, bool>> EditEmployeeAsync(EmployeeViewModel Employee);

        Task<KeyValuePair<HttpStatusCode, bool>> DeleteEmployeeAsync(int id);
    }
}
