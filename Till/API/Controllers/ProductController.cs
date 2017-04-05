using BLL.Impl;
using DAL;
using Model;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL;

namespace API.Controllers
{
    [RoutePrefix("products")]
    public class ProductController : ApiController
    {
        IProductManager _productManager;

        public ProductController(IProductManager productManager)
        {
            _productManager = productManager;
        }

        [HttpGet]
        [Route("")]
        public HttpResponseMessage Get()
        {
            var products = _productManager.GetProducts();
            return Request.CreateResponse(HttpStatusCode.OK, products);
        }

        [HttpGet]
        [Route("{Id}")]
        public HttpResponseMessage Get(string Id)
        {
            var product = _productManager.GetProduct(new ObjectId(Id));
            if (product == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, product);
            }
            return Request.CreateResponse(HttpStatusCode.OK, product);
        }

        [HttpPost]
        [Route("")]
        public HttpResponseMessage Post(Product product)
        {
            Product _category;
            try
            {
                _category = _productManager.Create(product);
            }
            catch (ArgumentException argEx)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, argEx.Message);
            }
            var response = Request.CreateResponse(HttpStatusCode.Created, _category);
            return response;
        }

        [HttpPut]
        [Route("{Id}")]
        public HttpResponseMessage Put(string Id, Product product)
        {
            var _category = _productManager.GetProduct(new ObjectId(Id));
            if (_category == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            try
            {
                _productManager.Update(new ObjectId(Id), product);
            }
            catch (ArgumentException argEx)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, argEx.Message);
            }
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpDelete]
        [Route("{Id}")]
        public HttpResponseMessage Delete(string Id)
        {
            var product = _productManager.GetProduct(new ObjectId(Id));
            if (product == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            _productManager.Delete(new ObjectId(Id));
            return Request.CreateResponse(HttpStatusCode.NoContent);
        }
    }
}
