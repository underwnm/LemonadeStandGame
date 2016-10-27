using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStandGame
{
    class Player
    {
        public string name;
        public Wallet wallet;
        public Recipe recipe;
        public Stand stand;

        public Player(string name)
        {
            this.name = name;
            wallet = new Wallet();
            recipe = new Recipe();
            stand = new Stand(this);
        }
    }
}
