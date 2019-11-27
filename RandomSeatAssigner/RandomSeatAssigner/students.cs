using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomSeatAssigner
{
    public class students
    {
       public String name { get; set; }
       public String status { get; set; }

        public int station { get; set; }

        public override string ToString()
        {
            return " {name} ";
        }


    }

    public class RootObject
    {
        public List<students> students { get; set; }
    }


}
