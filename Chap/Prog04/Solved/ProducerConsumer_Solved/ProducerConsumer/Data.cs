namespace ProducerConsumer
{
    /// <summary>
    /// This class is intentionally simple. It just acts as an example
    /// of a class of which objects are produced/consumed. If an object
    /// is the N'th to be produced, Number will return N.
    /// </summary>
    public class Data
    {
        private int _number;
        private static int _objectsCreated = 0;

        public Data()
        {
            _objectsCreated++;
            _number = _objectsCreated;
        }

        public int Number
        {
            get { return _number; }
        }
    }
}