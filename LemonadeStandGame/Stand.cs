using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStandGame
{
    class Stand
    {
        public Inventory inventory;
        public Recipe recipe;

        public Stand()
        {
        }
        private void CheckRecipeVsInventory()
        {
            int product;
            if (inventory.lemons.Count() < recipe.ingredients[0] || inventory.sugar.Count() < recipe.ingredients[1] || inventory.ice.Count() < recipe.ingredients[2] || inventory.cups.Count() < recipe.ingredients[3])
            {
                product = 0;
                Console.WriteLine("");
                Console.WriteLine("**With your inventory you can make {0} pitchers of lemonade**", product);
            }
            else
            {
                int maxLemons = inventory.lemons.Count() / recipe.ingredients[0];
                int maxSugar = inventory.sugar.Count() / recipe.ingredients[1];
                int maxIce = inventory.ice.Count() / recipe.ingredients[2];
                int maxCups = inventory.cups.Count() / recipe.ingredients[3];
                product = new int[] { maxLemons, maxSugar, maxIce, maxCups }.Min();
                Console.WriteLine("");
                Console.WriteLine("**With your inventory you can make {0} pitchers of lemonade and {1} pints to sell**", product, product * 8);
            }
        }
    }
}
