using AutoMapper;
using EmployeeApi.Business.Mappers;
using EmployeeApi.Business.Services;
using EmployeeApi.Contracts.Repository;
using EmployeeApi.Controllers;
using EmployeeApi.Entities.Models;
using EmployeeApi.Entities.ViewModels;
using EmployeeApi.Repository;
using EmployeeApi.Tests.MockObjects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;

namespace EmployeeApi.Tests
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