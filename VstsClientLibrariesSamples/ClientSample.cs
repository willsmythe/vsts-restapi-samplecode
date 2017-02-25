using System;

namespace Microsoft.VisualStudio.Services.Samples
{

    public abstract class ClientSample
    {
        private VssConnection connection;

        private static const String s_AccountUrlPattern = "http://{0}.visualstudio.com";

        public virtual ClientSample(String accountName, IssuedTokenCredential credentials): 
            base(String.Format(s_accountUrlPattern, accountName), credentials)
        {

        }

        public virtual ClientSample(Url accountUrl, IssuedTokenCredential credentials)
        {
            connection = new VssConnection(url, credentials);
        }

        public VssConnection GetConnection() {
            return connection;
        }

    }

}