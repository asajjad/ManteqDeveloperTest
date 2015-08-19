using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NServiceBus;

namespace ManteqCodeTest.Core
{
    public class CustomerCreatedHandler : IHandleMessages<ApprovalCreated>
    {
        public void Handle(ApprovalCreated message)
        {
        }
    }
}
