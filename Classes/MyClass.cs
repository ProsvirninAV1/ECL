using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECL.Classes
{
    class MyClass
    {
        public MyClass(uint myProperty)
        {
            MyProperty = myProperty;
        }

        public uint MyProperty { get; set; }
    }
}
