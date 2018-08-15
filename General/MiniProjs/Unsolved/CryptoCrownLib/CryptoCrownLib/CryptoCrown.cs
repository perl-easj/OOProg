namespace CryptoCrownLib
{
    class CryptoCrown
    {
        private const string NoOwner = "NoOwner";

        private long _key;
        private string _owner;

        public CryptoCrown(long key, string owner = NoOwner)
        {
            _key = key;
            _owner = owner;
        }

        public long Key
        {
            get { return _key; }
        }

        public string Owner
        {
            get { return _owner; }
            set { _owner = value; }
        }
    }   
}