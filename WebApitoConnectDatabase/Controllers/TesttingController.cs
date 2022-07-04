using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApitoConnectDatabase.Controllers
{
    public class TesttingController : ApiController
    {
        BusinessLogic bl = new BusinessLogic();

        StatusResponse response = new StatusResponse();
        [HttpGet]
        //[ActionName("Test")]
        public IHttpActionResult TestingCode()
        {          
                  bl.GetData();
                response.Message = "Succes";
                response.Status = "1";
           
        
            return Content(HttpStatusCode.OK, response);
        }
        [HttpPost]
        public IHttpActionResult Senddata([FromBody] Employee emp)
        {
            bl.PostDatas(emp);
            response.Message = "Succes";
            response.Status = "1";
            return Content(HttpStatusCode.OK, response);
        }
        [HttpPut]
        public IHttpActionResult update([FromBody] Employee emp)
        {
            bl.UpdateData(emp);
            response.Message = "Succes";
            response.Status = "1";
            return Content(HttpStatusCode.OK, response);
        }

        [HttpDelete]
        public IHttpActionResult DeleteData([FromBody] Employee emp)
        {
            bl.Delete(emp);
            response.Message = "Succes";
            response.Status = "1";
            return Content(HttpStatusCode.OK, response);

        }
    }
}
