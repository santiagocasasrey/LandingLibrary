using LandingLibrary;
using LandingLibrary.Enums;
using LandingLibrary.Models;
using NUnit.Framework;

namespace LandingLibraryTest
{
    [TestFixture]
    public class LandingPlatformTest
    {
        private LandingAreaClass LandingArea;
        private LandingPlatformClass LandingPlatform;
        private RocketClass Rocket1;
        private RocketClass Rocket2;

        [SetUp]
        public void SetUp()
        {
            LandingArea = new LandingAreaClass();
            Rocket1 = new RocketClass();
            Rocket2 = new RocketClass();
        }

        [Test]
        public void IsOkLandPosition_OK()
        {
            LandingPlatform = new LandingPlatformClass(new CoordinateModel(5, 5), new CoordinateModel(15, 15));
            LandingArea.SetLandingPlatform(LandingPlatform);
            Rocket1.SetLandingPosition(new CoordinateModel(5, 5));
            var result = LandingPlatform.AskForLandingPosition(Rocket1.GetLandingPosition());
            Assert.True(result.Equals(LandingPlatformResults.GetResultsString(LandingPlatformResultEnum.OkLanding)));
        }

        [Test]
        public void IsOutLandPosition_OK()
        {
            LandingPlatform = new LandingPlatformClass(new CoordinateModel(5, 5), new CoordinateModel(15, 15));
            LandingArea.SetLandingPlatform(LandingPlatform);
            Rocket1.SetLandingPosition(new CoordinateModel(16, 15));
            var result = LandingPlatform.AskForLandingPosition(Rocket1.GetLandingPosition());
            Assert.True(result.Equals(LandingPlatformResults.GetResultsString(LandingPlatformResultEnum.OutPlatform)));
        }

        [Test]
        public void IsSameLandingPositionThanLastChecked_OK()
        {
            LandingPlatform = new LandingPlatformClass(new CoordinateModel(5, 5), new CoordinateModel(15, 15));
            LandingArea.SetLandingPlatform(LandingPlatform);
            Rocket1.SetLandingPosition(new CoordinateModel(7, 8));
            Rocket2.SetLandingPosition(new CoordinateModel(7, 8));
            var result = LandingPlatform.AskForLandingPosition(Rocket1.GetLandingPosition());
            Assert.True(result.Equals(LandingPlatformResults.GetResultsString(LandingPlatformResultEnum.OkLanding)));
            result = LandingPlatform.AskForLandingPosition(Rocket2.GetLandingPosition());
            Assert.True(result.Equals(LandingPlatformResults.GetResultsString(LandingPlatformResultEnum.Clash)));
        }

        [Test]
        public void IsSameLandingPositionThanLastChecked_Only_One_OK()
        {
            LandingPlatform = new LandingPlatformClass(new CoordinateModel(5, 5), new CoordinateModel(15, 15));
            LandingArea.SetLandingPlatform(LandingPlatform);
            Rocket1.SetLandingPosition(new CoordinateModel(7, 8));
            Rocket2.SetLandingPosition(new CoordinateModel(7, 8));
            var result = LandingPlatform.AskForLandingPosition(Rocket1.GetLandingPosition());
            Assert.True(result.Equals(LandingPlatformResults.GetResultsString(LandingPlatformResultEnum.OkLanding)));
            result = LandingPlatform.AskForLandingPosition(Rocket2.GetLandingPosition());
            Assert.True(result.Equals(LandingPlatformResults.GetResultsString(LandingPlatformResultEnum.Clash)));
            result = LandingPlatform.AskForLandingPosition(Rocket2.GetLandingPosition());
            Assert.True(result.Equals(LandingPlatformResults.GetResultsString(LandingPlatformResultEnum.OkLanding)));
        }

        [Test]
        public void IsPositionNextToAnother_OK()
        {
            LandingPlatform = new LandingPlatformClass(new CoordinateModel(5, 5), new CoordinateModel(15, 15));
            LandingArea.SetLandingPlatform(LandingPlatform);
            Rocket1.SetLandingPosition(new CoordinateModel(7, 12));
            var result = LandingPlatform.AskForLandingPosition(Rocket1.GetLandingPosition());
            Assert.True(result.Equals(LandingPlatformResults.GetResultsString(LandingPlatformResultEnum.OkLanding)));
            Rocket2.SetLandingPosition(new CoordinateModel(6, 11));
            result = LandingPlatform.AskForLandingPosition(Rocket2.GetLandingPosition());
            Assert.True(result.Equals(LandingPlatformResults.GetResultsString(LandingPlatformResultEnum.Clash)));
            Rocket2.SetLandingPosition(new CoordinateModel(6, 12));
            result = LandingPlatform.AskForLandingPosition(Rocket2.GetLandingPosition());
            Assert.True(result.Equals(LandingPlatformResults.GetResultsString(LandingPlatformResultEnum.Clash)));
            Rocket2.SetLandingPosition(new CoordinateModel(6, 13));
            result = LandingPlatform.AskForLandingPosition(Rocket2.GetLandingPosition());
            Assert.True(result.Equals(LandingPlatformResults.GetResultsString(LandingPlatformResultEnum.Clash)));
            Rocket2.SetLandingPosition(new CoordinateModel(7, 11));
            result = LandingPlatform.AskForLandingPosition(Rocket2.GetLandingPosition());
            Assert.True(result.Equals(LandingPlatformResults.GetResultsString(LandingPlatformResultEnum.Clash)));
            Rocket2.SetLandingPosition(new CoordinateModel(7, 11));
            result = LandingPlatform.AskForLandingPosition(Rocket2.GetLandingPosition());
            Assert.True(result.Equals(LandingPlatformResults.GetResultsString(LandingPlatformResultEnum.Clash)));
            Rocket2.SetLandingPosition(new CoordinateModel(7, 12));
            result = LandingPlatform.AskForLandingPosition(Rocket2.GetLandingPosition());
            Assert.True(result.Equals(LandingPlatformResults.GetResultsString(LandingPlatformResultEnum.Clash)));
            Rocket2.SetLandingPosition(new CoordinateModel(7, 13));
            result = LandingPlatform.AskForLandingPosition(Rocket2.GetLandingPosition());
            Assert.True(result.Equals(LandingPlatformResults.GetResultsString(LandingPlatformResultEnum.Clash)));
            Rocket2.SetLandingPosition(new CoordinateModel(8, 11));
            result = LandingPlatform.AskForLandingPosition(Rocket2.GetLandingPosition());
            Assert.True(result.Equals(LandingPlatformResults.GetResultsString(LandingPlatformResultEnum.Clash)));
            Rocket2.SetLandingPosition(new CoordinateModel(8, 12));
            result = LandingPlatform.AskForLandingPosition(Rocket2.GetLandingPosition());
            Assert.True(result.Equals(LandingPlatformResults.GetResultsString(LandingPlatformResultEnum.Clash)));
            Rocket2.SetLandingPosition(new CoordinateModel(8, 13));
            result = LandingPlatform.AskForLandingPosition(Rocket2.GetLandingPosition());
            Assert.True(result.Equals(LandingPlatformResults.GetResultsString(LandingPlatformResultEnum.Clash)));
        }


        [Test]
        public void IsNotPositionNextToAnother_OK()
        {
            LandingPlatform = new LandingPlatformClass(new CoordinateModel(5, 5), new CoordinateModel(15, 15));
            LandingArea.SetLandingPlatform(LandingPlatform);
            Rocket1.SetLandingPosition(new CoordinateModel(7, 8));
            Rocket2.SetLandingPosition(new CoordinateModel(10, 14));
            var result = LandingPlatform.AskForLandingPosition(Rocket1.GetLandingPosition());
            Assert.True(result.Equals(LandingPlatformResults.GetResultsString(LandingPlatformResultEnum.OkLanding)));
            result = LandingPlatform.AskForLandingPosition(Rocket2.GetLandingPosition());
            Assert.True(result.Equals(LandingPlatformResults.GetResultsString(LandingPlatformResultEnum.OkLanding)));
        }
    }
}