using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Study.Day4
{
    public class Team
    {
        private String name;
        private List<Player> players = new List<Player>();

        public String GetName()
        {
            return name;
        }

        public void SetName(String name)
        {
            this.name = name;
        }

        public List<Player> GetPlayers()
        {
            return players;
        }

        public void SetPlayers(List<Player> players)
        {
            this.players = players;
        }
    }
}
