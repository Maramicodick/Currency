using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Currency.Server.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var uri = String.Format("https://blockchain.info/tobtc?currency=USD&value={0}", 500);

            WebClient client = new WebClient();
            client.UseDefaultCredentials = true;
            var data = client.DownloadString(uri);

            var result = Convert.ToDouble(data);
            return View();
        }
    }
}
