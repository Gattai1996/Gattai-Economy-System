namespace GattaiEconomySystem
{
    public static class TradeSystem
    {
        public static bool AttemptToBuy(EconomyEntity buyer, EconomyEntity seller, IInventoryItem item)
        {
            if (buyer.Currency.CanAfford(item.Price))
            {
                buyer.Currency.SubtractFromBalance(item.Price);
                seller.Currency.AddToBalance(item.Price);
                return true;
            }

            return false;
        }

        public static bool AttemptToSell(EconomyEntity seller, EconomyEntity buyer, IInventoryItem item)
        {
            return AttemptToBuy(buyer, seller, item);
        }
    }
}
