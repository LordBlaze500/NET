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
    public class PromotionApiController : ApiController
    {
        private Context _db;

        public PromotionApiController()
        {
            this._db = new Context();
        }

        // GET api/Promotionapi
        public IEnumerable<Promotion> Get()
        {
            return _db.Promotions;
        }

        // GET api/Promotionapi/5
        public String Get(int id)
        {
            Promotion Promotion = _db.Promotions.Find(id);
            return Json.Encode(Promotion);
        }

        // POST api/Promotionapi
        public HttpResponseMessage Post([FromBody] string json)
        {
            Promotion model = Json.Decode<Promotion>(json);
            if (ModelState.IsValid)
            {
                this._db.Promotions.Add(model);
                this._db.SaveChanges();
                var response = Request.CreateResponse<Promotion>(HttpStatusCode.Created, model);
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
            Promotion model = Json.Decode<Promotion>(json);
            Promotion promotion = _db.Promotions.Find(id);
            promotion.BeginningDate = model.BeginningDate;
            promotion.DiscountPercent = model.DiscountPercent;
            promotion.EndDate = model.EndDate;
            promotion.MaxQuantity = model.MaxQuantity;
            promotion.PromotionTitle = model.PromotionTitle;
            this._db.SaveChanges();
        }

        // DELETE api/Promotionapi/5
        public void Delete(int id)
        {
            Promotion Promotion = _db.Promotions.Find(id);
            _db.Promotions.Remove(Promotion);
            _db.SaveChanges();
        }
    }
}
