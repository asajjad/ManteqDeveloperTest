using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using NServiceBus;

namespace ManteqCodeTest.App_Start
{
    public class Bootstrapper
    {
        public void Start()
        {
            SetAutofacContainer();
        }
        private void SetAutofacContainer()
        {
           
        }

    }
}