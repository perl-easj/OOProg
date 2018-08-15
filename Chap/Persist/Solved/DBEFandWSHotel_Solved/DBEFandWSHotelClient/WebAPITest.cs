using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DBEFandWSHotelClient
{
    public class WebAPITest<T>
    {
        #region Instance fields
        private IWebAPIAsync<T> _webAPI;
        private string _tableName;
        #endregion

        #region Constructor
        public WebAPITest(IWebAPIAsync<T> webApi, string tableName)
        {
            _webAPI = webApi;
            _tableName = tableName;
        }
        #endregion

        #region Test methods for all five REST API methods
        public async Task RunAPITestLoad()
        {
            PrintHeader("Load");
            await LoadAndPrint("Load");
        }

        public async Task RunAPITestCreate(T obj)
        {
            await RunAPITest("Create", () => _webAPI.Create(obj));
        }

        public async Task RunAPITestRead(int key)
        {
            PrintHeader("Read");
            Task<T> readTask = _webAPI.Read(key);
            await readTask;
            NeatPrintSingle(readTask.Result, "after Read");
        }

        public async Task RunAPITestUpdate(int key, T obj)
        {
            await RunAPITest("Update", () => _webAPI.Update(key, obj));
        }

        public async Task RunAPITestDelete(int key)
        {
            await RunAPITest("Delete", () => _webAPI.Delete(key));
        }
        #endregion

        #region Private helper methods for test execution
        private async Task RunAPITest(string testOperation, Func<Task> APIOperation)
        {
            PrintHeader(testOperation);
            await LoadAndPrint($"before {testOperation}");
            await APIOperation();
            await LoadAndPrint($"after {testOperation}");
        }

        private async Task LoadAndPrint(string testOperation)
        {
            Task<List<T>> loadTask = _webAPI.Load();
            await loadTask;
            NeatPrintMultiple(loadTask.Result, $"{_tableName} {testOperation}");
        }

        private void PrintHeader(string testOperation)
        {
            Console.WriteLine($"Starting test of {testOperation} for {_tableName}");
            Console.WriteLine();
        }

        private void NeatPrintMultiple(List<T> records, string description)
        {
            NeatPrint(records, $"{description} - No records found", $"{description} - All records", () =>
            {
                foreach (var record in records)
                {
                    Console.WriteLine(record);
                }
            });
        }

        private void NeatPrintSingle(T record, string description)
        {
            NeatPrint(record, $"{description} - No record found", $"{description} - Got record", () =>
            {
                Console.WriteLine(record);
            });
        }

        private void NeatPrint<U>(U obj, string nulldescription, string description, Action printFunction)
        {
            if (obj == null)
            {
                Console.WriteLine(nulldescription);
                return;
            }

            Console.WriteLine(description);
            Console.WriteLine("-----------------------------------");
            printFunction();
            Console.WriteLine("-----------------------------------");
            Console.WriteLine();
        }
        #endregion
    }
}