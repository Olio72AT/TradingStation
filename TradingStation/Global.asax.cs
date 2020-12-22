using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using TradingStation.Controllers;
using TradingStation.Globals;
using TradingStation.Models;
using TradingStation.Services;
using TradingStation.ViewModels;

namespace TradingStation
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {

            GlobalD.userList = new List<User>();
            GlobalD.userVMList = new List<UserViewModel>();

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            GlobalD.userList =  Persistence.LoadDataFromDisk();

            if (GlobalD.userList != null)
                UserController.users = GlobalD.userList;


            foreach(User u in UserController.users)
            {
                UserViewModel modelToAdd = new UserViewModel();
                modelToAdd.ID = u.Id;
                // all other fields
                modelToAdd.FullName = u.FirstName + " " + u.LastName;
                modelToAdd.eMail = u.Email;
                modelToAdd.kontoList = u.assetKontos;

                GlobalD.userVMList.Add(modelToAdd);
            }
        }
    }
}
