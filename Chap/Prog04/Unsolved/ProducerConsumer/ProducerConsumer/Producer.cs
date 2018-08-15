namespace ProducerConsumer
{
    /// <summary>
    /// This class can produce objects of type T,
    /// and insert them into a Queue.
    /// </summary>
    /// <typeparam name="T">Type of objects produced</typeparam>
    public class Producer<T> where T : new()
    {
        private QueueWithLimit<T> _queue;
        private int _itemsProduced;

        /// <summary>
        /// Create a new producer.
        /// </summary>
        /// <param name="queue">Queue into which produced objects are inserted</param>
        public Producer(QueueWithLimit<T> queue)
        {
            _queue = queue;
            _itemsProduced = 0;
        }

        /// <summary>
        /// Produce a single object, and insert it into the Queue.
        /// </summary>
        public void Produce()
        {
            _queue.Insert(new T());
            _itemsProduced++;
        }

        /// <summary>
        /// Returns the total number of objects produced by this producer.
        /// </summary>
        public int ItemsProduced
        {
            get { return _itemsProduced; }
        }
    }
}