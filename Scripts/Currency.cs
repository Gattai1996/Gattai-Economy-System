using System;
using UnityEngine;

namespace GattaiEconomySystem
{
    /// <summary>
    /// A class that represents a currency which balance can be added and spent.
    /// </summary>
    [Serializable]
    public class Currency
    {
        /// <summary>
        /// The current balance of the currency.
        /// </summary>
        [SerializeField] private int balance;
        
        /// <summary>
        /// Gets the current balance of the currency.
        /// </summary>
        public int Balance => balance;

        /// <summary>
        /// The minimum balance value allowed for the currency.
        /// </summary>
        public const int MINIMUM_BALANCE = 0;
        
        /// <summary>
        /// The maximum balance value allowed for the currency.
        /// </summary>
        public const int MAXIMUM_BALANCE = 9999999;

        /// <summary>
        /// Creates a new instance of the Currency class with the specified initial balance.
        /// </summary>
        /// <param name="initialBalance">The initial balance for the currency.</param>
        public Currency(int initialBalance)
        {
            balance = initialBalance;
        }

        /// <summary>
        /// Adds the specified value to the balance, and then clamps the balance to ensure that it doesn't exceed the
        /// maximum or go below the minimum value.
        /// </summary>
        /// <param name="value">The value to add to the balance.</param>
        public void AddToBalance(int value)
        {
            balance += value;
            ClampBalance();
        }

        /// <summary>
        /// Checks if the balance is sufficient to afford a certain cost, subtracts that cost from the balance if it
        /// can be afforded, and then clamps the balance.
        /// </summary>
        /// <param name="value">The value to check and subtract from the balance.</param>
        /// <returns>Whether can afford for the value or not.</returns>
        public void SubtractFromBalance(int value)
        {
            balance -= value;
            ClampBalance();
        }

        /// <summary>
        /// Checks if the balance is sufficient to afford a certain cost, subtracts that cost from the balance if it
        /// can be afforded, and then clamps the balance.
        /// </summary>
        /// <param name="value">The value to check and subtract from the balance.</param>
        /// <returns>Whether can afford for the value or not.</returns>
        public bool CanAfford(int value)
        {
            return value <= balance;
        }

        /// <summary>
        /// Clamps the currency balance to the minimum and maximum values allowed.
        /// </summary>
        private void ClampBalance()
        {
            balance = Mathf.RoundToInt(Mathf.Clamp(balance, MINIMUM_BALANCE, MAXIMUM_BALANCE));
        }
    }
}
