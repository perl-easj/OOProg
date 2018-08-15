using System;
// ReSharper disable UnusedParameter.Local

namespace Client
{
    class Program
    {
        // Reference to data model, selected at run-time.
        private static IModel _model;

        static void Main(string[] args)
        {
            // Configure the model by obtaining a data source factory
            _model = new Model(SelectSource());

            // Use the data model
            Use();

            Console.WriteLine("Application can be closed by pressing any key...");
            Console.ReadKey();
        }

        // Enables the user to select the specific data source at run-time.
        // This could also be achieved by using e.g. a configuration file.
        // Method returns a reference to a Factory object, but does not
        // expose the specific type of the object.
        static IDataSourceFactory SelectSource()
        {
            Console.Write("Select model (\"w\" for Web Service, \"e\" for Entity Framework)  ");
            string userInput = Console.ReadKey().KeyChar.ToString();
            Console.WriteLine();

            if (userInput == "w")
            {
                Console.WriteLine("Using Web Service...");
                return new WebServiceSourceFactory("http://localhost:1099/");
            }
            if (userInput == "e")
            {
                Console.WriteLine("Using Entity Framework...");
                return new EntityFrameworkSourceFactory();
            }

            return SelectSource();
        }

        // Simulates usage of the data model, by first loading data
        // and then printing the entire content of the data model.
        static void Use()
        {
            _model.LoadModel();
            _model.PrintModelContent();
        }
    }
}
