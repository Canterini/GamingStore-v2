using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http.Results;
using System.Web.Mvc;

namespace GamingStore.Controllers
{
    public class myJsonResult : JsonResult
    {
        private  HttpStatusCode _httpstatus;

        public void JsonHttpStatusResult(object data, HttpStatusCode httpStatus)
        {
            Data = data;
            _httpstatus = httpStatus;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            context.RequestContext.HttpContext.Response.StatusCode = (int)_httpstatus;
            base.ExecuteResult(context);
        }

    }
}