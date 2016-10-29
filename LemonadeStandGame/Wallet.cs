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
        public double startingInvestmentMoney;
        public Wallet()
        {
            startingInvestmentMoney = 20.00;
            money = startingInvestmentMoney;
        }
        public bool CheckWalletForEnoughMoney(double costOfGoods)
        {
            return money >= costOfGoods;
        }
    }
}
