﻿namespace DeltaSigmaPhiWebsite.Tests.Controllers
{
    using Data.Interfaces;
    using Data.UnitOfWork;
    using DeltaSigmaPhiWebsite.Controllers;
    using Models;
    using Moq;
    using NUnit.Framework;
    using System.Linq;
    using System.Transactions;

    [TestFixture]
    public class AccountControllerTest
    {
        private TransactionScope scope;

        [SetUp]
        public void SetUp()
        {
            scope = new TransactionScope();
        }

        [TearDown]
        public void TearDown()
        {
            scope.Dispose();
        }

        [Test]
        public void GetUserIdListAsFullName()
        {
            // Arrange
            var uowMock = new Mock<IUnitOfWork>();
            var repMock = new Mock<IMembersRepository>();
            repMock.Setup(m => m.GetAll()).Returns(new []
            {
                new Member { UserId = 1, FirstName = "FN1", LastName = "LN1" },
                new Member { UserId = 2, FirstName = "FN2", LastName = "LN2" },
                new Member { UserId = 3, FirstName = "FN3", LastName = "LN3" },
            }.AsQueryable());
            uowMock.Setup(m => m.MemberRepository).Returns(repMock.Object);
            var controller = new AccountController(uowMock.Object);
            // Act
            //var actual = controller.GetUserIdListAsFullName();
            // Assert
            //Assert.IsInstanceOf<ActionResult>(actual);
        }

    }
}
