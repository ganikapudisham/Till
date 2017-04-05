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
    [RoutePrefix("subcategories")]
    public class SubCategoryController : ApiController
    {
        ISubCategoryManager _subCategoryManager ;
        IProductManager _productManager  ;

        SubCategoryController()
        {

        }

        public SubCategoryController(ISubCategoryManager subCategoryManager, IProductManager productManager)
        {
            _subCategoryManager = subCategoryManager;
            _productManager = productManager;
        }

        [HttpGet]
        [Route("")]
        public HttpResponseMessage Get()
        {
            var categories = _subCategoryManager.GetSubCategories();
            return Request.CreateResponse(HttpStatusCode.OK, categories);
        }

        [HttpGet]
        [Route("{Id}")]
        public HttpResponseMessage Get(string Id)
        {
            var category = _subCategoryManager.GetSubCategory(new ObjectId(Id));
            if (category == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, category);
            }
            return Request.CreateResponse(HttpStatusCode.OK, category);
        }

        [HttpPost]
        [Route("")]
        public HttpResponseMessage Post(SubCategory subCategory)
        {
            SubCategory _subCategory;
            try
            {
                _subCategory = _subCategoryManager.Create(subCategory);
            }
            catch (ArgumentException argEx)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, argEx.Message);
            }
            var response = Request.CreateResponse(HttpStatusCode.Created, _subCategory);
            return response;
        }

        [HttpPut]
        [Route("{Id}")]
        public HttpResponseMessage Put(string Id, SubCategory subCategory)
        {
            var _subCategory = _subCategoryManager.GetSubCategory(new ObjectId(Id));
            if (_subCategory == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            try
            {
                _subCategoryManager.Update(new ObjectId(Id), subCategory);
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
            var category = _subCategoryManager.GetSubCategory(new ObjectId(Id));
            if (category == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            if (_productManager.SubCategoryReferened(Id.ToString()))
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "SubCategory Is Referenced in Product");
            }

            _subCategoryManager.Delete(new ObjectId(Id));
            return Request.CreateResponse(HttpStatusCode.NoContent);
        }
    }
}
