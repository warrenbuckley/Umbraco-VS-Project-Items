using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using Umbraco.Core;
using Umbraco.Core.Events;
using Umbraco.Core.Models;
using Umbraco.Core.Publishing;
using Umbraco.Core.Services;

namespace $rootnamespace$
{
    /// <summary>
    /// Umbraco Register Events on Application Startup
    /// 
    /// Documentation
    /// http://our.umbraco.org/documentation/Reference/Events/application-startup
    /// http://our.umbraco.org/documentation/reference/events-v6/
    /// </summary>
    public class  $safeitemrootname$ : ApplicationEventHandler
    {

        protected override void ApplicationStarted(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
        {
            ContentService.Published += ContentServiceOnPublished;
        }

        private void ContentServiceOnPublished(IPublishingStrategy sender, PublishEventArgs<IContent> publishEventArgs)
        {
            //For every node that has been published (may be single node, or node & it's children)
            foreach (var node in publishEventArgs.PublishedEntities)
            {
                //If the node document type alias is Comment then...
                if (node.ContentType.Alias == "Comment")
                {
                    //Pass comment to Spam Checker
                    checkForSpam(node);
                }
            }
        }
    }
}
