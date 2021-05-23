namespace LandingLibrary.Models
{
    public class CoordinateModel
    {
        private int X { get; set; }
        private int Y { get; set; }

        /// <summary>
        /// Create a coordinate object with the x and y params given
        /// </summary>
        /// <param name="x">x coordinate</param>
        /// <param name="y">y coordinate</param>
        public CoordinateModel(int x, int y) {
            X = x;
            Y = y;
        }

        /// <summary>
        /// Get x coordinate
        /// </summary>
        /// <returns>int</returns>
        public int GetX() {
            return X;
        }

        /// <summary>
        /// Get y coordinate
        /// </summary>
        /// <returns>int</returns>
        public int GetY()
        {
            return Y;
        }

        /// <summary>
        /// Set coordinates x and y with the params given
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void SetCoordinates(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
