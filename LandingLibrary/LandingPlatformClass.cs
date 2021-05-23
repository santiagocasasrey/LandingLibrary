using LandingLibrary.Enums;
using LandingLibrary.Models;
using System.Collections.Generic;

namespace LandingLibrary
{
    public class LandingPlatformClass
    {
        private CoordinateModel PlatformStart { get; set; }
        private CoordinateModel PlatformEnd { get; set; }
        private CoordinateModel LastCheckedPosition { get; set; }
        private List<CoordinateModel> LandedRocketsList { get; set; } = new List<CoordinateModel>();

        /// <summary>
        /// Create a landing platform with the coordinates passed as params
        /// </summary>
        /// <param name="startPosition">Start point coordinates</param>
        /// <param name="endPosition">End point coordinates</param>
        public LandingPlatformClass(CoordinateModel startPosition, CoordinateModel endPosition) {
            PlatformStart = new CoordinateModel(startPosition.GetX(), startPosition.GetY());
            PlatformEnd = new CoordinateModel(endPosition.GetX(), endPosition.GetY());
        }

        /// <summary>
        /// Ask for coordinates to land on the platform
        /// </summary>
        /// <param name="position">Position asked</param>
        /// <returns>LandingPlatformResultEnum</returns>
        public string AskForLandingPosition(CoordinateModel position) {

            bool ItIsTheSameLastChecked = ItIsEqualTheLastCheckedPosition(position);
            if (ItIsTheSameLastChecked)
            {
                SetLastCheckedPosition(null);
                return LandingPlatformResults.GetResultsString(LandingPlatformResultEnum.Clash);
            }
            else
            {
                SetLastCheckedPosition(position);
            }

            bool IsNearOldPosition = CheckAndSaveLandPosition(position);
            if (IsNearOldPosition)
            {
                return LandingPlatformResults.GetResultsString(LandingPlatformResultEnum.Clash);
            }

            bool ItIsInside = ItIsInsideLandingPlatform(position);
            if (ItIsInside)
            {
                return LandingPlatformResults.GetResultsString(LandingPlatformResultEnum.OkLanding);
            }
            else
            {
                return LandingPlatformResults.GetResultsString(LandingPlatformResultEnum.OutPlatform);
            }
        }

        /// <summary>
        /// Checks if the rocket is inside the landing platform
        /// </summary>
        /// <param name="coordinates"></param>
        /// <returns>bool</returns>
        public bool ItIsInsideLandingPlatform(CoordinateModel coordinates) {
            bool result = true;

            if (PlatformStart.GetX() > coordinates.GetX() || PlatformStart.GetY() > coordinates.GetY()) { 
                result = false;
            }

            if (PlatformEnd.GetX() < coordinates.GetX() || PlatformEnd.GetY() < coordinates.GetY())
            {
                result = false;
            }
            return result;
        }

        /// <summary>
        /// Saves coordinates passed by param as the last checked position
        /// </summary>
        /// <param name="coordinates"></param>
        private void SetLastCheckedPosition(CoordinateModel coordinates) {
            LastCheckedPosition = coordinates;
        }

        /// <summary>
        /// Returns true if the coordinates passed as param are equal than the last coordinates checked.
        /// </summary>
        /// <param name="coordinates"></param>
        /// <returns></returns>
        private bool ItIsEqualTheLastCheckedPosition(CoordinateModel coordinates)
        {
            return LastCheckedPosition?.GetX() == coordinates.GetX() && LastCheckedPosition?.GetY() == coordinates.GetY();
        }

        /// <summary>
        /// Check if is trying to land next to previous position, if not it saves the new position.
        /// </summary>
        /// <param name="coordinates"></param>
        /// <returns></returns>
        private bool CheckAndSaveLandPosition(CoordinateModel coordinates) {
            bool result = IsPositionNextToAnother(coordinates);
            if (!result) LandedRocketsList.Add(coordinates);
            return result;
        }

        /// <summary>
        /// Check the previous landings to avoid landing next to a rocket
        /// </summary>
        /// <param name="coordinates"></param>
        /// <returns></returns>
        private bool IsPositionNextToAnother(CoordinateModel coordinates)
        {
            bool result = false;

            foreach (var LandRocket in LandedRocketsList)
            {
                var nextPositions = new List<CoordinateModel>();
                nextPositions.Add(new CoordinateModel(LandRocket.GetX() - 1, LandRocket.GetY() - 1));
                nextPositions.Add(new CoordinateModel(LandRocket.GetX(), LandRocket.GetY() - 1));
                nextPositions.Add(new CoordinateModel(LandRocket.GetX() + 1, LandRocket.GetY() - 1));

                nextPositions.Add(new CoordinateModel(LandRocket.GetX() - 1, LandRocket.GetY()));
                nextPositions.Add(new CoordinateModel(LandRocket.GetX() + 1, LandRocket.GetY()));

                nextPositions.Add(new CoordinateModel(LandRocket.GetX() - 1, LandRocket.GetY() + 1));
                nextPositions.Add(new CoordinateModel(LandRocket.GetX(), LandRocket.GetY() + 1));
                nextPositions.Add(new CoordinateModel(LandRocket.GetX() + 1, LandRocket.GetY() + 1));

                result = nextPositions.Find(x => x.GetX() == coordinates.GetX() && x.GetY() == coordinates.GetY()) != null;
                if (result) break;
            }
            return result;
        }
    }
}
