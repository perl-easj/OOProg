using System;
using System.Collections.Generic;
using System.Linq;
using DataAccess.DataSource;
using DataAccess.DBToolClasses;
using DataAccess.DomainClasses;

namespace DataAccess
{
    public class DataAccessTest
    {
        public static void Run()
        {
            Console.WriteLine("-------------- DBTool Test (Customer) --------------------");
            TestDBToolCustomer(new DBTool<Customer>());
            Console.WriteLine();
            Console.WriteLine();

            // UNCOMMENT THE BELOW LINES TO TEST DBToolAdapter
            //Console.WriteLine("-------------- DBToolAdapter Test (Customer) -------------");
            //TestDataSourceCustomer(new DBToolAdapter<Customer>());
            //Console.WriteLine();
            //Console.WriteLine();

            // UNCOMMENT THE BELOW LINES TO TEST DataSourceAdapter
            //Console.WriteLine("-------------- DataSourceAdapter Test (Car) --------------");
            //TestDataSourceCar(new DataSourceAdapter<Car>());
            //Console.WriteLine();
            //Console.WriteLine();
        }

        private static void TestDBToolCustomer(DBTool<Customer> custDB)
        {
            // Initialised
            PrintDBInfo(custDB, "init");

            // Read records from DB
            custDB.ReadFromDB();
            PrintDBInfo(custDB, "readFromDB");

            // Insert two records
            custDB.InsertRecord(new Customer("Erik", "11223344", NextKey(custDB.GetAllKeys().ToList())));
            custDB.InsertRecord(new Customer("Fiona", "44332211", NextKey(custDB.GetAllKeys().ToList())));
            PrintDBInfo(custDB, "insert");

            // Update an object
            Customer oldObj = custDB.GetRecord(3);
            Customer newObj = new Customer(oldObj.Name, "13371337", oldObj.Key);
            custDB.UpdateRecord(oldObj, newObj);
            PrintDBInfo(custDB, "update");

            // Try to remove three object (only two exist)
            custDB.RemoveRecord(2);
            custDB.RemoveRecord(8);
            custDB.RemoveRecord(4);
            PrintDBInfo(custDB, "delete");
        }

        private static void TestDataSourceCustomer(IDataSource<int, Customer> custDataSource)
        {
            // Initialised
            PrintDataSourceInfo(custDataSource, "init");

            // Read records from DB
            custDataSource.Load();
            PrintDataSourceInfo(custDataSource, "readFromDB");

            // Insert two records
            int newKeyA = NextKey(custDataSource.All.Keys.ToList());
            custDataSource.Create(newKeyA, new Customer("Erik", "11223344", newKeyA));
            int newKeyB = NextKey(custDataSource.All.Keys.ToList());
            custDataSource.Create(newKeyB, new Customer("Fiona", "44332211", newKeyB));
            PrintDataSourceInfo(custDataSource, "insert");

            // Update an object
            Customer oldObj = custDataSource.Read(3);
            Customer newObj = new Customer(oldObj.Name, "13371337", oldObj.Key);
            custDataSource.Update(newObj.Key, newObj);
            PrintDataSourceInfo(custDataSource, "update");

            // Try to remove three object (only two exist)
            custDataSource.Delete(2);
            custDataSource.Delete(8);
            custDataSource.Delete(4);
            PrintDataSourceInfo(custDataSource, "delete");
        }

        private static void TestDataSourceCar(IDataSource<int, Car> carDataSource)
        {
            // Initialised
            PrintDataSourceInfo(carDataSource, "init");

            // Read records from DB
            carDataSource.Load();
            PrintDataSourceInfo(carDataSource, "readFromDB");

            // Insert four records
            carDataSource.Create(NextKey(carDataSource.All.Keys.ToList()), new Car("ABC", 100000));
            carDataSource.Create(NextKey(carDataSource.All.Keys.ToList()), new Car("DEF", 120000));
            carDataSource.Create(NextKey(carDataSource.All.Keys.ToList()), new Car("GHI", 140000));
            carDataSource.Create(NextKey(carDataSource.All.Keys.ToList()), new Car("JKL", 160000));
            PrintDataSourceInfo(carDataSource, "insert");

            // Update an object
            Car oldObj = carDataSource.Read(3);
            Car newObj = new Car(oldObj.Plate, oldObj.Price + 15000);
            carDataSource.Update(3, newObj);
            PrintDataSourceInfo(carDataSource, "update");

            // Try to remove three object (only two exist)
            carDataSource.Delete(2);
            carDataSource.Delete(8);
            carDataSource.Delete(4);
            PrintDataSourceInfo(carDataSource, "delete");
        }

        private static void PrintDBInfo<T>(DBTool<T> dbTool, string dbOperation) where T : class, IHasKey
        {
            Console.WriteLine($"(DBTool) Number of records after DB {dbOperation}: {dbTool.NoOfRecords()}");
            foreach (var key in dbTool.GetAllKeys())
            {
                Console.WriteLine($"Record key: {key}");
                Console.WriteLine($"Record : {dbTool.GetRecord(key)}");
            }
            Console.WriteLine();
        }

        private static void PrintDataSourceInfo<TKey, TData>(IDataSource<TKey, TData> source, string dbOperation)
        {
            Console.WriteLine($"(IDataSource) Number of records after DB {dbOperation}: {source.Count}");
            foreach (var keyAndObj in source.All)
            {
                Console.WriteLine($"Record key: {keyAndObj.Key}");
                Console.WriteLine($"Record : {keyAndObj.Value}");
            }
            Console.WriteLine();
        }

        private static int NextKey(List<int> keys)
        {
            return keys.Count != 0 ? keys.Max() + 1 : 1;
        }
    }
}