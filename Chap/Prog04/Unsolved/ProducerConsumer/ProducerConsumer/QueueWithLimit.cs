using System;
using System.Collections.Generic;

namespace ProducerConsumer
{
    /// <summary>
    /// This class defines a Queue with limited capacity.
    /// Elements are inserted with Insert, and removed with Remove.
    /// The Queue can be seeded with a number of initial objects.
    /// </summary>
    public class QueueWithLimit<T> where T : new()
    {
        #region Instance fields
        private Queue<T> _queue;
        private int _limit;
        private int _countInitial;  
        #endregion

        #region Constructor
        /// <summary>
        /// Create the Queue with the specified capacity
        /// and initial number of objects.
        /// </summary>
        public QueueWithLimit(int limit, int countInitial = 0)
        {
            _queue = new Queue<T>();
            _limit = limit;
            _countInitial = countInitial;

            for (int i = 0; i < countInitial; i++)
            {
                Insert(new T());
            }
        }
        #endregion

        #region Properties
        /// <summary>
        /// Return the current number of objects in the Queue
        /// </summary>
        public int CountCurrent
        {
            get { return _queue.Count; }
        }

        /// <summary>
        /// Return the initial number of objects in the Queue
        /// </summary>
        public int CountInitial
        {
            get { return _countInitial; }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Try to insert an object into the Queue.
        /// </summary>
        /// <param name="value">Object to insert.</param>
        /// <returns>True is insert was successful, otherwise false.</returns>
        public bool Insert(T value)
        {
            if (_queue.Count < _limit)
            {
                _queue.Enqueue(value);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Try to remove an object from the Queue. An 
        /// exception is thrown if the Queue is empty.
        /// </summary>
        /// <returns>Removed object</returns>
        public T Remove()
        {
            if (_queue.Count == 0)
            {
                throw new InvalidOperationException();
            }

            return _queue.Dequeue();
        } 
        #endregion
    }
}