using System;
using Autofac;
using ManteqCodeTest.Core;
using NServiceBus;
using NServiceBus.Unicast;

public class CommandsHandler : IHandleMessages<CreateMedicalProcedureApprovalRequest>
{
    private readonly IRepository<MedicalApprovalProcedure> _repository;

    public CommandsHandler(IRepository<MedicalApprovalProcedure> repository)
    {
        _repository = repository;
    }

    public void Handle(CreateMedicalProcedureApprovalRequest message)
    {
        var item = new MedicalApprovalProcedure(message.Id, message.PatientId, message.PatientName, message.DateOfBirth);

        _repository.Save(item, -1);
    }
}


