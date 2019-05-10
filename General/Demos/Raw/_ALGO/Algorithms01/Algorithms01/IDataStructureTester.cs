namespace Algorithms01
{
    public interface IDataStructureTester
    {
        long AddInitial(int valuesToAdd, int maxValue);
        long InsertBack(int valuesToAdd, int maxValue);
        long InsertFront(int valuesToAdd, int maxValue);
        long LookupRandom(int numberOfLookups);
        long DeleteRandom(int numberOfDeletes);
        long FindRandom(int numberOfFinds, int maxValue);
    }
}