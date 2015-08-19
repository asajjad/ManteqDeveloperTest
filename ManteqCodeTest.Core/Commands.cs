using System;
using NServiceBus;

namespace ManteqCodeTest.Core
{
    public class Command : IMessage
    {

    }
    public class CreateMedicalProcedureApprovalRequest : Command
    {
        public Guid Id;
        public int OriginalVersion;
        public string PatientId;
        public string PatientName;
        public DateTime? DateOfBirth;


        public CreateMedicalProcedureApprovalRequest(Guid id, int originalVersion, string patientId, string patientName, DateTime? dateOfBirth)
        {
            Id = id;
            OriginalVersion = originalVersion;
            PatientName = patientName;
            PatientId = patientId;
            DateOfBirth = dateOfBirth;
        }
    }

    public class UpdateMedicalProcedureApprovalRequest : Command
    {
        public Guid Id;
        public string PatientName;

        public UpdateMedicalProcedureApprovalRequest(Guid id, string patientName)
        {
            Id = id;
            PatientName = patientName;
        }
    }

}
