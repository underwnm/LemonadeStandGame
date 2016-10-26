using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStandGame
{
    class Wallet
    {
        public double money;
        public double startingMoney;
        public Wallet()
        {
            startingMoney = 20.00;
            money = startingMoney;
        }
        public bool CheckWallet(double amount)
        {
            return money >= amount;
        }
    }
}
