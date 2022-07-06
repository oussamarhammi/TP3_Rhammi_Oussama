using JuliePro.Controllers;
using JuliePro_Core;
using JuliePro_Core.Interfaces;
using JuliePro_DataAccess.Data;
using JuliePro_Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace JuliePro_DataAcess
{
    public class DeleteSpeciality_Tests
    {

        // Arrange

      
        [Fact]
        public async Task Delete_Speciality_Return_Index_View()
        {

            int Id = 1;

            var mockRepo = new Mock<ISpecialitiesService>();
            mockRepo.Setup(repo => repo.DeleteAsync<Speciality>(Id));
            var controller = new SpecialitiesController(mockRepo.Object);

            // Act
            var result = await controller.DeleteConfirmed(Id);

            // Assert
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Null(redirectToActionResult.ControllerName);
            Assert.Equal("Index", redirectToActionResult.ActionName);
            mockRepo.Verify();
        }


    }
}
