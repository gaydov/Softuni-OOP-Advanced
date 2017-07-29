using System;
using System.Collections.Generic;

public class CoffeeMachine
{
    private int coins;

    public CoffeeMachine()
    {
        this.CoffeesSold = new List<CoffeeType>();
    }

    public IList<CoffeeType> CoffeesSold { get; }

    public void BuyCoffee(string size, string type)
    {
        CoffeeType currentCoffeeType;
        bool isTypeValid = Enum.TryParse(type, true, out currentCoffeeType);

        CoffeePrice currentCoffeePrice;
        bool isSizeValid = Enum.TryParse(size, true, out currentCoffeePrice);

        if (isTypeValid && isSizeValid)
        {
            if (this.coins >= (int)currentCoffeePrice)
            {
                this.CoffeesSold.Add(currentCoffeeType);
                this.coins = 0;
            }
        }
    }

    public void InsertCoin(string coin)
    {
        Coin currentCoin;

        if (Enum.TryParse(coin, true, out currentCoin))
        {
            this.coins += (int)currentCoin;
        }
    }
}
