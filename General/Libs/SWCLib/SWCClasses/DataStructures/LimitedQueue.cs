using System;
using System.Collections.Generic;

namespace SWCClasses.DataStructures
{
    public class LimitedQueue<T>
    {
        #region Instance fields
        private Queue<T> _queue;
        private int _limit;
        private object _lock;
        #endregion

        #region Constructor
        /// <summary>
        /// Create the Queue with the specified capacity limit.
        /// </summary>
        public LimitedQueue(int limit)
        {
            _queue = new Queue<T>();
            _limit = limit;
            _lock = new object();
        }
        #endregion

        #region Properties
        /// <summary>
        /// Return the current number of objects in the Queue
        /// </summary>
        public int CountCurrent
        {
            get
            {
                lock (_lock)
                {
                    return _queue.Count;
                }
            }
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
            lock (_lock)
            {
                if (_queue.Count < _limit)
                {
                    _queue.Enqueue(value);
                    return true;
                }

                return false;
            }
        }

        /// <summary>
        /// Try to remove an object from the Queue. An 
        /// exception is thrown if the Queue is empty.
        /// </summary>
        /// <returns>Removed object</returns>
        public T Remove()
        {
            lock (_lock)
            {
                if (_queue.Count == 0)
                {
                    throw new InvalidOperationException();
                }

                return _queue.Dequeue();
            }
        }
        #endregion
    }
}