using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TradingStation.Models;

namespace TradingStation.Services
{
    public static class PassHandler
    {
        public static void PasswordReset(string newPass, string token, int id)
        {
            User userToReset = TradingStation.Controllers.UserController.users.Where(x => x.Id == id).FirstOrDefault();
            if (userToReset.Token == token)
            {
                userToReset.Password = newPass;
            }

        }
        public static void SetToken(int id)
        {
            User userToReset = TradingStation.Controllers.UserController.users.Where(x => x.Id == id).FirstOrDefault();
            var tokenPicker = System.Security.Cryptography.RNGCryptoServiceProvider.Create();


            byte[] rngByteArray = new byte[1024];
            tokenPicker.GetBytes(rngByteArray); // fuellt das Array mit zufaelligen Bytes
            string token = Convert.ToString(rngByteArray);

            userToReset.Password = "";
            userToReset.Token = token;



        }

        public static void SendToken()
        {
            // stub method which would actually send the token to the user
            // or respectively a link with the token embedded so the user can reset his password via REST
        }
    }
}