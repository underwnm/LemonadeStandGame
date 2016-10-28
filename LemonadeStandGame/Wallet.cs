using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStandGame
{
    class Wallet
    {
        public double cashInWallet;
        public double startingInvestmentMoney;
        public Wallet()
        {
            startingInvestmentMoney = 20.00;
            cashInWallet = startingInvestmentMoney;
        }
        public bool CheckWalletForEnoughMoney(double costOfGoods)
        {
            return cashInWallet >= costOfGoods;
        }
    }
}
