using System;
using System.Threading.Tasks;
using DReservation.Models.Domain;
using DReservation.Services;
using DReservation.UI.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

namespace DReservation.Tests.UnitTests.Controllers
{
    [TestFixture]
    public class ControllerTests
    {
        private Mock<IReservationService> _reservationServiceMock;
        private HomeController _controller;

        [SetUp]
        public void SetUp()
        {
            _reservationServiceMock = new Mock<IReservationService>();

            _controller = new HomeController(_reservationServiceMock.Object);
        }

        [Test]
        public async Task Get_Should_Catch_The_Exception_When_Date_Is_Empty()
        {
            // Act
            var result = await _controller.GetAvailableTimes(string.Empty);

            // Assert
            Assert.IsInstanceOf<BadRequestObjectResult>(result);
        }

        [Test]
        public async Task Get_Should_Catch_The_Exception_When_Date_Is_Null()
        {
            // Act
            var result = await _controller.GetAvailableTimes(null);

            // Assert
            Assert.IsInstanceOf<BadRequestObjectResult>(result);
        }

        [TestCase("ABCD")]
        [TestCase("1234")]
        [TestCase("1236/18/32")]
        [TestCase("1236-18-32")]
        [TestCase("1")]
        public async Task Get_Should_Catch_The_Exception_When_StartingDate_IsNot_Valid(string startingDate)
        {
            // Act
            var result = await _controller.GetAvailableTimes(startingDate);

            // Assert
            Assert.IsInstanceOf<BadRequestObjectResult>(result);
        }

        [TestCase("20180312")]
        [TestCase("20181015")]
        public async Task Get_Should_ReturnOk_When_StartingDate_Is_Valid(string startDate)
        {
            // Act
            var result = await _controller.GetAvailableTimes(startDate);

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
        }

        [Test]
        public async Task Post_Should_Catch_The_Exception_When_Date_Is_Null()
        {
            // Act
            var result = await _controller.Post(null);

            // Assert
            Assert.IsInstanceOf<BadRequestObjectResult>(result);
        }

        [Test]
        public async Task Post_Should_Catch_The_Exception_When_Parameter_Is_Empty_Inside()
        {
            // Act
            var result = await _controller.Post(new Reservation());

            // Assert
            Assert.IsInstanceOf<BadRequestObjectResult>(result);
        }

        [Test]
        public async Task Post_Should_Return_Ok_When_Parameter_Is_Valid()
        {
            // Act
            var result = await _controller.Post(ValidReservation);

            // Assert
            Assert.IsInstanceOf<CreatedResult>(result);
        }

        public Reservation ValidReservation = new Reservation
        {
            Start = DateTime.Now,
            End = DateTime.Now.AddMinutes(60),
            Patient = new Patient
            {
                Name = "Jose",
                Phone = "646 85 57 47",
            }
        };
    }
}
