using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TradingStation.Globals;
using TradingStation.Models;
using TradingStation.Services;

namespace TradingStation.Controllers
{
    public class UserController : Controller
    {
        public const string pepperString = "hallowelt";

        public static List<User> users = new List<User>();

        // GET: User
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View(users);
        }

        // GET
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }
        /// <summary>
        ///  LOGIN
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // POST
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(User u)
        {
            bool success = false;

            User userFromDB = users.Where(x => x.Email == u.Email).FirstOrDefault();
            if (userFromDB != null)
            {

                var sha = System.Security.Cryptography.SHA512Managed.Create(); // erstellt sha Instanz

                // erstellt ein ByteArray aus Passwort+Pepper+Salt
                byte[] userEingabeArray = System.Text.Encoding.UTF8.GetBytes(u.Password + UserController.pepperString + userFromDB.Salt);


                // erstellt einen SHA512Managed-Hash aus dem "normalem" ByteArray
                byte[] userShaArray = sha.ComputeHash(userEingabeArray);

                // Obfuscation - Verdunklung => Konvertiert den "normalen" String zu einem Base64String
                string userShaString = Convert.ToBase64String(userShaArray);

                // Code was hart zum schreiben war.. muss auch hart zum lesen sein lg ruhland :D

                // Vergleiche ob das in der Datenbank bzw. Persistenz abgespeicherte Passwort gleich der Eingabe ist.
                // falls ja setze die success(also Login-Erfolg)-Variable auf 'wahr'
                if (userFromDB.Password == userShaString)
                {
                    success = true;
                    string username = u.Email;
                    var ticket = new FormsAuthenticationTicket(1, username, DateTime.Now, DateTime.Now.AddDays(1), true, JsonConvert.SerializeObject(
                            new
                            {
                                UserId = 1,
                                RoleId = "U",
                                Name = u.FirstName +" "+ u.LastName
                            }
                            )
                        ) ;
                    string enTicket = FormsAuthentication.Encrypt(ticket);
                    var cookie = new HttpCookie(".o", enTicket);
                    cookie.HttpOnly = true;
                    cookie.Expires = DateTime.Now.AddDays(1);
                    Response.Cookies.Add(cookie);

                }

            }
            // wenn die Eingabe ! (also falsch) ist, dann returnen zu Login und auffordern erneut zu versuchen.
            if (!success)
            {
                TempData["errorMsg"] = "Passwort ist falsch! - Bitte erneut versuchen.";
                TempData["email"] = u.Email;
                return RedirectToAction("Index", "UserViewModel", new { id = userFromDB.Id });
            }

            return RedirectToAction("Index");
        }

        // GET: Personen/Details/5
        public ActionResult Details(int id)
        {
            User u = users.Where(x => x.Id == id).FirstOrDefault();
            return View(u);
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Personen/Create
        [HttpPost]
        //public ActionResult Create(Personen person)
        public ActionResult Create(FormCollection formCollection)
        {
            User u = new User();
            u.FirstName = formCollection[1]; // is it?
            u.LastName = formCollection[2]; // is it?
            u.Email = formCollection[3]; // is it?
            u.Password = formCollection[4]; // is it?
            u.userRole = UserRole.user;

            if (u.Password == formCollection[4])
            {
                u.Id = users.Count + 1;

                var sha = System.Security.Cryptography.SHA512Managed.Create();

                var rngSalt = System.Security.Cryptography.RNGCryptoServiceProvider.Create();


                byte[] rngByteArray = new byte[1024];
                rngSalt.GetBytes(rngByteArray); // fuellt das Array mit zufaelligen Bytes

                string saltStr = Convert.ToBase64String(rngByteArray);

                u.Salt = saltStr;



                byte[] userPasswordArray = System.Text.Encoding.UTF8.GetBytes(u.Password + UserController.pepperString + saltStr);

                byte[] userPasswordSHAArray = sha.ComputeHash(userPasswordArray);

                string shaString = Convert.ToBase64String(userPasswordSHAArray);

                u.Password = shaString;

                users.Add(u);
            }
            else
            {
                TempData["errorMsg"] = "Passwoerter stimmen nicht ueberein!";
                TempData["firstName"] = u.FirstName;
                TempData["lastName"] = u.LastName;
                TempData["email"] = u.Email;

                return RedirectToAction("Create"); //redirectToAction kills ViewBag, so we use 'TempData'
            }

            // TODO: Add insert logic here

            return RedirectToAction("Index");

        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Personen/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {

                User u = users.Where(x => x.Id == id).FirstOrDefault();
                users.Remove(u);

                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // ----------- PW RESET

        [HttpGet]
        public ActionResult PasswordReset()
        {
            return View();
        }

        public ActionResult StoreUsers()
        {

            Persistence.Store(users);

            return RedirectToAction("Index");

        }

    }
}
