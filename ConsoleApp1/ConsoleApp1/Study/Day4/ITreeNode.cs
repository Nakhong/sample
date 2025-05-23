using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Study.Day4
{
    public interface ITreeNode
    {
        String GetName(); 
        void SetName(String name); 

        IEnumerable<ITreeNode> GetChildren(); 
    }
}
