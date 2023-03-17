using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppFirst.Models;

namespace WebAppFirst.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        NorthwindOriginalEntities db = new NorthwindOriginalEntities();
        public ActionResult Login()

        {

            return View();

        }



        [HttpPost]

        public ActionResult Authorize(Logins LoginModel)

        {

            NorthwindOriginalEntities db = new NorthwindOriginalEntities();



            //Haetaan käyttäjän/Loginin tiedot annetuilla tunnustiedoilla tietokannasta LINQ -kyselyllä

            var LoggedUser = db.Logins.SingleOrDefault(x => x.UserName == LoginModel.UserName && x.PassWord == LoginModel.PassWord);



            if (LoggedUser != null)

            {

                ViewBag.LoginMessage = "Successfull login";

                ViewBag.LoggedStatus = "In";

                Session["UserName"] = LoggedUser.UserName;

                return RedirectToAction("Index", "Home"); //Tässä määritellään mihin onnistunut kirjautuminen johtaa --> Home/Index

            }

            else

            {

                ViewBag.LoginMessage = "Login unsuccessfull";

                ViewBag.LoggedStatus = "Out";

                LoginModel.LoginErrorMessage = "Tuntematon käyttäjätunnus tai salasana.";

                return View("Login", LoginModel);

            }

        }



        public ActionResult LogOut()

        {

            Session.Abandon();

            ViewBag.LoggedStatus = "Out";

            return RedirectToAction("Index", "Home"); //Uloskirjautumisen jälkeen pääsivulle

        }
    }
}