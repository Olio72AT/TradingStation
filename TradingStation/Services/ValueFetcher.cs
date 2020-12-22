using System;
using System.Collections.Generic;
using System.Linq;
using TradingStation.Controllers;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using TradingStation.Models;

namespace TradingStation.Services
{
    public static class ValueFetcher
    {
        public static async System.Threading.Tasks.Task<JsonResult> FetchBitCoinAJAX()
        {
            using (var httpClient = new HttpClient())
            {

                dynamic bitCoinJson = await httpClient.GetStringAsync("https://api.coindesk.com/v1/bpi/currentprice.json");
                JsonResult jsonResult = (JsonResult)bitCoinJson;

                return jsonResult;
            }

        }

        public static async System.Threading.Tasks.Task<JsonAsset> FetchBitCoinAsync()
        {
            using (var httpClient = new HttpClient())
            {
                var JSONResultSnipplet = await httpClient.GetStringAsync("https://api.coindesk.com/v1/bpi/currentprice.json");

                JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
                dynamic JSONFinal = javaScriptSerializer.Deserialize<object>(JSONResultSnipplet);


                var fetchedAsset = new JsonAsset();

                fetchedAsset.ChartName = JSONFinal["chartName"];
                fetchedAsset.PriceEur = (float)JSONFinal["bpi"]["EUR"]["rate_float"];
                fetchedAsset.Time = JSONFinal["time"]["updated"];



                return fetchedAsset;

            }
        }

    }
}