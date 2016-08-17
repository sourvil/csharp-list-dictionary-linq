using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_list_dictionary_linq
{
    public class Team
    {
        private string _name = "";
        private int _foundedYear = 0;
        private City _teamCity;
        public string Name { get { return _name; } set { _name = value; } }
        public int FoundedYear { get { return _foundedYear; } set { _foundedYear = value; } }
        public City TeamCity { get { return _teamCity; } set { _teamCity = value; } }

        private Stadium _teamStadium;

        public Stadium TeamStadium
        {
            get { return _teamStadium; }
            set { _teamStadium = value; }
        }

    }
}
