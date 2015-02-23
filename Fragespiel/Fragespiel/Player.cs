using System;

namespace Fragespiel
{
    class Player
    {
        public String Name { get; private set; }
        public int Points { get; set; }

        public Player(String name)
        {
            Name = name;
            Points = 0;
        }
    }
}
