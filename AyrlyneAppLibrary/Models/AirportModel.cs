using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AyrlyneAppLibrary.Models
{
    public class AirportModel
    {
        public int AirportID { get; set; }

        public string AirportName { get; set; }

        public string AirportType { get; set; }

        public int AirportRegionID { get; set; }//state attribute

        public string AirportCode { get; set; }

        public string Longitude { get; set; }

        public string Latitude { get; set; }

        public List<AirportConnectionModel> Connections { get; set; }

    }
}
