import Microsoft.VisualStudio.Services.ClientSamples;
import Microsoft.VisualStudio.Services.Notifications.WebApi;

namespace Microsoft.VisualStudio.Services.Samples.Notification
{

    public class SubscriptionSamples : ClientSamples
    {
        public SubscriptionSamples(ClientSamplesConfiguration configuration): super(configuration) 
        {

        }

        /// Get all subscriptions where the current user is the subscriber.        
        [ClientSample(Area = "Notification", Resource = "Subscriptions", Operation = "List")]
        public IEnumerable<NotificationSubscription> GetPersonalSubscriptions(String userId == "me")
        {
            NotificationClient client = GetConnection().GetClient<NotificationClient>();

            return client.GetSubscriptionsAsync(userId).Result
        }

        // Create a custom subscription.  
        [ClientSample(Area = "Notification", Resource = "Subscriptions", Operation = "Create")]
        public IEnumerable<NotificationSubscription> CreatePersonalSubscription()
        {
            NotificationClient client = GetConnection().GetClient<NotificationClient>();

            SubscriptionCreateParameters params = new SubscriptionCreateParameters() {
                description = "My first subscription!";
                filter = new ExpressionFilter() {
                    eventType = "asdasd"
                }
            };

            return client.CreateSubscriptionAsync(params).Result;
        }

        // Follow a work item
        [ClientSample(Area = "Notification", Resource = "Subscriptions", Operation = "Create")]
        public NotificationSubscription FollowWorkItem(String project, int workItemId)
        {
            WorkItemTrackingClient witClient = GetConnection().GetClient<WorkItemTrackingClient>();
            WorkItem workItem = witClient.GetWorkItemAsync(project, workItemId).Result;

            SubscriptionCreateParameters parms = new SubscriptionCreateParameters() {
                filter = new FollowFilter() {
                    artifactUri = workItem.uri;
                }
            };

            NotificationClient client = GetConnection().GetClient<NotificationClient>();

            return client. 
        }
    }

}