using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AyrlyneAppLibrary.Models
{
    public class UserModel
    {
        public int UserID { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string Email { get; set; }
        public int HomeAirportID { get; set; }
        public string? UserAirlineID { get; set; }
        public bool isAdmin { get; set; }

        //ticket history
    }
}
