using System;

namespace WebShopV05
{
    public class InsertCodeHere
    {
        public void MyCode()
        {
            // The FIRST line of code should be BELOW this line

            double netPriceBook = 30;
            double netPriceDVD = 50;
            double netPriceGame = 100;

            int noOfBooksInOrder = 8;
            int noOfDVDsInOrder = 3;
            int noOfGamesInOrder = 2;

            // I have chosen a style where each part of the total price is
            // calculated explicitly. All parts are then added up.

            double taxPercentage = 10.0;
            double creditCardFeePercentage = 2.0;
            double shippingForAllItems = 49;

            double netPriceForBooks = netPriceBook * noOfBooksInOrder;
            double netPriceForDVDs = netPriceDVD * noOfDVDsInOrder;
            double netPriceForGames = netPriceGame * noOfGamesInOrder;

            double netPriceForAllItems = netPriceForBooks + netPriceForDVDs + netPriceForGames;

            double taxForAllItems = netPriceForAllItems * (taxPercentage / 100);

            double creditCardFeeForAllItems = (netPriceForAllItems + taxForAllItems + shippingForAllItems) *
                                              (creditCardFeePercentage / 100);

            double totalPrice = netPriceForAllItems + taxForAllItems + 
                                shippingForAllItems + creditCardFeeForAllItems;

            Console.WriteLine($"You ordered {noOfBooksInOrder} books, {noOfDVDsInOrder} DVDs and {noOfGamesInOrder} games");
            Console.WriteLine($"Total cost including tax, shipping and credit card fee: {totalPrice} kr.");

            // The LAST line of code should be ABOVE this line
        }
    }
}