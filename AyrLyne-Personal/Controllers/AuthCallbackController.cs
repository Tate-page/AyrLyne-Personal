using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Threading;
using Microsoft.AspNetCore.Components.Server.Circuits;
using System.Net;
using Google.Apis.Auth;
using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using System.Collections.Generic;
using AyrLyne_Personal.Data;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using AyrLyne_Personal.Models;

namespace AyrLyne_Personal.Controllers
{
    [ApiController]
    [Route("AuthCallback")]
    public class AuthCallbackController : Controller
    {
        public AuthCallbackController()
        {
        }
        public IActionResult Index()
        {
            return Redirect("~/AuthCallback/CallBack");
        }

        [HttpGet("SignOut")]
        public  IActionResult SignOut(HttpContext tempContext)
        {
            string scheme =  CookieAuthenticationDefaults.AuthenticationScheme;
            var signoutTask = tempContext.SignOutAsync(scheme);
            var redirect = LocalRedirect("/");
            return redirect;
            
        }

        [HttpPost]
        public async Task<IActionResult> CallBack([FromForm] GoogleSignInFormData data)
        {
            if(data is null)
            {
                return StatusCode(500);
            }

            string cookieCsrfToken = HttpContext.Request.Cookies["g_csrf_token"];
            if (string.IsNullOrWhiteSpace(cookieCsrfToken))
            {
                return StatusCode(500);
            }
            string postBodyCsrfToken = data.g_csrf_token;
            if (postBodyCsrfToken.IsNullOrEmpty())
            {
                return StatusCode(500);
            }
            if(postBodyCsrfToken.ToString() != cookieCsrfToken.ToString())
            {
                return StatusCode(500);
            }
            string token = data.credential;
            GoogleJsonWebSignature.Payload payload;
            try
            {
                payload = await GoogleJsonWebSignature.ValidateAsync(token);
                Console.WriteLine("User Auth Info:");
                Console.WriteLine("UserID:" + payload.Subject);
                Console.WriteLine("Name:" + payload.Name);
                Console.WriteLine("Email:" + payload.Email);
                Console.WriteLine("--------------");
            }
            catch(Exception ex){
                Console.WriteLine(ex);
                return StatusCode(500);
            }

            string mailEncoded = WebUtility.UrlEncode(payload.Email);
            string nameEncoded = WebUtility.UrlEncode(payload.Name);

            string url = $"/HandleSignIn";
            string scheme = CookieAuthenticationDefaults.AuthenticationScheme;
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, payload.Name),
                new Claim(ClaimTypes.Email, payload.Email),
                new Claim(ClaimTypes.Role, "customer")
            };
            
            ClaimsIdentity googleUser = new ClaimsIdentity(claims, scheme);
            ClaimsPrincipal principal = new ClaimsPrincipal(googleUser);
            AuthenticationProperties properties = new AuthenticationProperties { IsPersistent = true, RedirectUri = Request.Host.Value };
            await HttpContext.SignInAsync(scheme, principal, properties);
            var ret = base.Redirect(url);
            return ret;
        }
    }
}
