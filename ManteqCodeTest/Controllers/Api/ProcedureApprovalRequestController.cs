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
        private readonly IRepository<MedicalApprovalProcedure> _repository;
        IBus _bus;

        public ProcedureApprovalRequestController(IBus bus, IRepository<MedicalApprovalProcedure> repository)
        {
            _repository = repository;
            _bus = bus;
        }

        [Route("api/medicalprocedureapproval/request")]
        public void Post()
        {
            var createMedicalProcedureApprovalRequest = new CreateMedicalProcedureApprovalRequest(Guid.NewGuid(), 1, "1", "Henry", DateTime.UtcNow);
            _bus.Send("Samples.StepByStep.Server", createMedicalProcedureApprovalRequest);
        }

    }
}