using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Study.Day4
{
    public class Country
    {
        private String name;
        private List<League> leagues = new List<League>();

        public String GetName()
        {
            return name;
        }

        public void SetName(String name)
        {
            this.name = name;
        }

        public List<League> GetLeagues()
        {
            return leagues;
        }

        public void SetLeagues(List<League> leagues)
        {
            this.leagues = leagues;
        }
    }
}
