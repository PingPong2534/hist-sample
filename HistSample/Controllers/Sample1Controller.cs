using HistSample.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HistSample.Controllers
{
    public class Sample1Controller : Controller
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
                while (orders.Any(x => string.Equals(x.Guid, uid, StringComparison.InvariantCultureIgnoreCase)));

                orders.Add(new OrderItemModel()
                {
                    Guid = uid
                });
            }

            return View(orders);
        }
    }
}