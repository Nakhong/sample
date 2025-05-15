using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Study.Day4
{
    public class Player
    {
        private String name;
        private String position;

        public String getName()
        {
            return name;
        }

        public void setName(String name)
        {
            this.name = name;
        }

        public String getPosition()
        {
            return position;
        }

        public void setPosition(String position)
        {
            this.position = position;
        }
    }
}
