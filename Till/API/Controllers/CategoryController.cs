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
    [RoutePrefix("categories")]
    public class CategoryController : ApiController
    {

        private readonly ICategoryManager _categoryManager;
        private readonly ISubCategoryManager _subCategoryManager;

        CategoryController()
        {

        }

        public CategoryController(ICategoryManager categoryManger, ISubCategoryManager subCategoryManager)
        {
            _categoryManager = categoryManger;
            _subCategoryManager = subCategoryManager;
        }

        [HttpGet]
        [Route("")]
        public HttpResponseMessage Get()
        {
            var categories = _categoryManager.GetCategories();
            return Request.CreateResponse(HttpStatusCode.OK, categories);
        }

        [HttpGet]
        [Route("{Id}")]
        public HttpResponseMessage Get(string Id)
        {
            var category = _categoryManager.GetCategory(new ObjectId(Id));
            if (category == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, category);
            }
            return Request.CreateResponse(HttpStatusCode.OK, category);
        }

        [HttpPost]
        [Route("")]
        public HttpResponseMessage Post(Category category)
        {
            Category _category;
            try
            {
                _category = _categoryManager.Create(category);
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
        public HttpResponseMessage Put(string Id, Category category)
        {
            var _category = _categoryManager.GetCategory(new ObjectId(Id));
            if (_category == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            try
            {
                _categoryManager.Update(new ObjectId(Id), category);
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
            var category = _categoryManager.GetCategory(new ObjectId(Id));
            if (category == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            if (_subCategoryManager.CategoryReferened(Id.ToString()))
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Category Is Referenced in SubCategory");
            }

            _categoryManager.Delete(new ObjectId(Id));


            return Request.CreateResponse(HttpStatusCode.NoContent);

        }
    }
}
