using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Study.Day6.Model
{
    public abstract class Common
    {
        public string Name { get; set; }
        public enum Position
        {
            //Director,// 이사
            //SeniorManager,// 수석
            //Manager,// 책임
            //SeniorAssistant,// 선임
            //Assistant// 전임
            이사,// 이사
            수석,// 수석
            책임,// 책임
            선임,// 선임
            전임// 전임
        }
    }
}
