using AG_OneSignalAPI.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

namespace AG_OneSignalAPI.Controllers
{
    public class OneSignalController : Controller
    {
        public string API_KEY = WebConfigurationManager.AppSettings["API_KEY"];
        public string URL_APPS = WebConfigurationManager.AppSettings["URL_APPS"];
        // GET: OneSignal

        public ActionResult CreateApp()
        {
            return View(new OneSignalDetails());
        }

        [HttpPost]
        public ActionResult CreateApp(OneSignalDetails obj)
        {
            try
            {

                var client = new RestClient(URL_APPS + "?name=" + obj.name + "&chrome_web_origin=" + obj.chrome_web_origin + "&site_name=" + obj.chrome_web_origin + "");

                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("Authorization", "Basic " + API_KEY + "");
                request.AddHeader("Content-Type", "application/json");

                IRestResponse response = client.Execute(request);

                return RedirectToAction("Index", "OneSignal");
            }
            catch (Exception)
            {

                return View("Error");
            }

        }

        public ActionResult Index()
        {
            try
            {
                var client = new RestClient(URL_APPS);
                client.Timeout = -1;
                var request = new RestRequest(Method.GET);
                request.AddHeader("Authorization", "Basic " + API_KEY + "");
                request.AddHeader("Content-Type", "application/json");
                IRestResponse response = client.Execute(request);
                var oneSignalDetails = JsonConvert.DeserializeObject<List<OneSignalDetails>>(response.Content);
                return View(oneSignalDetails);
            }
            catch (Exception)
            {

                return View("Error");
            }

        }
        public ActionResult Details(string id)
        {
            try
            {
                var client = new RestClient(URL_APPS + "/" + id);
                client.Timeout = -1;
                var request = new RestRequest(Method.GET);
                request.AddHeader("Authorization", "Basic " + API_KEY + "");
                request.AddHeader("Content-Type", "application/json");
                IRestResponse response = client.Execute(request);
                var oneSignalDetail = JsonConvert.DeserializeObject<OneSignalDetails>(response.Content);
                return View(oneSignalDetail);
            }
            catch (Exception)
            {

                return View("Error");
            }

        }
        public ActionResult Edit(string id)
        {
            try
            {
                if (id == null)
                { return View("Index"); }
                var client = new RestClient(URL_APPS + "/" + id);
                client.Timeout = -1;
                var request = new RestRequest(Method.GET);
                request.AddHeader("Authorization", "Basic " + API_KEY + "");
                request.AddHeader("Content-Type", "application/json");
                IRestResponse response = client.Execute(request);
                var oneSignalDetail = JsonConvert.DeserializeObject<OneSignalDetails>(response.Content);
                return View(oneSignalDetail);
            }
            catch (Exception)
            {

                return View("Error");
            }

        }
        [HttpPost]
        public ActionResult Edit(OneSignalDetails obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var client = new RestClient(URL_APPS + "/" + obj.id + "?name=" + obj.name + "&chrome_web_origin=" + obj.chrome_web_origin + "");
                    client.Timeout = -1;
                    var request = new RestRequest(Method.PUT);
                    request.AddHeader("Authorization", "Basic " + API_KEY + "");
                    request.AddHeader("Content-Type", "application/json");
                    IRestResponse response = client.Execute(request);

                    return RedirectToAction("Index", "OneSignal");
                }
                else
                    return RedirectToAction("Index", "OneSignal");
            }
            catch (Exception)
            {

                return View("Error");
            }



        }


    }
}
