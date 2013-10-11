using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Mvc;
using Umbraco.Core.Models;
using Umbraco.Web.WebApi;

namespace $rootnamespace$
{
    public class $safeitemrootname$ : UmbracoApiController
    {
        [HttpGet]
        public string GetHelloWorld()
        {
            return "Hello World";
        }

        [HttpGet]
        public string GetName(string name)
        {
            return "Hello " + name;
        }

        [HttpGet]
        public IEnumerable<string> GetUmbracoTeam()
        {
            return new[]
            {
                "Niels", 
                "Per", 
                "Tim", 
                "Paul", 
                "Shannon", 
                "Morten", 
                "Sebastiaan", 
                "Anders"
            };
        }

        [HttpGet]
        public IEnumerable<IContentType> GetContentTypes()
        {
            var allContentTypes = Services.ContentTypeService.GetAllContentTypes();
            return allContentTypes;
        }

        [HttpGet]
        public IEnumerable<ITemplate> GetTemplates()
        {
            var allTemplates = Services.FileService.GetTemplates();
            return allTemplates;
        }

        [HttpPost]
        public HttpResponseMessage PostComment()
        {
            //Create Node/Content at root (aka -1) using the document type 'comment'
            var newComment = Services.ContentService.CreateContent("test comment", -1, "comment");

            //Update value on newly created comment node
            newComment.Properties["commentText"].Value = "I am the comment text";

            //Save & Publish our comment node
            Services.ContentService.SaveAndPublish(newComment);

            //Create a response with HTTP Created header & serialized object of our new comment node
            var response = Request.CreateResponse(HttpStatusCode.Created, newComment);

            //URL to our newly created comment node
            string uri = Umbraco.TypedContent(newComment.Id).Url;
            response.Headers.Location = new Uri(uri);

            //Return the HTTP Response
            return response;
        }

    }
}
