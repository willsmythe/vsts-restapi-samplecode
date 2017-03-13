using Microsoft.TeamFoundation.WorkItemTracking.WebApi;
using Microsoft.TeamFoundation.WorkItemTracking.WebApi.Models;
using Microsoft.VisualStudio.Services.Common;
using Microsoft.VisualStudio.Services.WebApi;
using Microsoft.VisualStudio.Services.WebApi.Patch;
using Microsoft.VisualStudio.Services.WebApi.Patch.Json;
using System;
using System.Collections.Generic;
using Microsoft.TeamFoundation.Build.WebApi;

namespace VstsClientLibrariesSamples.Build
{
    public class BuildBadge
    {
        private readonly IConfiguration _configuration;
        private VssBasicCredential _credentials;
        private Uri _uri;

        public BuildBadge(IConfiguration configuration)
        {
            _configuration = configuration;
            _credentials = new VssBasicCredential("", _configuration.PersonalAccessToken);
            _uri = new Uri(_configuration.UriString);
        }

        public String GetBuildBadge(Guid projectId, int buildDefinitionId)
        {
            VssConnection connection = new VssConnection(_uri, new VssCredentials()); // this is using the default credentials, not the credentials set above
        
            BuildHttpClient buildClient = connection.GetClient<BuildHttpClient>();
            
            String badge = buildClient.GetBadgeAsync(projectId, buildDefinitionId).Result;

            return badge;
        } 
    }
}
