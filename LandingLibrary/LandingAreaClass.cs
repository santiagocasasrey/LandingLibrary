using LandingLibrary.Models;

namespace LandingLibrary
{
    public class LandingAreaClass
    {
        private CoordinateModel AreaStart { get; set; }
        private CoordinateModel AreaEnd { get; set; }
        private LandingPlatformClass LandingPlatform { get; set; }


        /// <summary>
        /// Create a landing area
        /// </summary>
        /// <param name="landingPlatform"></param>
        public LandingAreaClass() {
            AreaStart = new CoordinateModel(0, 0);
            AreaEnd = new CoordinateModel(100, 100);
        }
        /// <summary>
        /// Set landing platform in area
        /// </summary>
        /// <param name="landingPlatform"></param>
        public void SetLandingPlatform(LandingPlatformClass landingPlatform)
        {
            LandingPlatform = landingPlatform;
        }

        /// <summary>
        /// Get landing platform from area
        /// </summary>
        /// <returns></returns>
        public LandingPlatformClass GetLandingPlatform()
        {
            return LandingPlatform;
        }
    }
}
