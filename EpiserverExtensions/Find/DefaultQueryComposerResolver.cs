using EPiServer;
using EPiServer.Core;
using EPiServer.ServiceLocation;
using EpiserverExtensions.ContentTypes;
using EpiserverExtensions.Exceptions;
using EpiserverExtensions.Services;
using System;
using System.Linq;

namespace EpiserverExtensions.Find
{

    public class DefaultQueryComposerResolver : IQueryComposerResolver
    {
        protected readonly IContentLoader ContentLoader;

        public DefaultQueryComposerResolver(IContentLoader contentLoader)
        {
            this.ContentLoader = contentLoader;
        }

        public IQueryComposer Resolve(IQueryContext query)
        {
            if (query == null)
                throw new ArgumentNullException(nameof(query));

            var content = this.ContentLoader.Get<IListingContent>(new ContentReference(query.ContentId));

            if (content == null)
                throw new EpiserverExtensionsException($"Cant not find the content with Id:{query.ContentId}");

            var composers = ServiceLocator.Current.GetAllInstances<IQueryComposer>();

            return composers?.FirstOrDefault(c => c.IsSatisfied(query));
        }
    }
}
