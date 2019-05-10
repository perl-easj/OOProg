using System;

namespace Algorithms01
{
    public abstract class DataStructureTesterBase<T> : IDataStructureTester
    {
        private Random _generator;
        private T _collection;

        protected DataStructureTesterBase(T collection)
        {
            _generator = new Random();
            _collection = collection;
        }

        public Random Generator
        {
            get { return _generator; }
        }

        public T Collection
        {
            get { return _collection; }
        }

        public long AddInitial(int valuesToAdd, int maxValue)
        {
            return TimedTester.MeasureRunTimeLoop(() => { AddInitialStatement(Generator.Next(maxValue)); }, valuesToAdd);
        }

        public long InsertBack(int valuesToAdd, int maxValue)
        {
            return TimedTester.MeasureRunTimeLoop(() => { InsertBackStatement(Generator.Next(maxValue)); }, valuesToAdd);
        }

        public long InsertFront(int valuesToAdd, int maxValue)
        {
            return TimedTester.MeasureRunTimeLoop(() => { InsertFrontStatement(Generator.Next(maxValue)); }, valuesToAdd);
        }

        public long LookupRandom(int numerofLookups)
        {
            return TimedTester.MeasureRunTimeLoop(LookupRandomStatement, numerofLookups);
        }

        public long DeleteRandom(int numberofDeletes)
        {
            return TimedTester.MeasureRunTimeLoop(DeleteRandomStatement, numberofDeletes);
        }

        public long FindRandom(int numberofFinds, int maxValue)
        {
            return TimedTester.MeasureRunTimeLoop(() => { FindRandomStatement(Generator.Next(maxValue)); }, numberofFinds);
        }

        public abstract void AddInitialStatement(int valueToInsert);
        public abstract void InsertBackStatement(int valueToInsert);
        public abstract void InsertFrontStatement(int valueToInsert);
        public abstract void LookupRandomStatement();
        public abstract void DeleteRandomStatement();
        public abstract void FindRandomStatement(int valueToFind);
    }
}