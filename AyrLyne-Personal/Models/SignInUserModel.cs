using AyrLyne_Personal.Components.CompenentModels;
using System.ComponentModel.DataAnnotations;

namespace AyrLyne_Personal.Models
{
    public class SignInUserModel
    {
        [Required]
        public string Fname { get; set; }

        [Required]
        public string Lname { get; set; }

        [Required]
        public int HomeAirportID { get; set; }

    }
}
