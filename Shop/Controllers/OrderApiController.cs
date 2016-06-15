using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Shop.Models;
using System.Web.Helpers;

namespace Shop.Controllers
{
    public class OrderApiController : ApiController
    {
        private Context _db;

        public OrderApiController()
        {
            this._db = new Context();
        }

        // GET api/orderapi
        public IEnumerable<Order> Get()
        {
            return _db.Orders;
        }

        // GET api/orderapi/5
        public String Get(int id)
        {
            Order Order = _db.Orders.Find(id);
            return Json.Encode(Order);
        }

        // POST api/orderapi
        public HttpResponseMessage Post([FromBody] string json)
        {
            Order model = Json.Decode<Order>(json);
            if (ModelState.IsValid)
            {
                model.OrderedDate = DateTime.Now;
                this._db.Orders.Add(model);
                this._db.SaveChanges();
                var response = Request.CreateResponse<Order>(HttpStatusCode.Created, model);
                string url = Url.Route(null, new { id = model.Id });
                response.Headers.Location = new Uri(Request.RequestUri, url);
                return response;
            }
            else
            {
                var response = Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                return response;
            }
        }

        // PUT api/Promotionapi/5
        public void Put(int id, [FromBody]string json)
        {
            Order model = Json.Decode<Order>(json);
            Order order = _db.Orders.Find(id);
            order.OrderedDate = model.OrderedDate;
            order.Phone = model.Phone;
            order.Quantity = model.Quantity;
            order.ShippingDate = model.ShippingDate;
            order.Email = model.Email;
            this._db.SaveChanges();
        }

        // DELETE api/orderapi/5
        public void Delete(int id)
        {
            Order Order = _db.Orders.Find(id);
            _db.Orders.Remove(Order);
            _db.SaveChanges();
        }
    }
}
