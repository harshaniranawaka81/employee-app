using AutoMapper;
using EmployeeApp.Business.Mappers;
using EmployeeApp.Business.Services;
using EmployeeApp.Contracts.Repository;
using EmployeeApp.Controllers;
using EmployeeApp.Entities.Models;
using EmployeeApp.Entities.ViewModels;
using EmployeeApp.Repository;
using EmployeeApp.Tests.MockObjects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;

namespace EmployeeApp.Tests
{
    public class EmployeeControllerTests
    {
        public IMapper GetMapper()
        {
            var mappingProfile = new EmployeeProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(mappingProfile));
            return new Mapper(configuration);
        }

        [Fact]
        public void Index_ReturnsAViewResult_WithAListOfEmployees()
        {
            // Arrange
            var logger = new Mock<ILogger<EmployeesController>>();

            var employeeService = new EmployeeService(MockRepositoryWrapper.GetMock().Object, GetMapper());
            var controller = new EmployeesController(employeeService, logger.Object);

            // Act
            var result = controller.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result.Result);
            var model = Assert.IsAssignableFrom<List<EmployeeViewModel>>(
                viewResult.ViewData.Model);
            Assert.Equal(3, model.Count());
        }
    }
}