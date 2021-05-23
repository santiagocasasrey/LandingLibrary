using LandingLibrary.Models;

namespace LandingLibrary
{
    public class RocketClass
    {
        private CoordinateModel LandingPosition { get; set; }

        /// <summary>
        /// Creates a rocket
        /// </summary>
        public RocketClass() { 
        
        }

        /// <summary>
        /// Set rocket landing coordinates
        /// </summary>
        /// <param name="landingPosition"></param>
        public void SetLandingPosition(CoordinateModel landingPosition) {
            if (LandingPosition == null)
            {
                LandingPosition = new CoordinateModel(landingPosition.GetX(), landingPosition.GetY());
            }
            else {
                LandingPosition.SetCoordinates(landingPosition.GetX(), landingPosition.GetY());
            }
        }

        /// <summary>
        /// Get landing coordinates
        /// </summary>
        /// <returns></returns>
        public CoordinateModel GetLandingPosition()
        {
            return LandingPosition;
        }

    }
}
