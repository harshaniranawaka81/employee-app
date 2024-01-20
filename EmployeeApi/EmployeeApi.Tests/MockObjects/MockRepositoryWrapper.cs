using AutoMapper;
using EmployeeApp.Contracts.Repository;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeApp.Business.Mappers;

namespace EmployeeApp.Tests.MockObjects
{
    public static class MockRepositoryWrapper
    {

        public static Mock<IRepositoryWrapper> GetMock()
        {
            var mock = new Mock<IRepositoryWrapper>();

            var employeeRepoMock = MockIEmployeeRepository.GetMock();

            mock.Setup(m => m.Employee).Returns(() => employeeRepoMock.Object);
            mock.Setup(m=>m.SaveAsync()).Callback(() => { return; });

            return mock;
        }
    }
}
