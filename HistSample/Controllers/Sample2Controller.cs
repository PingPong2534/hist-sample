using HistSample.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace HistSample.Controllers
{
    public class Sample2Controller : Controller
    {
        public const string DetailSession = "DetailSession";

        public ActionResult Index()
        {
            Session.Clear();

            var orders = new List<OrderItemModel>();
            var orderDetails = new List<OrderItemDetailModel>();

            for (int i = 0; i < 10; i++)
            {
                var guid = string.Empty;
                do
                {
                    guid = Guid.NewGuid().ToString("N");
                }
                while (orders.Any(x => Equals(x.Guid, guid)));

                orders.Add(new OrderItemModel()
                {
                    Guid = guid
                });

                orderDetails.Add(new OrderItemDetailModel()
                {
                    Guid = guid,
                    ItemName = "item" + i.ToString(),
                    Detail = " Cras sit amet nibh libero, in gravida nulla. Nulla vel metus scelerisque ante sollicitudin commodo. Cras purus odio, vestibulum in vulputate at, tempus viverra turpis.",
                    ImgUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/e/e7/Everest_North_Face_toward_Base_Camp_Tibet_Luca_Galuzzi_2006.jpg/1280px-Everest_North_Face_toward_Base_Camp_Tibet_Luca_Galuzzi_2006.jpg"
                });
            }

            Session[DetailSession] = orderDetails;

            return View(orders);
        }

        [HttpPost]
        public ActionResult LoadDetail(string guid)
        {
            var details = (List<OrderItemDetailModel>)Session[DetailSession];

            if (details == null)
                return new HttpStatusCodeResult(400);

            if (details.Any())
            {
                var selectDetail = details.FirstOrDefault(x => Equals(x.Guid, guid));

                if (selectDetail == null)
                    return new HttpStatusCodeResult(400);

                //Delay Loading data sample
                Thread.Sleep(200);

                return Json(selectDetail);
            }

            return new HttpStatusCodeResult(404);
        }

        private bool Equals(string v1, string v2)
        {
            return string.Equals(v1, v2, StringComparison.InvariantCultureIgnoreCase);
        }
    }
}