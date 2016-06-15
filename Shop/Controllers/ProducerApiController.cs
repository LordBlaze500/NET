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
    public class ProducerApiController : ApiController
    {
        private Context _db;

        public ProducerApiController()
        {
            this._db = new Context();
        }

        // GET api/Producerapi
        public IEnumerable<Producer> Get()
        {
            return _db.Producer;
        }

        // GET api/Producerapi/5
        public String Get(int id)
        {
            Producer Producer = _db.Producer.Find(id);
            return Json.Encode(Producer);
        }

        // POST api/Producerapi
        public HttpResponseMessage Post([FromBody] string json)
        {
            Producer model = Json.Decode<Producer>(json);
            if (ModelState.IsValid)
            {
                this._db.Producer.Add(model);
                this._db.SaveChanges();
                var response = Request.CreateResponse<Producer>(HttpStatusCode.Created, model);
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

        // PUT api/Producerapi/5
        public void Put(int id, [FromBody]string json)
        {
            Producer model = Json.Decode<Producer>(json);
            Producer producer = _db.Producer.Find(id);
            producer.Nazwa = model.Nazwa;
            producer.Adres = model.Adres;
            producer.Nip = model.Nip;
            producer.Regon = model.Regon;
            this._db.SaveChanges();
        }

        // DELETE api/Producerapi/5
        public void Delete(int id)
        {
            //Producer Producer = _db.Producer.Find(id);
            //_db.Producer.Remove(Producer);
            //_db.SaveChanges();
        }
    }
}