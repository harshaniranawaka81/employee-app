using EmployeeApi.Contracts.Repository;

namespace EmployeeApi.Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly EmployeeApiDbContext _repoContext;
        private IEmployeeRepository _employee;

        public IEmployeeRepository Employee
        {
            get
            {
                if (_employee == null)
                {
                    _employee = new EmployeeRepository(_repoContext);
                }

                return _employee;
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