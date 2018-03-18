using System;
using System.Web.Mvc;
using EPiServer;
using EPiServer.Core;
using EpiserverExtensions.ContentTypes;
using EpiserverExtensions.Services;

namespace EpiserverExtensions
{
    public class GenericListingBaseController<TListingBlock, TQuery> 
        : EPiServer.Web.Mvc.PartialContentController<TListingBlock>
        where TListingBlock : IListingContent
        where TQuery : QueryViewModel
    {

        protected readonly IContentLoader ContentLoader;
        protected readonly ISearchService SearchService;

        public GenericListingBaseController(IContentLoader contentLoader,
            ISearchService searchService)
        {
            this.ContentLoader = contentLoader;
            this.SearchService = searchService;
        }

        public override ActionResult Index(TListingBlock currentContent)
        {
            return PopulateIndexView(currentContent);
        }

        [HttpPost]
        public virtual ActionResult Search(TQuery query)
        {
            return this.PopulateSearchView(query);
        }

        protected virtual ActionResult PopulateSearchView(TQuery query)
        {
            var content = this.ContentLoader.Get<IContent>(new ContentReference(query.ContentId));

            if (content == null)
                throw new ArgumentException(nameof(query));

            var result = this.SearchService.Fetch<IContent>(MapQueryContext(query));
            var viewModel = new SearchResultViewModel<IContent>(result, content);

            return PartialView(this.ResultView(query), viewModel);
        }

        protected virtual ActionResult PopulateIndexView(TListingBlock listingBlock)
        {
            return PartialView(IndexView(listingBlock), listingBlock);
        }

        protected virtual IQueryContext MapQueryContext(TQuery query)
        {
            IQueryContext queryContext = null;

            var content = this.ContentLoader.Get<IContent>(new ContentReference(query.ContentId)) as IListingContent;

            if (content == null)
                throw new Exceptions.EpiserverExtensionsException($"The current content is not {typeof(IListingContent).Name}");

            if(content is IScopedSearchContent)
            {
                queryContext = Activator.CreateInstance<PaginableScopedQueryContext>();
                ((PaginableScopedQueryContext)queryContext).RootSearch = ((IScopedSearchContent)content).Root;
            }

            if(content is IPaginableContent)
            {
                queryContext = queryContext ?? Activator.CreateInstance<PaginableQueryContext>();
                ((PaginableQueryContext)queryContext).CurrentPage = query is PaginableQueryViewModel ? (query as PaginableQueryViewModel).Page : 1;
                ((PaginableQueryContext)queryContext).PageSize = ((IPaginableContent)content).PageSize;
            }

            queryContext = queryContext ?? Activator.CreateInstance<QueryContext>();
            queryContext.ContentId = ((IContent)content).ContentLink.ID;

            return queryContext;
        }

        protected virtual string IndexView(TListingBlock content) => $"{content.GetOriginalType().Name}/Index";

        protected virtual string ResultView(TQuery query)
        {
            var content = this.ContentLoader.Get<IContent>(new ContentReference(query.ContentId));

            return $"{content.GetOriginalType().Name}/_Result";
        }
    }
}
