using HistSample.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HistSample.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var orders = new List<OrderItemModel>();

            for (int i = 0; i < 10; i++)
            {
                var uid = string.Empty;
                do
                {
                    uid = Guid.NewGuid().ToString("N");
                }
                while (orders.Any(x => string.Equals(x.Uid, uid, StringComparison.InvariantCultureIgnoreCase)));

                orders.Add(new OrderItemModel()
                {
                    Uid = uid
                });
            }

            return View(orders);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}