using System;

namespace ProjektNaPO
{
    [Serializable]
    public class Product
    {
        public enum KindOf
        {
            Book,
            Movie,
            Album,
            Game
        }

        public int Amount;
        public string Name;
        public double Price;
        public KindOf Prod;

        public Product(string name, int amount, double price, KindOf prod)
        {
            Name = name;
            Amount = amount;
            Price = price;
            Prod = prod;
        }

        public override string ToString()
        {
            return Name + " - Amount: " + Amount + " - Price: " + Price;
        }
    }
}