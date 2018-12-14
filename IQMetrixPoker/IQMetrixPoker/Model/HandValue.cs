using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IQMetrixPoker.Model
{
    public struct HandValue
    {
        public int Total { get; set; }
        public int[] HighCard { get; set; }        
        public int[] HighestKicker { get; set; }
    }
}
