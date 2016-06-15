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
    public class ProductsApiController : ApiController
    {
        private Context _db;

        public ProductsApiController()
        {
            this._db = new Context();
        }

        // GET api/Productsapi
        public IEnumerable<Products> Get()
        {
            return _db.Products;
        }

        // GET api/Productsapi/5
        public String Get(int id)
        {
            Products Products = _db.Products.Find(id);
            return Json.Encode(Products);
        }

        // POST api/Productsapi
        public HttpResponseMessage Post([FromBody] string json)
        {
            Products model = Json.Decode<Products>(json);
            if (ModelState.IsValid)
            {
                this._db.Products.Add(model);
                this._db.SaveChanges();
                var response = Request.CreateResponse<Products>(HttpStatusCode.Created, model);
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

        // PUT api/Productsapi/5
        public void Put(int id, [FromBody]string json)
        {
            Products model = Json.Decode<Products>(json);
            Products products = _db.Products.Find(id);
            products.ProductName = model.ProductName;
            products.Quantity = model.Quantity;
            products.Code = model.Code;
            products.Price = model.Price;
            products.VAT = model.VAT;
            products.AddDate = model.AddDate;
            this._db.SaveChanges();
        }

        // DELETE api/Productsapi/5
        public void Delete(int id)
        {
            Products Products = _db.Products.Find(id);
            _db.Products.Remove(Products);
            _db.SaveChanges();
        }
    }
}