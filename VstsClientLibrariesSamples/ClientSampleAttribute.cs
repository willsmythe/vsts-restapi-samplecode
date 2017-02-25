using System;

namespace Microsoft.VisualStudio.Services.Samples
{

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class ClientSampleAttribute : Attribute
    {

        public ClientSampleAttribute(String area, String resource, String operation)
        {
            
        }

    }

}