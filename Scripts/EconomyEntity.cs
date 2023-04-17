using UnityEngine;

namespace GattaiEconomySystem
{
    /// <summary>
    /// Represents an abstract base class for entities that can hold a currency.
    /// </summary>
    public abstract class EconomyEntity : MonoBehaviour
    {
        /// <summary>
        /// The initial balance of the currency for the economy entity.
        /// </summary>
        [SerializeField, Tooltip("The initial balance of the currency for the economy entity.")] 
        protected int initialBalance;
        
        /// <summary>
        /// The currency associated with the economy entity.
        /// </summary>
        public Currency Currency { get; private set; }

        protected virtual void Awake()
        {
            Currency = new Currency(initialBalance);
        }
    }
}
