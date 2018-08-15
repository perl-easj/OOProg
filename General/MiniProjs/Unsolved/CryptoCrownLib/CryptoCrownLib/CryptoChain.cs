using System;
using System.Collections.Generic;

namespace CryptoCrownLib
{
    class CryptoChain
    {
        #region Singleton implementation
        private static CryptoChain _instance;

        public static CryptoChain Instance
        {
            get { return _instance = _instance ?? new CryptoChain(); }
        }
        #endregion

        #region Instance field
        private List<CryptoCrown> _crowns;
        private long _nextValidKey;
        private long _maxKey;
        private double _scaling;
        private object _lock;
        #endregion

        #region Constructor
        private CryptoChain(long initialMaxKey = 1000000, double scaling = 1.1)
        {
            _crowns = new List<CryptoCrown>();
            _maxKey = initialMaxKey;
            _scaling = scaling;
            _lock = new object();
            _nextValidKey = NextValidKey;
        }
        #endregion

        #region Public properties
        public long MaxKey
        {
            get { return _maxKey; }
        }

        public long ValidKey
        {
            get { return _nextValidKey; }
        }
        #endregion

        #region Public methods
        public bool Insert(CryptoCrown cc)
        {
            if (cc.Key == _nextValidKey)
            {
                lock (_lock)
                {
                    _crowns.Add(cc);
                    _maxKey = NextMaxKey;
                    _nextValidKey = NextValidKey;
                }
                return true;
            }

            return false;
        }

        public int NoOfCrowns(string owner)
        {
            lock (_lock)
            {
                return _crowns.FindAll(cc => cc.Owner == owner).Count;
            }
        }
        #endregion

        #region Private properties
        private long NextMaxKey
        {
            get { return (_maxKey * _scaling > long.MaxValue) ? long.MaxValue : (long)(_maxKey * _scaling); }
        }

        private long NextValidKey
        {
            get
            {
                long nextKey = _maxKey / 7;

                lock (_lock)
                {
                    foreach (CryptoCrown crown in _crowns)
                    {
                        nextKey = (nextKey * crown.Key) + 311;
                    }
                }

                return Math.Abs(nextKey % MaxKey);
            }
        }
        #endregion
    }
}