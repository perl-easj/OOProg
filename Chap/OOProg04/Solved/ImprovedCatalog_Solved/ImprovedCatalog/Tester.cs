using System;
using ImprovedCatalog.CatalogBaseClasses.Interfaces;
using ImprovedCatalog.Model;

namespace ImprovedCatalog
{
    public class Tester
    {
        private DomainModel _model;

        public Tester()
        {
            _model = new DomainModel(true);
        }

        public void Run()
        {
            TestIterateOverAll(_model.Cars);
            TestIterateOverAll(_model.Movies);

            TestRead(_model.Cars, "AA 111");
            TestRead(_model.Cars, "DD 444");
            TestRead(_model.Cars, "XX 999");
            TestRead(_model.Movies, 2);
            TestRead(_model.Movies, 7);
            TestRead(_model.Movies, 3);

            TestIndexing(_model.Cars, "CC 333");
            TestIndexing(_model.Cars, "DD 444");
            TestIndexing(_model.Cars, "YY 888");
            TestIndexing(_model.Movies, 9);
            TestIndexing(_model.Movies, 1);
            TestIndexing(_model.Movies, 4);

            TestIterateOverCatalog(_model.Cars);
            TestIterateOverCatalog(_model.Movies);
        }

        /// <summary>
        /// Tests that we can
        /// 1) Retrieve a collection of values of type V from the catalog
        /// 2) Manually iterate over the returned collection.
        /// </summary>
        /// <typeparam name="V">Type of values stored in catalog</typeparam>
        private void TestIterateOverAll<V>(IAll<V> catalog, string desc = null)
        {
            Console.WriteLine($"{DescToDescription<V>(desc)}, iteration over All property...");
            foreach (V item in catalog.All)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Tests that we can
        /// 1) Use a given key to read a value from the given catalog, by calling Read.
        /// </summary>
        /// <typeparam name="K">Type for key for values stored in catalog</typeparam>
        /// <typeparam name="V">Type for values stored in catalog</typeparam>
        private void TestRead<K, V>(ICatalog<K, V> catalog, K key, string desc = null)
        {
            Console.WriteLine($"{DescToDescription<V>(desc)}, use of Read method...");
            Console.WriteLine($"Key {key} returns -> {catalog.Read(key)}");
            Console.WriteLine();
        }

        /// <summary>
        /// Tests that we can
        /// 1) Use a given key to read a value from the given catalog, by invoking the index operator.
        /// </summary>
        /// <typeparam name="K">Type for key for values stored in catalog</typeparam>
        /// <typeparam name="V">Type for values stored in catalog</typeparam>
        private void TestIndexing<K, V>(IIndexableCatalog<K, V> catalog, K key, string desc = null)
        {
            Console.WriteLine($"{DescToDescription<V>(desc)}, use of index operator...");
            Console.WriteLine($"Key {key} returns -> {catalog[key]}");
            Console.WriteLine();
        }

        /// <summary>
        /// Tests that we can
        /// 1) Iterate directly over the catalog itself.
        /// </summary>
        /// <typeparam name="V">Type of values stored in catalog</typeparam>
        private void TestIterateOverCatalog<V>(IEnumerableCatalog<V> catalog, string desc = null)
        {
            Console.WriteLine($"{DescToDescription<V>(desc)}, iteration over Catalog directly...");
            foreach (V item in catalog)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
        }

        private string DescToDescription<V>(string desc)
        {
            return $"Testing {desc ?? typeof(V).Name} Catalog";
        }
    }
}