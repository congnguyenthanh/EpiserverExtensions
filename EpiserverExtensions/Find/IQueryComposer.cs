using EPiServer;
using EPiServer.Core;
using EPiServer.Find;
using EpiserverExtensions.ContentTypes;
using EpiserverExtensions.Services;

namespace EpiserverExtensions.Find
{
    public interface IQueryComposer
    {
        bool IsSatisfied(IQueryContext content);

        ITypeSearch<IContent> Compose(IQueryContext query);
    }

    public abstract class QueryComposer<TListingContent, TQuery> : IQueryComposer
        where TQuery : IQueryContext
    {
        protected readonly IContentLoader ContentLoader;
        protected readonly IClient Client;

        protected QueryComposer(IContentLoader contentLoader,
            IClient client)
        {
            this.ContentLoader = contentLoader;
            this.Client = client;
        }

        public abstract ITypeSearch<IContent> Compose(IQueryContext query);

        public bool IsSatisfied(IQueryContext content)
        {
            return this.ContentLoader.Get<IContent>(new ContentReference(content.ContentId)).GetOriginalType() == (typeof(TListingContent));
        }

        protected TQuery GetQuery(IQueryContext query) => (TQuery)query;
    }
}
