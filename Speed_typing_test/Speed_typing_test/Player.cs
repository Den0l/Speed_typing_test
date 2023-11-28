using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Speed_typing_test
{
    internal class Player
    {
        public string name;
        public double cpm;
        public double cps;

        public Player(string gname, double gcpm, double gcps) 
        {
            name = gname;
            cpm = Math.Round(gcpm, 2);
            cps = Math.Round(gcps, 2);
        }

    }
}
