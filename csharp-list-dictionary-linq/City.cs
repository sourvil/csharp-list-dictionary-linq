using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_list_dictionary_linq
{
    public class City
    {
        private string _name = "";
        private int _code = 0;
        public string Name { get { return _name; } set { _name = value; } }
        public int Code { get { return _code; } set { _code = value; } }
    }
}
