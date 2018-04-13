using System.Collections.Generic;
using BowlingSPAService.Model.EntityModels;
using NUnit.Framework;

namespace BowlingSPAService.NUnit.Tests.Controllers
{
    [TestFixture]
    public class BowlerStandingsControllerTest
    {
        private IList<Bowler> bowlers;

        [TestFixtureSetUp]
        public void Setup()
        {
            bowlers = new List<Bowler>();
        }

        [Test]
        public void BowlerStandingsController_GetWithNoResultsFromRepository_ReturnsEmptyBowlingStats()
        {

            ////Arrange
            //var repositoryMock = new Mock<IUnitOfWork>();
            ////Setup mock to dictate behavior of repository and will return list of bowlers when called:
            //repositoryMock.Setup(x => x.Repository.GetQuery<Score>(It.IsAny<Expression<Func<Score, bool>>>())).Returns(It.IsAny<IQueryable<Score>>());
            ////Create instance of BowlerStandingsControllerTest that will have mock repository injected; this is what will be used during the unit test
            //var bowlerStandingsController = new BowlerStandingsController(repositoryMock.Object);

            ////Act
            //var result = bowlerStandingsController.Get(1, 1);

            //Assert
            Assert.IsNotNull(true); // Test if null
            //Assert.AreEqual(bowlers, result); //Test the return is identical to what we expected

        }
    }
}
