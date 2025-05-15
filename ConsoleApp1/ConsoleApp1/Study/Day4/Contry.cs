using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Study.Day4
{
    public class Contry
    {
        private String name;
        private List<League> leagues = new List<League>();

        public String getName()
        {
            return name;
        }

        public void setName(String name)
        {
            this.name = name;
        }

        public List<League> getLeagues()
        {
            return leagues;
        }

        public void setLeagues(List<League> leagues)
        {
            this.leagues = leagues;
        }
    }
}
