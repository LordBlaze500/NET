using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Shop.Models;

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
        public string Get(int id)
        {
            return "value";
        }

        // POST api/orderapi
        public HttpResponseMessage Post([FromBody]Order model)
        {
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

        // PUT api/orderapi/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/orderapi/5
        public void Delete(int id)
        {
        }
    }
}
