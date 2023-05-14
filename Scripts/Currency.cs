using System;
using UnityEngine;

namespace GattaiEconomySystem
{
    /// <summary>
    /// Represents a currency that has a balance, symbol, and icon
    /// </summary>
    [Serializable]
    public class Currency
    {
        [SerializeField, Tooltip("The initial balance of the currency")] 
        private int initialBalance;
        
        [SerializeField, Tooltip("The current balance of the currency")] 
        private int balance;
        
        [SerializeField, Tooltip("The symbol of the currency")] 
        private char symbol;
        
        [SerializeField, Tooltip("The icon of the currency")] 
        private Sprite icon;

        [SerializeField, Tooltip("Whether this is a soft currency, usually soft currencies can be acquired playing " +
                                 "the game without expending real money for it.")]
        private bool isSoftCurrency = true;

        public Action<int> OnBalanceChange;
        
        /// <summary>
        /// Gets the current balance of the currency.
        /// </summary>
        public int Balance => balance;

        /// <summary>
        /// Gets the symbol of the Currency.
        /// </summary>
        public char Symbol => symbol;

        /// <summary>
        /// Gets the icon of the Currency.
        /// </summary>
        public Sprite Icon => icon;

        /// <summary>
        /// Gets the boolean field that represents whether this is a soft currency.
        /// Usually soft currencies can be acquired playing the game without expending real money for it.
        /// </summary>
        public bool IsSoftCurrency => isSoftCurrency;

        /// <summary>
        /// The minimum balance value allowed for the currency.
        /// </summary>
        public virtual int MinimumBalance { get; set; }
        
        /// <summary>
        /// The maximum balance value allowed for the currency.
        /// </summary>
        public virtual int MaximumBalance { get; set; } = 9999999;

        /// <summary>
        /// Creates a new instance of the Currency class.
        /// </summary>
        public Currency()
        {
            balance = initialBalance;
        }
        
        /// <summary>
        /// Creates a new instance of the Currency class with the specified initial balance.
        /// </summary>
        /// <param name="initialBalance">The initial balance for the currency.</param>
        public Currency(int initialBalance)
        {
            this.initialBalance = initialBalance;
            balance = initialBalance;
        }

        /// <summary>
        /// Adds the specified value to the balance, and then clamps the balance to ensure that it doesn't exceed the
        /// maximum or go below the minimum value.
        /// </summary>
        /// <param name="value">The value to add to the balance.</param>
        public virtual void AddToBalance(int value)
        {
            balance += value;
            ClampBalance();
            OnBalanceChange?.Invoke(Balance);
        }

        /// <summary>
        /// Checks if the balance is sufficient to afford a certain cost, subtracts that cost from the balance if it
        /// can be afforded, and then clamps the balance.
        /// </summary>
        /// <param name="value">The value to check and subtract from the balance.</param>
        /// <returns>Whether can afford for the value or not.</returns>
        public virtual void SubtractFromBalance(int value)
        {
            balance -= value;
            ClampBalance();
            OnBalanceChange?.Invoke(Balance);
        }

        /// <summary>
        /// Checks if the balance is sufficient to afford a certain cost, subtracts that cost from the balance if it
        /// can be afforded, and then clamps the balance.
        /// </summary>
        /// <param name="value">The value to check and subtract from the balance.</param>
        /// <returns>Whether can afford for the value or not.</returns>
        public virtual bool CanAfford(int value)
        {
            return value <= balance;
        }

        /// <summary>
        /// Clamps the currency balance to the minimum and maximum values allowed.
        /// </summary>
        private void ClampBalance() => balance = Mathf.RoundToInt(Mathf.Clamp(balance, MinimumBalance, MaximumBalance));

        /// <summary>
        /// Gets the balance concatenated with the symbol.
        /// </summary>
        /// <param name="symbolAtFront">False by default. If true it makes the symbol be concatenated before the balance.</param>
        /// <returns>The concatenated balance with the symbol.</returns>
        public string GetFormattedBalance(bool symbolAtFront = false) => symbolAtFront ? $"{symbol} {balance}" : $"{balance} {symbol}";
    }
}
