using EmployeeApi.Contracts.Repository;

namespace EmployeeApi.Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly EmployeeApiDbContext _repoContext;
        private IEmployeeRepository? _employeeRepo;

        public IEmployeeRepository Employee
        {
            get
            {
                if (_employeeRepo == null)
                {
                    _employeeRepo = new EmployeeRepository(_repoContext);
                }

                return _employeeRepo;
            }
        }

        public RepositoryWrapper(EmployeeApiDbContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }

        public async Task<int> SaveAsync()
        {
            return await _repoContext.SaveChangesAsync();
        }
    }
}