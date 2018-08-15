using System;
// ReSharper disable UnusedVariable
#pragma warning disable 219

namespace WebShopV06
{
    public class InsertCodeHere
    {
        public void MyCode()
        {
            // The FIRST line of code should be BELOW this line

            double netPriceBook = 30;
            double netPriceDVD = 50;
            double netPriceGame = 100;

            int noOfBooksInOrder = 0;
            int noOfDVDsInOrder = 0;
            int noOfGamesInOrder = 0;

            double totalNetPrice = netPriceBook * noOfBooksInOrder + netPriceDVD * noOfDVDsInOrder + netPriceGame * noOfGamesInOrder;

            // SO#1
            bool receiveSpecialOffer1 = false;

            // SO#2
            bool receiveSpecialOffer2 = false;

            // SO#3
            bool receiveSpecialOffer3 = false;

            // SO#4
            bool receiveSpecialOffer4 = false;

            Console.WriteLine($"You ordered {noOfBooksInOrder} books, {noOfDVDsInOrder} DVDs and {noOfGamesInOrder} games");
            Console.WriteLine($"You qualify for special offer #1 : {receiveSpecialOffer1}");
            Console.WriteLine($"You qualify for special offer #2 : {receiveSpecialOffer2}");
            Console.WriteLine($"You qualify for special offer #3 : {receiveSpecialOffer3}");
            Console.WriteLine($"You qualify for special offer #4 : {receiveSpecialOffer4}");

            // The LAST line of code should be ABOVE this line
        }
    }
}