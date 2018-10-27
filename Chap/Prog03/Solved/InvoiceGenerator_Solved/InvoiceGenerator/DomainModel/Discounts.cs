using System;
using System.Collections.Generic;
using System.Linq;

namespace InvoiceGenerator.DomainModel
{
    /// <summary>
    /// The intention with the Discount class is to store the rules
    /// for which discounts are given. It is assumed that only a single
    /// discount rule can exist for a specific product.
    /// 
    /// The idea is that once the rules have been defined, you can obtain
    /// the discount for a product in a given order by calling the method
    /// GetDiscountPercentage.
    /// </summary>
    public class Discounts
    {
        public Dictionary<string, Func<Order, int>> DiscountRules; 

        public Discounts()
        {
            DiscountRules = new Dictionary<string, Func<Order, int>>();

            // Rule #1: 15 % discount on sweaters, if more than one sweater is ordered.
            AddDiscountRule("Sweater", order => ProductCountHigherThan(order,"Sweater", 2, 15));

            // Rule #2: 20 % discount on belts, if more than two belts are ordered.
            AddDiscountRule("Belt", order => ProductCountHigherThan(order, "Belt", 3, 20));

            // Rule #3: 10 % discount on shirts, if total price for order (without tax) is at least 1000 kr.
            AddDiscountRule("Shirt", order => OrderTotalHigherThan(order, 1000, 10));

            // Rule #3: 25 % discount on sunglasses, if total price for order (without tax) is at least 1500 kr.
            AddDiscountRule("Sunglasses", order => OrderTotalHigherThan(order, 1500, 25));
        }

        public void AddDiscountRule(string productDescription, Func<Order, int> rule)
        {
            if (DiscountRules.ContainsKey(productDescription))
            {
                throw new ArgumentException($"Called AddDiscountRule with product {productDescription} : discount rule already present");
            }

            DiscountRules.Add(productDescription, rule);
        }

        public int GetDiscountPercentage(Order anOrder, Product aProduct)
        {
            if (DiscountRules.ContainsKey(aProduct.Description))
            {
                return DiscountRules[aProduct.Description](anOrder);
            }

            return 0; // Zero is the default discount, i.e. no discount.
        }

        private int ProductCountHigherThan(Order anOrder, string productDesc, int noToTrigger, int discount)
        {
            return anOrder.OrderLines
                       .Where(ol => ol.OrderedProduct.Description == productDesc)
                       .Select(ol => ol.Quantity)
                       .Sum() >= noToTrigger ? discount : 0;
        }

        private int OrderTotalHigherThan(Order anOrder, double amountToTrigger, int discount)
        {
            return anOrder.OrderLines
                .Select(ol => ol.OrderedProduct.Price * ol.Quantity)
                .Sum() >= amountToTrigger ? discount : 0;
        }
    }
}