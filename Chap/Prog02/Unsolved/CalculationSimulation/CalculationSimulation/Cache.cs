namespace CalculationSimulation
{
    /// <summary>
    /// This class acts as a cache of already calculated results
    /// </summary>
    public class Cache
    {
        #region Instance fields
        private int[,] cacheValues;
        #endregion

        #region Constructor
        public Cache()
        {
            // Create a 5x5 cache of results
            cacheValues = new int[5, 5];

            for (int x = 0; x < 5; x++)
            {
                for (int y = 0; y < 5; y++)
                {
                    cacheValues[x, y] = -1; // -1 means "no result stored"
                }
            }
        }
        #endregion

        #region Properties
        /// <summary>
        /// Look up the value stored in cell [x,y]
        /// </summary>
        public int Lookup(int x, int y)
        {
            return cacheValues[x, y];
        }

        /// <summary>
        /// Stores the given value in cell [x,y]
        /// </summary>
        public void Insert(int x, int y, int value)
        {
            cacheValues[x, y] = value;
        } 
        #endregion
    }
}
