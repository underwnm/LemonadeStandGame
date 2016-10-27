using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LemonadeStandGame
{
    class UserInterface
    {
        public void DisplayWelcomeTemplate()
        {
            DisplayMenuMessage();
            AddSpace();
            DisplayMenuInstructions();
            AddSpace();
        }
        public void DisplayStoreTemplate(Store store, Player player)
        {
            ClearScreen();
            DisplayItemPrices(store);
            DisplayCurrentInventory(player);
            DisplayRecipe(player);
            player.stand.CheckRecipeVsInventory();
        }
        public void DisplayRecipeTemplate(Weather weather)
        {
            ClearScreen();
            DisplayTomorrowForecast(weather);
            DisplayGetRecipe();
        }
        public void DisplayGetRecipe()
        {
            Console.WriteLine("Create a recipe for tomorrow");
            Console.WriteLine("Each recipe creates a 1 gallon pitcher\nThis will create 10 pints to sell to potential customers");
            Console.WriteLine("");
        }
        public void DisplayMenuMessage()
        {
            Console.WriteLine("WELCOME TO LEMONADE STAND! THIS IS A GAME TO SEE WHO CAN GET THE HIGHEST SCORE!\n");
            Thread.Sleep(500);
            Console.WriteLine("-------------------------------------------------------------------------------");
            Console.WriteLine("\tIN THIS GAME YOU WILL BE IN CHARGE OF RUNNING YOUR OWN LEMONADE");
            Console.WriteLine("\tSTAND. YOU CAN COMPETE WITH ANY AMOUNT OF PEOPLE THAT YOU WANT.");
            Console.WriteLine("\tTHE GOAL IS TO MAKE THE HIGHEST PROFIT. SALES WILL BE AFFECTED BY");
            Console.WriteLine("\tYOUR RECIPE, THE WEATHER, AND THE PER GLASS PRICE OF YOUR RECIPE.");
            Thread.Sleep(500);
            Console.WriteLine("--------------------------------------------------------------------------------");
        }
        public void DisplayMenuNumberOfPeople()
        {
            Console.WriteLine("HOW MANY PEOPLE WILL BE PLAYING?");
            Console.WriteLine("TYPE YOUR ANSWER AND HIT ENTER");
        }
        public void DisplayMenuInstructions()
        {
            Console.WriteLine("TO MANAGE YOUR LEMONADE STAND, YOU WILL NEED TO MAKE THESE DECISIONS EVERY DAY.\n");
            Console.WriteLine("\t\t1. THE AMOUNT OF SUGAR, ICE, AND LEMONS");
            Console.WriteLine("\t\t2. WHAT PRICE TO SELL EACH GLASS FOR\n");
            Console.WriteLine("\tYOU WILL BEGIN WITH A TOTAL OF $20.00 CASH. YOU THEN");
            Console.WriteLine("\tCREATE A RECIPE WITH SUGAR, LEMONS, AND ICE. YOUR TOTAL COST");
            Console.WriteLine("\tTO MAKE LEMONADE WILL DEPEND ON YOUR RECIPE. YOUR EXPENSES");
            Console.WriteLine("\tARE THE SUM OF THE INGREDIANT COSTS IN YOUR RECIPE.");
        }
        public void DisplayDay(int day)
        {
            Console.WriteLine("On Day {0}", day);
        }
        public void ClearScreen()
        {
            Console.Clear();
        }
        public void AddSpace()
        {
            Console.WriteLine("");
        }
        public void DisplayItemPrices(Store store)
        {
            Console.WriteLine("");
            Console.WriteLine("These are today's prices");
            Console.WriteLine("------------------------------------");
            Console.WriteLine("A single lemon costs {0}", store.cost[0]);
            Console.WriteLine("A 240 Tbsp bag of sugar costs {0}", store.cost[1]);
            Console.WriteLine("A 10 cup bag of ice costs {0}", store.cost[2]);
            Console.WriteLine("A 100 pack of pint sized plastic cups cost {0}", store.cost[3]);
            Console.WriteLine("------------------------------------");
        }
        public void DisplayCurrentInventory(Player player)
        {
            Console.WriteLine("");
            Console.WriteLine("Let's check your supply...");
            Console.WriteLine("------------------------------------");
            Console.WriteLine("You have {0} lemons", player.stand.inventory.lemons.Count());
            Console.WriteLine("You have {0} tablespoons of sugar", player.stand.inventory.sugar.Count());
            Console.WriteLine("You have {0} cups of ice", player.stand.inventory.ice.Count());
            Console.WriteLine("You have {0} pint sized cups", player.stand.inventory.cups.Count());
            Console.WriteLine("You have ${0} available in cash", player.wallet.money.ToString("#.##"));
            Console.WriteLine("------------------------------------");
        }
        public void DisplayRecipe(Player player)
        {
            Console.WriteLine("");
            Console.WriteLine("Let's check your recipe...");
            Console.WriteLine("------------------------------------");
            Console.WriteLine("{0} lemons", player.recipe.ingredients[0]);
            Console.WriteLine("{0} tablespoon of sugar", player.recipe.ingredients[1]);
            Console.WriteLine("{0} cups of ice", player.recipe.ingredients[2]);
            Console.WriteLine("------------------------------------");
        }
        public void DisplayActualWeather(Weather weather)
        {
            Console.WriteLine("");
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine("    Weather Today: {0} and a High of {1}°", weather.weather[0], weather.weather[1]);
            Console.WriteLine("----------------------------------------------------------");
        }
        public void DisplayTomorrowForecast(Weather weather)
        {
            Console.WriteLine("");
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine("Tomorrow's weather forecast calls for {0} and a High of {1}°", weather.weather[0], weather.weather[1]);
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine("");
        }
        public void DisplayAtStand()
        {
            Console.WriteLine("");
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine("           TIME TO SETUP YOUR STAND FOR TODAY");
            Console.WriteLine("----------------------------------------------------------");
        }
        public void DisplayPintsSold(Player player)
        {
            Console.WriteLine("Today out of the {0} pints of lemonade you made...\nYou sold {1} to customers...", player.stand.pintsSold, player.stand.pitchers*player.stand.pintsPerPitcher);
        }
        public void DisplayProfit(Player player)
        {
            Console.WriteLine("Today's Income: ${0}", player.stand.dailyIncome.ToString("#.##"));
            Console.WriteLine("Today's Gross Proft: ${0}", player.stand.grossProfit.ToString("#.##"));
            Console.WriteLine("Total Net Profit: ${0}", player.totalNetProfit.ToString("#.##"));
            Console.WriteLine("Your Wallet: ${0}", player.wallet.money.ToString("#.##"));
        }
        public void DisplayHowManyPitchers()
        {
            Console.WriteLine("How many pitchers do you want to make for today?");
        }
        public void DisplayHowMuchPerPint()
        {
            Console.WriteLine("Enter the price per pint of lemonade for the day.");
        }
        public void DisplayEndOfGame(Player player)
        {
            Console.WriteLine("You have finished your 7 day project of running a lemonade stand.");
            Console.WriteLine("Total Net Profit: ${0}", player.totalNetProfit.ToString("#.##"));
        }
    }
}
