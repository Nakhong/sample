using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Study.Day4
{
    public class League
    {
        private String name;
        private List<Team> team = new List<Team>();
        private Country country;

        public String GetName()
        {
            return name;
        }

        public void SetName(String name)
        {
            this.name = name;
        }

        public List<Team> GetTeam()
        {
            return team;
        }

        public void SetTeam(List<Team> team)
        {
            this.team = team;
        }

        public Country getCountry() {
            return country;
        }

        public void setCountry(Country country)
        {
            this.country = country;
        }
    }
}
