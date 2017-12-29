using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektNaPO
{
    [Serializable]
    public class Product
    {
        public string Name;
        public int Amount;
        public double Price;
        public KindOf Prod;


        public enum KindOf
        {
            Book,
            Movie,
            Album,
            Game
        }

        public Product(string name, int amount, double price, KindOf prod)
        {
            Name = name;
            Amount = amount;
            Price = price;
            Prod = prod;
        }

        public override string ToString()
        {
            return (Name + " - Amount: " + Amount + " - Price: " + Price);
        }
    }
}
