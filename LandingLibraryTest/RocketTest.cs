using LandingLibrary;
using LandingLibrary.Models;
using NUnit.Framework;

namespace LandingLibraryTest
{
    [TestFixture]
    public class RocketTest
    {
        private RocketClass rocket;

        [SetUp]
        public void SetUp()
        {
            rocket = new RocketClass();
        }

        [Test]
        public void SetAndGetRocketCoordinates_OK()
        {
            rocket.SetLandingPosition(new CoordinateModel(7, 9));
            var result = rocket.GetLandingPosition().GetX();
            Assert.True(result == 7);
            result = rocket.GetLandingPosition().GetY();
            Assert.True(result == 9);
        }
    }
}