using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAssembly
{
    public class ArithmeticOperation
    {
        public int numA { get; set; }
        public int numB { get; set; }

        public int sum()
        {
            return numA + numB;
        }

        public int sus()
        {
            return numA - numB;
        }

    }
}
