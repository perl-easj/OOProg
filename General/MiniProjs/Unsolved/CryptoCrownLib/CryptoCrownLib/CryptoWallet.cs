    namespace CryptoCrownLib
{
    class CryptoWallet
    {
        private string _owner;

        public CryptoWallet(string owner)
        {
            _owner = owner;
        }

        public bool InsertCrown(CryptoCrown cc)
        {
            return cc.Owner == _owner && CryptoChain.Instance.Insert(cc);
        }

        public int Crowns
        {
            get { return CryptoChain.Instance.NoOfCrowns(_owner); }
        }

        public string Owner
        {
            get { return _owner; }
        }
    }
}