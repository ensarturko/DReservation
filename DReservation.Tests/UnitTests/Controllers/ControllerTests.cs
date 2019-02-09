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
        public async Task GetAvailableTimes_Should_Throw_Exception_When_Date_Is_Empty()
        {
            try
            {
                // Act
                var result = await _controller.GetAvailableTimes(string.Empty);

                // Assert
                Assert.Fail();
            }
            catch (Exception)
            {
                // ignored
            }
        }

        [Test]
        public async Task GetAvailableTimes_Should_Throw_Exception_When_Date_Is_Null()
        {
            try
            {
                // Act
                var result = await _controller.GetAvailableTimes(null);

                // Assert
                Assert.Fail();
            }
            catch (Exception)
            {
                // ignored
            }
        }

        [TestCase("ABCD")]
        [TestCase("1234")]
        [TestCase("1236/18/32")]
        [TestCase("1236-18-32")]
        [TestCase("1")]
        public async Task GetAvailableTimes_Should_Throw_Exception_When_StartingDate_IsNot_Valid(string startingDate)
        {
            try
            {
                // Act
                var result = await _controller.GetAvailableTimes(startingDate);

                // Assert
                Assert.Fail();
            }
            catch (Exception)
            {
                // ignored
            }
        }

        [Test]
        public async Task Post_Should_Return_ViewResult_When_Date_Is_Null()
        {
            // Act
            var result = await _controller.DoFinalReservation(null);

            // Assert
            Assert.IsInstanceOf<ViewResult>(result);
        }

        [Test]
        public async Task Post_Should_Return_ViewResult_When_Parameter_Is_Empty_Inside()
        {
            // Act
            var result = await _controller.DoFinalReservation(new Reservation());

            // Assert
            Assert.IsInstanceOf<ViewResult>(result);
        }

        [Test]
        public async Task Post_Should_Return_Ok_When_Parameter_Is_Valid()
        {
            // Act
            var result = await _controller.DoFinalReservation(ValidReservation);

            // Assert
            Assert.IsInstanceOf<ViewResult>(result);
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
