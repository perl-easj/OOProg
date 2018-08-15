using System;
using JustPullTheTrigger.GoodGuys;
// ReSharper disable UnusedParameter.Local

namespace JustPullTheTrigger
{
    public class Program
    {
        #region ReSharper Config
        public static bool _hint = false;
        private static string HintEnd
        {
            get { return _hint ? "?" : ""; }
        } 
        #endregion

        static void Main(string[] args)
        {
            Goverment.Instance.EliminateRussianBadGuy();

            Console.WriteLine();
            Console.Write("...THE END ");
            Console.WriteLine(HintEnd);

            Console.ReadKey();
        }
    }
}
