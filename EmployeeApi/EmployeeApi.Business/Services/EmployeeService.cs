using System.Net;
using AutoMapper;
using EmployeeApi.Contracts.Repository;
using EmployeeApi.Contracts.Services;
using EmployeeApi.Entities.Models;
using EmployeeApi.Entities.ViewModels;

namespace EmployeeApi.Business.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;
        private readonly IMapper _mapper;

        public EmployeeService(IRepositoryWrapper repositoryWrapper, IMapper mapper)
        {
            _repositoryWrapper = repositoryWrapper;
            _mapper = mapper;
        }

        public async Task<KeyValuePair<HttpStatusCode, IEnumerable<EmployeeViewModel>>> GetAllEmployeesAsync()
        {
            var result = await _repositoryWrapper.Employee.GetAllEmployeesAsync();

            var employeeViewResult = _mapper.Map<IEnumerable<Employee>, List<EmployeeViewModel>>(result);

            if (result.Any())
            {
                return new KeyValuePair<HttpStatusCode, IEnumerable<EmployeeViewModel>>(HttpStatusCode.OK, employeeViewResult);
            }
            else
            {
                return new KeyValuePair<HttpStatusCode, IEnumerable<EmployeeViewModel>>(HttpStatusCode.NoContent, employeeViewResult);
            }
        }

        public async Task<KeyValuePair<HttpStatusCode, EmployeeViewModel?>> GetEmployeeAsync(int id)
        {
            if (id == 0)
            {
                return new KeyValuePair<HttpStatusCode, EmployeeViewModel?>(HttpStatusCode.BadRequest, null);
            }

            var result = await _repositoryWrapper.Employee.GetEmployeeByIdAsync(id);

            var employeeViewResult = _mapper.Map<EmployeeViewModel>(result);

            if (result != null)
            {
                return new KeyValuePair<HttpStatusCode, EmployeeViewModel?>(HttpStatusCode.OK, employeeViewResult);
            }
            else
            {
                return new KeyValuePair<HttpStatusCode, EmployeeViewModel?>(HttpStatusCode.NotFound, employeeViewResult);
            }
        }

        public async Task<KeyValuePair<HttpStatusCode, bool>> SaveEmployeeAsync(EmployeeViewModel employee)
        {
            var employeeObj = _mapper.Map<Employee>(employee);

            _repositoryWrapper.Employee.CreateEmployee(employeeObj);

            var result = await _repositoryWrapper.SaveAsync();

            var isSaved = result > 0;

            if (isSaved)
            {
                return new KeyValuePair<HttpStatusCode, bool>(HttpStatusCode.Created, isSaved);
            }
            else
            {
                return new KeyValuePair<HttpStatusCode, bool>(HttpStatusCode.NoContent, isSaved);
            }
        }

        public async Task<KeyValuePair<HttpStatusCode, bool>> EditEmployeeAsync(EmployeeViewModel employee)
        {
            var employeeObj = _mapper.Map<Employee>(employee);

            _repositoryWrapper.Employee.UpdateEmployee(employeeObj);

            var result = await _repositoryWrapper.SaveAsync();

            var isSaved = result > 0;

            if (isSaved)
            {
                return new KeyValuePair<HttpStatusCode, bool>(HttpStatusCode.Created, isSaved);
            }
            else
            {
                return new KeyValuePair<HttpStatusCode, bool>(HttpStatusCode.NoContent, isSaved);
            }
        }

        public async Task<KeyValuePair<HttpStatusCode, bool>> DeleteEmployeeAsync(int id)
        {
            if (id == 0)
            {
                return new KeyValuePair<HttpStatusCode, bool>(HttpStatusCode.BadRequest, false);
            }

            var employee = await _repositoryWrapper.Employee.GetEmployeeByIdAsync(id);

            _repositoryWrapper.Employee.DeleteEmployee(employee);
            var result = await _repositoryWrapper.SaveAsync();

            var isDeleted = result > 0;

            if (isDeleted)
            {
                return new KeyValuePair<HttpStatusCode, bool>(HttpStatusCode.NoContent, isDeleted);
            }
            else
            {
                return new KeyValuePair<HttpStatusCode, bool>(HttpStatusCode.NotFound, isDeleted);
            }
        }
    }
}