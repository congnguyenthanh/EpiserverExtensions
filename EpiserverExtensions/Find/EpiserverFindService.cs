using EPiServer.Core;
using EPiServer.Find;
using EPiServer.Find.Cms;
using EPiServer.ServiceLocation;
using EpiserverExtensions.Exceptions;
using EpiserverExtensions.Services;
using System.Linq;

namespace EpiserverExtensions.Find
{
    public class EpiserverFindService : ISearchService
    {
        protected readonly IClient Client;
        protected readonly IQueryComposerResolver QueryComposerResolver;

        public EpiserverFindService(IClient client,
            IQueryComposerResolver composerResolver)
        {
            this.Client = client;
            this.QueryComposerResolver = composerResolver;
        }

        public IPagedList<TContent> Fetch<TContent>(IQueryContext query) where TContent : IContentData
        {
            var composer = this.QueryComposerResolver.Resolve(query);

            if (composer == null)
                throw new EpiserverExtensionsException($"Can not resolve any composer of content:{query.ContentId}");

            var searchQuery = composer.Compose(query);

            var result = searchQuery.GetContentResult();
            var page = query is IPaginableQueryContext ? ((IPaginableQueryContext)query).CurrentPage : 1;
            var pageSize = query is IPaginableQueryContext ? ((IPaginableQueryContext)query).PageSize : result.TotalMatching;

            return new PagedList<TContent>(result.OfType<TContent>(), page, pageSize, result.TotalMatching);
        }
    }
}
