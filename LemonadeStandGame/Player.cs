﻿using System;
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
        public UserInterface display;
        public double money = 20.00;

        public Player(string Name)
        {
            name = Name;
        }
    }
}
