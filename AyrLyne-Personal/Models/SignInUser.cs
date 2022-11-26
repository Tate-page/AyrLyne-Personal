using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Xml.Linq;
using helper = AyrLyne_Personal.Helpers.ClaimsPrincipalHelper;
namespace AyrLyne_Personal.Models
{
    public class SignInUser : ISignInUser
    {
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string Email { get; set; }
        public bool isAdmin { get; set; }
        public int AirlineID { get; set; }

        public int UserID { get; set; }
        public bool isLoggedIn { get; set; }

        public int HomeAirportID { get; set; }

        public SignInUser()
        {
            this.Fname = "";
            this.Lname = "";
            this.Email = "";
            this.isAdmin = false;
            this.isLoggedIn = false;
        }
        public SignInUser(string fname, string lname, string email)
        {
            this.Fname = fname;
            this.Lname = lname;
            this.Email = email;
            this.isAdmin = false;
            this.isLoggedIn = isLoggedIn;
        }

        public void signIn(SignInUser user)
        {
            this.UserID = user.UserID;
            this.Fname = user.Fname;
            this.Lname = user.Lname;
            this.Email = user.Email;
            this.isAdmin = user.isAdmin;
            this.isLoggedIn = true;
        }

        public void signOut()
        {
            this.Fname = "";
            this.Lname = "";
            this.Email = "";
            this.isAdmin = false;
            this.isLoggedIn = false;
        }

        public string getFirstName(ClaimsPrincipal claimsPrincipal)
        {
            return helper.GetFirstName(claimsPrincipal);
        }

        public string getLastName(ClaimsPrincipal claimsPrincipal)
        {
            return helper.GetLastName(claimsPrincipal);
        }

        public string getEmail(ClaimsPrincipal claimsPrincipal)
        {
            return helper.GetEmail(claimsPrincipal);
        }

        public string getUserID(ClaimsPrincipal claimsPrincipal)
        {
            return helper.GetUserId(claimsPrincipal);
        }

        public void updateUserToClaims(ClaimsPrincipal claimsPrincipal)
        {
            this.Fname = this.getFirstName(claimsPrincipal);
            this.Lname = this.getLastName(claimsPrincipal);
            this.Email = this.getEmail(claimsPrincipal);
            this.UserID = Int32.Parse(this.getUserID(claimsPrincipal));
        }

    }
}
