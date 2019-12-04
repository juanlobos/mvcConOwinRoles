using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace WebApplicationOwin.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [Authorize(Roles = "Cliente")]
        public ActionResult Prueba()
        {
            return View();
        }

        public ActionResult About(string nombre)
        {
            var users = new Usuarios();
            
            var user = users.listaUsers().Where(z => z.Nombre == nombre).FirstOrDefault();
            string[] roles = user.Rol.Split(',');
            ViewBag.Message = "Your application description page.";
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, user.Nombre));
            foreach (var item in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, item));
            }
            
            var id = new ClaimsIdentity(claims,
                                        DefaultAuthenticationTypes.ApplicationCookie);

            var ctx = Request.GetOwinContext();
            var authenticationManager = ctx.Authentication;
            authenticationManager.SignIn(new AuthenticationProperties()
            {
                AllowRefresh = true,
                ExpiresUtc = DateTime.UtcNow.AddMinutes(2)
            }, id);

            return View();
        }
        [Authorize(Roles ="Persona")]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Salir()
        {
            var ctx = Request.GetOwinContext();
            var authenticationManager = ctx.Authentication;
            authenticationManager.SignOut();
            return RedirectToAction("Index");
        }
    }
}