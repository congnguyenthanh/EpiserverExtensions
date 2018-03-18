using EPiServer;
using EPiServer.Core;
using EpiserverExtensions.ContentTypes.Listing;
using EpiserverExtensions.Services;

namespace EpiserverExtensions
{
    public class ListingController : GenericListingBaseController<ListingBlock, SearchQueryViewModel>
    {
        public ListingController(EPiServer.IContentLoader contentLoader,
            Services.ISearchService searchService) : base(contentLoader, searchService)
        {
        }

        protected override IQueryContext MapQueryContext(SearchQueryViewModel query)
        {
            var listingBlock = this.ContentLoader.Get<IContent>(new ContentReference(query.ContentId)) as ListingBlock;

            return new ListingQueryContext()
            {
                ContentId = query.ContentId,
                CurrentPage = query.Page,
                RootSearch = listingBlock.Root,
                PageSize = listingBlock.PageSize,
                SearchText = query.SearchText
            };
        }
    }
}
