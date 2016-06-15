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
    public class LeafletApiController : ApiController
    {
        private Context _db;
 
        public LeafletApiController()
        {
            this._db = new Context();
        }
 
        // GET api/Leafletapi
        public IEnumerable<Leaflet> Get()
        {
            return _db.Leaflets;
        }
 
        // GET api/Leafletapi/5
        public String Get(int id)
        {
            Leaflet Leaflet = _db.Leaflets.Find(id);
            return Json.Encode(Leaflet);
        }
 
        // POST api/Leafletapi
        public HttpResponseMessage Post([FromBody] string json)
        {
            Leaflet model = Json.Decode<Leaflet>(json);
            if (ModelState.IsValid)
            {
                this._db.Leaflets.Add(model);
                this._db.SaveChanges();
                var response = Request.CreateResponse<Leaflet>(HttpStatusCode.Created, model);
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
 
        // PUT api/Leafletapi/5
        public void Put(int id, [FromBody]string json)
        {
            Leaflet model = Json.Decode<Leaflet>(json);
            Leaflet leaflet = _db.Leaflets.Find(id);
            leaflet.LeafletTitle = model.LeafletTitle;
            leaflet.Content = model.Content;
            leaflet.Colour = model.Colour;
            leaflet.Width = model.Width;
            leaflet.Height = model.Height;
            this._db.SaveChanges();
        }
 
        // DELETE api/Leafletapi/5
        public void Delete(int id)
        {
            Leaflet Leaflet = _db.Leaflets.Find(id);
            _db.Leaflets.Remove(Leaflet);
            _db.SaveChanges();
        }
    }
 }