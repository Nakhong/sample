using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Study.Day4
{
    class Team
    {
        private String name;
        private List<Player> players = new List<Player>();

        public String getName()
        {
            return name;
        }

        public void setName(String name)
        {
            this.name = name;
        }

        public List<Player> getPlayers()
        {
            return players;
        }

        public void setPlayers(List<Player> players)
        {
            this.players = players;
        }
    }
}
