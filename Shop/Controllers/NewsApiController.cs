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
    public class NewsApiController : ApiController
    {
        private Context _db;

        public NewsApiController()
        {
            this._db = new Context();
        }

        // GET api/Newsapi
        public IEnumerable<News> Get()
        {
            return _db.News;
        }

        // GET api/Newsapi/5
        public String Get(int id)
        {
            News News = _db.News.Find(id);
            return Json.Encode(News);
        }

        // POST api/Newsapi
        public HttpResponseMessage Post([FromBody] string json)
        {
            News model = Json.Decode<News>(json);
            if (ModelState.IsValid)
            {
                this._db.News.Add(model);
                this._db.SaveChanges();
                var response = Request.CreateResponse<News>(HttpStatusCode.Created, model);
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

        // PUT api/Newsapi/5
        public void Put(int id, [FromBody]string json)
        {
            News model = Json.Decode<News>(json);
            News news = _db.News.Find(id);
            news.NewsTitle = model.NewsTitle;
            news.NewsContent = model.NewsContent;
            news.NewsDate = model.NewsDate;
            news.NewsAuthor = model.NewsAuthor;
            this._db.SaveChanges();
        }

        // DELETE api/Newsapi/5
        public void Delete(int id)
        {
            News News = _db.News.Find(id);
            _db.News.Remove(News);
            _db.SaveChanges();
        }
    }
}
