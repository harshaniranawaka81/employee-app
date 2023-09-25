using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApi.Contracts.Repository
{
    public interface IRepositoryWrapper
    {
        IEmployeeRepository Employee { get; }
        Task<int> SaveAsync();
    }
}


