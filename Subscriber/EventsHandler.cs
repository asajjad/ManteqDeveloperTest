using System;
using ManteqCodeTest.Core;
using ManteqCodeTest.Core.Domain;
using NServiceBus;

public class EventsHandler : IHandleMessages<ApprovalCreated>
{
    public void Handle(ApprovalCreated message)
    {
        using (var dataStoreContext = new SqlDataStoreContext())
        {
            var manteqApprovalRequest = new ManteqApprovalRequest();
            manteqApprovalRequest.ApprovalRequestId = message.Id;
            manteqApprovalRequest.PatientName = message.PatientName;
            manteqApprovalRequest.PatientId = message.PatientId;
            manteqApprovalRequest.DateOfBirth = message.DateOfBirth;
            dataStoreContext.ManteqApprovalRequests.Add(manteqApprovalRequest);
            dataStoreContext.SaveChanges();
        }
        
    }
}
