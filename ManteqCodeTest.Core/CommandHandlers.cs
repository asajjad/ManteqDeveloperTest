using System;
using ManteqCodeTest.Core;
using NServiceBus;

namespace ManteqCodeTest.Core
{
    public class CommandHandlers : IHandleMessages<CreateMedicalProcedureApprovalRequest>
    {
        private readonly IRepository<MedicalApprovalProcedure> _repository;

        public CommandHandlers(IRepository<MedicalApprovalProcedure> repository)
        {
            _repository = repository;
        }

        public void Handle(CreateMedicalProcedureApprovalRequest message)
        {
            var item = new MedicalApprovalProcedure(message.Id, message.PatientId, message.PatientName, message.DateOfBirth);
            _repository.Save(item, -1);
        }
     }

    public class MyHandler : IHandleMessages<MyMessage>
    {
        public void Handle(MyMessage message)
        {
            Console.WriteLine("Hello from MyHandler");
        }
    }

    public class MyMessage : IMessage
    {
    }
}
