using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using WebApiDemo.Models;

namespace WebApiDemo.Controllers
{
    public class HomeController : Controller
    {
       
        // GET: Home
       
        public async Task<ActionResult> index(string text)
        {
           
                var clinet = new HttpClient();
                var request = new HttpRequestMessage
                {
                    RequestUri = new Uri("https://api.weatherapi.com/v1/current.json?key=933472e5e9d24dab88c170335221406&q=" + text),
                    Method = HttpMethod.Get
                };
                var response = await clinet.SendAsync(request);
                string body = await response.Content.ReadAsStringAsync();
                JavaScriptSerializer js = new JavaScriptSerializer();
              
                Root root = js.Deserialize<Root>(body);
            if (root.current != null || root.location != null)
            {
                return View(root);
            }

            else
            {
                ViewBag.status = "1"; return View();
               
            }





        }
      
    }
}