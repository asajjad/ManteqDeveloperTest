using System;
using NServiceBus;

namespace ManteqCodeTest.Core
{
    public class Event : IEvent
    {
        public int Version;
    }

    public class ApprovalCreated : Event
    {
        public  Guid Id { get; set; }
        public  string PatientId { get; set; }
        public  string PatientName { get; set; }
        public  DateTime? DateOfBirth { get; set; }
        public ApprovalCreated(Guid id, string patientId, string patientName, DateTime? dateOfBirth)
        {
            this.Id = id;
            this.PatientId = patientId;
            this.PatientName = patientName;
            this.DateOfBirth = dateOfBirth;
        }
    }

    public class ApprovalUpdated : Event
    {
        public readonly Guid Id;
        public string PatientName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public ApprovalUpdated(Guid id, string patientName, DateTime? dateOfBirth)
        {
            this.Id = id;
            this.PatientName = patientName;
            this.DateOfBirth = dateOfBirth;
        }
    }

}

