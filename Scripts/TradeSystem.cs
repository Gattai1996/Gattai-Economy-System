using UnityEngine;

namespace GattaiEconomySystem
{
    /// <summary>
    /// A static class that handles trade operations, specifically buying and selling things using currencies.
    /// </summary>
    public static class TradeSystem
    {
        private static bool IsValidOperation(Currency buyerCurrency, Currency sellerCurrency) => 
            buyerCurrency.GetType() != sellerCurrency.GetType() || buyerCurrency.IsSoftCurrency != sellerCurrency.IsSoftCurrency;

        /// <summary>
        /// Attempts to buy a thing from the seller using the currency of the buyer for the specified price.
        /// </summary>
        /// <param name="buyerCurrency">The currency of the buyer.</param>
        /// <param name="sellerCurrency">The currency of the seller.</param>
        /// <param name="price">The price of the thing.</param>
        /// <returns>Returns `true` if the purchase was successful, and `false` if the buyer does not have enough funds to buy the thing.</returns>
        public static bool AttemptToBuy(Currency buyerCurrency, Currency sellerCurrency, int price)
        {
            if (IsValidOperation(buyerCurrency, sellerCurrency))
            {
                Debug.LogError("Attempt to make a operation using different currencies or soft currency settings is not allowed!");
                return false;
            }
            
            if (!buyerCurrency.CanAfford(price)) return false;
            buyerCurrency.SubtractFromBalance(price);
            sellerCurrency.AddToBalance(price);
            return true;
        }

        /// <summary>
        /// Attempts to sell a thing to a buyer using the currency of the seller for the specified price.
        /// </summary>
        /// <param name="sellerCurrency">The currency of the seller.</param>
        /// <param name="buyerCurrency">The currency of the buyer.</param>
        /// <param name="price">The price of the thing.</param>
        /// <returns>Returns `true` if the sale was successful, and `false` if the buyer does not have enough funds to buy the thing.</returns>
        public static bool AttemptToSell(Currency sellerCurrency, Currency buyerCurrency, int price) => 
            AttemptToBuy(buyerCurrency, sellerCurrency, price);
    }
}
