using EmployeeApp.Contracts.Repository;
using EmployeeApp.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeApp.Repository
{
    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        private readonly EmployeeAppDbContext repositoryContext;

        public EmployeeRepository(EmployeeAppDbContext repositoryContext)
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