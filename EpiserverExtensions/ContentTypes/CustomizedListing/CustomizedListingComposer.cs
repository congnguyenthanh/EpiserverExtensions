using EPiServer.Core;
using EPiServer.Find;
using EpiserverExtensions.ContentTypes.Listing;
using EpiserverExtensions.Find;
using EpiserverExtensions.Services;
using System.Linq;

namespace EpiserverExtensions.ContentTypes.CustomizedListing
{
    public class CustomizedListingComposer : QueryComposer<CustomizedListingBlock, ListingQueryContext>
    {
        public CustomizedListingComposer(EPiServer.IContentLoader contentLoader, IClient client)
            : base(contentLoader, client)
        {
        }

        public override ITypeSearch<IContent> Compose(IQueryContext query)
        {
            var queryContext = this.GetQuery(query);
            var content = this.ContentLoader.Get<CustomizedListingBlock>(new ContentReference(query.ContentId));

            var findQuery = this.Client.Search<ISearchableContent>();

            if (!string.IsNullOrWhiteSpace(queryContext.SearchText))
            {
                findQuery = findQuery.For(queryContext.SearchText);
            }

            if (!string.IsNullOrWhiteSpace(content.IncludedContents))
            {
                var contentTypeIds = content.IncludedContents.Split(',');

                if (contentTypeIds != null && contentTypeIds.Any())
                {
                    foreach (var contentTypeId in contentTypeIds)
                    {
                        findQuery = findQuery.OrFilter(m => m.ContentTypeID.Match(int.Parse(contentTypeId)));
                    }
                }
            }

            if (!ContentReference.IsNullOrEmpty(queryContext.RootSearch))
            {
                findQuery = findQuery.Filter(m => m.ParentLink.ID.Match(queryContext.RootSearch.ID));
            }


            return findQuery.Filter(m => m.IsDeleted.Match(false))
                                 .Skip((queryContext.CurrentPage - 1) * content.PageSize)
                                 .Take(content.PageSize)
                                 .OrderBy(m => m.Keywords);
        }
    }
}
