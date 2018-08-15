namespace CryptoCrownLib
{
    public interface IMiner
    {
        void MineCryptoCrowns(int noOfCrownsToMine);
        void MineSingleCryptoCrown();
        bool AttemptToMineSingleCryptoCrown(long key);
        void OnFinished();
        long CurrentMaxKey { get; }
    }
}