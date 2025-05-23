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

        public String GetName()
        {
            return name;
        }

        public void SetName(String name)
        {
            this.name = name;
        }

        public String GetPosition()
        {
            return position;
        }

        public void SetPosition(String position)
        {
            this.position = position;
        }

    }
}
