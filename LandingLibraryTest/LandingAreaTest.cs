using LandingLibrary;
using LandingLibrary.Models;
using NUnit.Framework;

namespace LandingLibraryTest
{
    [TestFixture]
    public class LandingAreaTest
    {
        private LandingAreaClass LandingArea;
        private LandingPlatformClass LandingPlatform;

        [SetUp]
        public void SetUp()
        {
            LandingArea = new LandingAreaClass();
            LandingPlatform = new LandingPlatformClass(new CoordinateModel(5, 5), new CoordinateModel(15, 15));
            LandingArea.SetLandingPlatform(LandingPlatform);
        }

        [Test]
        public void IsThereLandingPlatform_OK()
        {
            LandingArea.GetLandingPlatform();
            var result = LandingArea.GetLandingPlatform() != null;
            Assert.True(result);
        }
    }
}