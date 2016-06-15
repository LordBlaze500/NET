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
    public class ComplaintApiController : ApiController
    {

        private Context _db;

        public ComplaintApiController()
        {
            this._db = new Context();
        }

        // GET api/complaintapi
        public IEnumerable<Complaint> Get()
        {
            return _db.Complaints;
        }

        // GET api/complaintapi/5
        public Complaint Get(int id)
        {
            return _db.Complaints.Find(id);
        }

        // POST api/complaintapi
        public HttpResponseMessage Post([FromBody]Complaint model)
        {
            if (ModelState.IsValid)
            {
                this._db.Complaints.Add(model);
                this._db.SaveChanges();
                var response = Request.CreateResponse<Complaint>(HttpStatusCode.Created, model);
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
            Complaint model = Json.Decode<Complaint>(json);
            Complaint complaint = _db.Complaints.Find(id);
            complaint.Invoice = model.Invoice;
            complaint.ProductName = model.ProductName;
            complaint.SaleDate = model.SaleDate;
            complaint.DamageDesc = model.DamageDesc;
            this._db.SaveChanges();
        }

        // DELETE api/complaintapi/5
        public void Delete(int id)
        {
            Complaint complaint = _db.Complaints.Find(id);
            _db.Complaints.Remove(complaint);
            _db.SaveChanges();
        }
    }
}
