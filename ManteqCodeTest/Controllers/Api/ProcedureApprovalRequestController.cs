using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ManteqCodeTest.Core;
using NServiceBus;

namespace ManteqCodeTest.Controllers.Api
{
    public class ProcedureApprovalRequestController : ApiController
    {

        IBus bus;

        public ProcedureApprovalRequestController(IBus bus)
        {
            this.bus = bus;
        }


        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        [Route("api/medicalprocedureapproval/request")]
        public void Post()
        {
            var createMedicalProcedureApprovalRequest = new CreateMedicalProcedureApprovalRequest(Guid.NewGuid(), 1, "1", "Henry", DateTime.UtcNow);
            this.bus.Send(createMedicalProcedureApprovalRequest);
            this.bus.Send(new MyMessage());
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}