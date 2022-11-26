using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AyrlyneAppLibrary.Models
{
    public class AirportConnectionModel
    {
        public int AirportConnectionID { get; set; }

        public int AirportID1 { get; set; }

        public int AirportID2 { get; set; }

        public AirportModel Airport1 { get; set; }

        public AirportModel Airport2 { get; set; }
    }
}
