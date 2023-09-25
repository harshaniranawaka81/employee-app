using EmployeeApi.Contracts.Repository;
using EmployeeApi.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeApi.Repository
{
    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        private readonly EmployeeApiDbContext repositoryContext;

        public EmployeeRepository(EmployeeApiDbContext repositoryContext)
            : base(repositoryContext)
        {
            this.repositoryContext = repositoryContext;
        }

        public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
        {
            return await FindAll()
                .OrderBy(employee => employee.EmployeeName)
                .ToListAsync();
        }

        public async Task<Employee?> GetEmployeeByIdAsync(int employeeId)
        {
            return await FindByCondition(employee => employee.EmployeeId.Equals(employeeId))
                .FirstOrDefaultAsync();
        }
        
        public void CreateEmployee(Employee employee)
        {
            Create(employee);
        }

        public void UpdateEmployee(Employee employee)
        {
            Update(employee);
        }

        public void DeleteEmployee(Employee employee)
        {
            Delete(employee);
        }
    }
}