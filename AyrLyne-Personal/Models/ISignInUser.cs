using System.Security.Claims;

namespace AyrLyne_Personal.Models
{
    public interface ISignInUser
    {
        string Fname { get; set; }
        string Lname { get; set; }
        string Email { get; set; }
        string UserLevel { get; set; }
        int UserID { get; set; }
        bool isLoggedIn { get; set; }
        int HomeAirportID { get; set; }


        void signIn(SignInUser user);
        void signOut();

        string getFirstName(ClaimsPrincipal claimsPrincipal);

        string getLastName(ClaimsPrincipal claimsPrincipal);
        

        string getEmail(ClaimsPrincipal claimsPrincipal);
        

        string getUserID(ClaimsPrincipal claimsPrincipal);

        void updateUserToClaims(ClaimsPrincipal claimsPrincipal);
    }
}