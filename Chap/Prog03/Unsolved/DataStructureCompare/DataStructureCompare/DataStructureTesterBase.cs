using System;
using System.Collections.Generic;

namespace DataStructureCompare
{
    /// <summary>
    /// Base class for classes testing a specific collection class.
    /// The methods from IDataStructureTester are implemented, but
    /// the specific action done in each iteration (the ...Statement
    /// methods) is sometimes implemented in this class (as virtual 
    /// methods), and somethimes deferred to the sub-classes 
    /// (as abstract methods).
    /// </summary>
    /// <typeparam name="T">
    /// Type of collection class to test
    /// </typeparam>
    public abstract class DataStructureTesterBase<T> : IDataStructureTester where T : ICollection<int>, new()
    {
        #region Instance fields
        private Random _generator;
        private T _collection;
        #endregion

        #region Constructor
        protected DataStructureTesterBase()
        {
            _generator = new Random();
            _collection = new T();
        }
        #endregion

        #region Properties
        public Random Generator
        {
            get { return _generator; }
        }

        public T Collection
        {
            get { return _collection; }
        }
        #endregion

        #region Implementation of IDataStructureTester
        public long InsertInitial(int noOfToInserts, int maxValue)
        {
            return TimedTester.MeasureRunTimeLoop(() => { InsertInitialStatement(Generator.Next(maxValue)); }, noOfToInserts);
        }

        public long InsertBack(int noOfToInserts, int maxValue)
        {
            return TimedTester.MeasureRunTimeLoop(() => { InsertBackStatement(Generator.Next(maxValue)); }, noOfToInserts);
        }

        public long InsertFront(int noOfToInserts, int maxValue)
        {
            return TimedTester.MeasureRunTimeLoop(() => { InsertFrontStatement(Generator.Next(maxValue)); }, noOfToInserts);
        }

        public long LookupRandom(int noOfLookups)
        {
            return TimedTester.MeasureRunTimeLoop(LookupRandomStatement, noOfLookups);
        }

        public long DeleteRandom(int noOfDeletes)
        {
            return TimedTester.MeasureRunTimeLoop(DeleteRandomStatement, noOfDeletes);
        }

        public long FindRandom(int noOfFinds, int maxValue)
        {
            return TimedTester.MeasureRunTimeLoop(() => { FindRandomStatement(Generator.Next(maxValue)); }, noOfFinds);
        }
        #endregion

        #region Virtual Insert methods (can be overrided in specific collection classes)
        public virtual void InsertInitialStatement(int valueToInsert)
        {
            Collection.Add(valueToInsert);
        }

        public virtual void InsertBackStatement(int valueToInsert)
        {
            Collection.Add(valueToInsert);
        }

        public virtual void InsertFrontStatement(int valueToInsert)
        {
            Collection.Add(valueToInsert);
        }

        public virtual void FindRandomStatement(int valueToFind)
        {
            bool found = Collection.Contains(valueToFind);
        }
        #endregion

        #region Abstract methods (must be overrided in specific collection classes)
        public abstract void LookupRandomStatement();
        public abstract void DeleteRandomStatement();
        #endregion
    }
}