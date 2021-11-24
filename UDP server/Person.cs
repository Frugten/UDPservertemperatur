using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UDP_server
{
    class Person
    {
        public string Name { get; set; }
        public string Occupation { get; set; }

        public override string ToString()
        {
            return $"{Name}: {Occupation}";
        }
    }
}
