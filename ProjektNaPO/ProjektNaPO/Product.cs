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

        private static int counter;
        public int Id {get;set;}
        public int Amount;
        public string Name;
        public double Price;
        public KindOf Prod;

        public Product(string name, int amount, double price, KindOf prod)
        {
            Id = counter++;
            Name = name;
            Amount = amount;
            Price = price;
            Prod = prod;
        }

        public override string ToString()
        {
            return Name + " - Amount: " + Amount + " - Price: " + Price + " - Type: " + Prod;
        }
    }
}