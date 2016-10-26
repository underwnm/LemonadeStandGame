using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStandGame
{
    class Wallet
    {
        public double cash;
        public double startingCash;
        public Wallet()
        {
            startingCash = 20.00;
            cash = startingCash;
        }
        public bool CheckWallet(double amount)
        {
            return cash >= amount;
        }
    }
}
