using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Web;
using System.Web.Hosting;
using TradingStation.Models;

namespace TradingStation.Services
{
    public class Persistence
    {

        // TODO: Termine persistieren und laden

        //public static List<Object> ObjectsToPersist = new List<Object>();
        public static string currentWebAppFolder = HostingEnvironment.ApplicationPhysicalPath;
        static string fileName = @"myData.bin";

        static string pathToFile = currentWebAppFolder + fileName;


        public static void Init(List<Object> fooList)
        {
            // First - Initialize - Clear all items in the list 
            fooList.Clear();

            // TODO - Check if File Path is avaliable ...
        }



        public static bool Store(List<User> listToStore)
        {
            // Clear List             

            JsonSerializer serializer = new JsonSerializer();

            
            // WTF? FileStream fs = new FileStream(pathToFile, FileMode.Create);

            // Take a snapshot of all objects to store
            try
            {


                // Any other ??? 
                // ObjectsToPersist.Add(Snipplets.Controllers.EmployeeController.EmployeeListe);

                using (StreamWriter sw = new StreamWriter(pathToFile))
                using (JsonWriter writer = new JsonTextWriter(sw))
                {
                    serializer.Serialize(writer, listToStore);
                    // {"ExpiryDate":new Date(1230375600000),"Price":0}
                }
                return true;

            }
            catch
            {
                Debug.WriteLine("bar");
                // Somethings wrong!! 
                return false;
            }
        }

        public static List<User> LoadDataFromDisk()
        {
            List<User> loadedList;

            if (System.IO.File.Exists(pathToFile))
            {
                try
                {
                    // deserializing JSON directly from file
                    using (StreamReader file = File.OpenText(pathToFile))
                    {
                        JsonSerializer serializer = new JsonSerializer();
                        loadedList = (List<User>)serializer.Deserialize(file, typeof(List<User>));
                    }

                    return loadedList;
                }
                catch
                {
                    return null;
                }
            }
            else
            {
                // Laden hat nicht funktioniert
                return null;

            }


        }

        public static bool Reset()
        {
            try
            {
                if (System.IO.File.Exists(pathToFile))
                {
                    System.IO.File.Delete(pathToFile);
                }

                return true; // reset worked - file deleted

            }

            catch
            {
                return false;  // reset didn't work - file not deleted
            }

        }

    }
}