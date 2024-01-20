using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApp.Contracts.Repository
{
    public interface IRepositoryWrapper
    {
        IEmployeeRepository Employee { get; }
        Task<int> SaveAsync();
    }
}


