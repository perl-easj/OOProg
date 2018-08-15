namespace CryptoCrownLib
{
    class CryptoMine
    {
        private string _owner;

        public CryptoMine(string owner)
        {
            _owner = owner;
        }

        public string Owner
        {
            get { return _owner; }
        }

        public long MaxKey
        {
            get { return CryptoChain.Instance.MaxKey; }
        }

        public CryptoCrown Try(long key)
        {
            return CryptoChain.Instance.ValidKey == key ? new CryptoCrown(key, _owner) : null;
        }
    }
}