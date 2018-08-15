using System;
using System.Diagnostics;

namespace CryptoCrownLib
{
    public abstract class MinerBase : IMiner
    {
        #region Instance fields
        private Stopwatch _watch;
        private object _lock;
        #endregion

        #region Properties
        private string Owner { get; }
        private CryptoMine Mine { get; }
        private CryptoWallet Wallet { get; }

        public long CurrentMaxKey
        {
            get { return Mine.MaxKey; } 
        }
        #endregion

        #region Constructor
        protected MinerBase(string owner)
        {
            Owner = owner;
            Mine = new CryptoMine(Owner);
            Wallet = new CryptoWallet(Owner);

            _watch = new Stopwatch();
            _lock = new object();
        }
        #endregion

        #region Methods
        public void MineCryptoCrowns(int noOfCrownsToMine)
        {
            lock (_lock)
            {
                _watch.Restart();
            }

            while (Wallet.Crowns < noOfCrownsToMine)
            {
                MineSingleCryptoCrown();
            }

            lock (_lock)
            {
                Console.WriteLine();
                Console.WriteLine(
                    $"Done mining, got {Wallet.Crowns:D3} Crowns in {_watch.Elapsed.TotalSeconds:000.00} seconds");
            }
        }

        public abstract void MineSingleCryptoCrown();

        public bool AttemptToMineSingleCryptoCrown(long key)
        {
            CryptoCrown cc = Mine.Try(key);
            if (cc != null)
            {
                Wallet.InsertCrown(cc);
                ReportWalletContent();
                return true;
            }

            return false;
        }

        public virtual void OnFinished()
        {
            // Intentionally empty
        }

        private void ReportWalletContent()
        {
            lock (_lock)
            {
                Console.SetCursorPosition(0, 0);
                Console.WriteLine($"{Owner} now has {Wallet.Crowns:D3} Crowns, ({_watch.Elapsed.TotalSeconds:000.00}) secs.");
            }
        }
        #endregion
    }
}
