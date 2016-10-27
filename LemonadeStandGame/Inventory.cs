using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStandGame
{
    class Inventory
    {
        public List<Lemon> lemons;
        public List<Sugar> sugar;
        public List<Ice> ice;
        public List<Cup> cups;
        public Inventory()
        {
            lemons = new List<Lemon>();
            sugar = new List<Sugar>();
            ice = new List<Ice>();
            cups = new List<Cup>();
        }
        public void AddLemon(int amount)
        {         
            for (int i = 0; i < amount; i++)
            {
                lemons.Add(new Lemon());
            }
        }
        public void AddSugar(int amount)
        {
            amount = ConvertSugarToTablespoons(amount);
            for (int i = 0; i < amount; i++)
            {
                sugar.Add(new Sugar());
            }
        }
        public void AddIce(int amount)
        {
            amount = ConvertIceBagToCups(amount);
            for (int i = 0; i < amount; i++)
            {
                ice.Add(new Ice());
            }
        }
        public void AddCup(int amount)
        {
            amount = ConvertCupBagToCups(amount);
            for (int i = 0; i < amount; i++)
            {
                cups.Add(new Cup());
            }
        }
        public void RemoveLemon(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                lemons.RemoveAt(0);
            }
        }
        public void RemoveSugar(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                sugar.RemoveAt(0);
            }
        }
        public void RemoveIce(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                ice.RemoveAt(0);
            }
        }
        public void RemoveCup(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                cups.RemoveAt(0);
            }
        }
        private int ConvertSugarToTablespoons(int amount)
        {
            amount = amount * 240;
            return amount;
        }
        private int ConvertIceBagToCups(int amount)
        {
            amount = amount * 10;
            return amount;
        }
        private int ConvertCupBagToCups(int amount)
        {
            amount = amount * 100;
            return amount;
        }

    }
}
