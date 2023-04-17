namespace GattaiEconomySystem
{
    public static class TradeSystem
    {
        public static bool AttemptToBuy(EconomyEntity buyer, EconomyEntity seller, int price)
        {
            if (buyer.Currency.CanAfford(price))
            {
                buyer.Currency.SubtractFromBalance(price);
                seller.Currency.AddToBalance(price);
                return true;
            }

            return false;
        }

        public static bool AttemptToSell(EconomyEntity seller, EconomyEntity buyer, int price)
        {
            return AttemptToBuy(buyer, seller, price);
        }
    }
}
