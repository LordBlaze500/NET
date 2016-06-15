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
    public class KategoriaApiController : ApiController
    {
        private Context _db;

        public KategoriaApiController()
        {
            this._db = new Context();
        }

        // GET api/Kategoriaapi
        public IEnumerable<Kategoria> Get()
        {
            return _db.Kategorie;
        }

        // GET api/Kategoriaapi/5
        public String Get(int id)
        {
            Kategoria Kategoria = _db.Kategorie.Find(id);
            return Json.Encode(Kategoria);
        }

        // POST api/Kategoriaapi
        public HttpResponseMessage Post([FromBody] string json)
        {
            Kategoria model = Json.Decode<Kategoria>(json);
            if (ModelState.IsValid)
            {
                this._db.Kategorie.Add(model);
                this._db.SaveChanges();
                var response = Request.CreateResponse<Kategoria>(HttpStatusCode.Created, model);
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

        // PUT api/Kategoriaapi/5
        public void Put(int id, [FromBody]string json)
        {
            Kategoria model = Json.Decode<Kategoria>(json);
            Kategoria Kategoria = _db.Kategorie.Find(id);
            Kategoria.Name = model.Name;
            Kategoria.Description = model.Description;
            this._db.SaveChanges();
        }

        // DELETE api/Kategoriaapi/5
        public void Delete(int id)
        {
            Kategoria Kategoria = _db.Kategorie.Find(id);
            _db.Kategorie.Remove(Kategoria);
            _db.SaveChanges();
        }
    }
}
