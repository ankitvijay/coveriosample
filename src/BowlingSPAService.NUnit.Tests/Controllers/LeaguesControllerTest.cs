using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using BowlingSPAService.Model.EntityModels;
using BowlingSPAService.Repository.RepoTransactions;
using BowlingSPAService.WebAPI.Controllers.api;
using Moq;
using NUnit.Framework;

namespace BowlingSPAService.NUnit.Tests.Controllers
{
    [TestFixture]
    public class LeaguesControllerTest
    {
        private IList<League> leagues;

        [TestFixtureSetUp]
        public void Setup()
        {

            leagues = new List<League>()
            {
                new League()
                {
                    Id = 1,
                    Name = "Thursday Night Men's League"                    
                },
                new League()
                {
                    Id = 2,
                    Name = "Wednesday Night Mixed League"                    
                },
            };

        }

        [Test]
        public void LeaguesController_Get_ReturnsAllLeagues()
        {
            //Arrange
            var repositoryMock = new Mock<IUnitOfWork>();
            //Setup mock to dictate behavior of repository and it will return a list of leagues when called:
            repositoryMock.Setup(x => x.Repository.GetAll<League>()).Returns(leagues);
            //Create instance of leagues controller that will have mock repository injected; this is what will be used during the unit test
            var leaguesController = new LeaguesController(repositoryMock.Object);

            //Act
            var result = leaguesController.Get();

            //Assert
            repositoryMock.Verify(x => x.Repository.GetAll<League>(), Times.Once); // Ensure repository was called
            Assert.IsNotNull(result); // Test to make sure return is not null
            Assert.IsInstanceOf<IList<League>>(result);
            CollectionAssert.AreEqual(result.ToList(), leagues.ToList()); // Test the return is identical to what we expected

        }

        [Test]
        public void LeaguesController_GetWithValidLeagueId_ReturnsSingleLeague()
        {
            //Arrange
            const int leagueId = 1;
            var repositoryMock = new Mock<IUnitOfWork>();
            var singleLeague = leagues.Where(x => x.Id == leagueId).AsQueryable();
            //Setup mock to dictate behavior of repository and it will return a single league matching Id used in test when called:
            repositoryMock.Setup(x => x.Repository.GetQuery<League>(It.IsAny<Expression<Func<League, bool>>>())).Returns(singleLeague);
            //Create instance of leagues controller that will have mock repository injected; this is what will be used during the unit test
            var leaguesController = new LeaguesController(repositoryMock.Object);


            //Act
            var result = leaguesController.Get(leagueId);

            //Assert
            repositoryMock.Verify(x => x.Repository.GetQuery<League>(It.IsAny<Expression<Func<League, bool>>>()), Times.Once); // Ensure repository was called
            Assert.IsNotNull(result); // Test to make sure return is not null
            Assert.IsInstanceOf<League>(result); ;  // Test type
            Assert.AreEqual(result, singleLeague.SingleOrDefault()); // Test the return collection (with a single league) is identical to what we expected

        }

    }
}
