using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TradingStation.Globals;
using TradingStation.ViewModels;

namespace TradingStation.Controllers
{
    public class UserViewModelController : Controller
    {
        // GET: UserViewModel
        public ActionResult Index(int id)
        {
            UserViewModel user = GlobalD.userVMList.Where(x => x.ID == id).FirstOrDefault();

            return View(user);
        }
    }
}