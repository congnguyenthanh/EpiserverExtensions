using EPiServer.Core;
using EPiServer.Find;
using EpiserverExtensions.Find;
using EpiserverExtensions.Services;
using System.Linq;

namespace EpiserverExtensions.ContentTypes.Listing
{
    public class ListingComposer : QueryComposer<ListingBlock, ListingQueryContext>
    {
        public ListingComposer(EPiServer.IContentLoader contentLoader, IClient client) : base(contentLoader, client)
        {
        }

        public override ITypeSearch<IContent> Compose(IQueryContext query)
        {
            var queryContext = this.GetQuery(query);

            var content = this.ContentLoader.Get<IContent>(new ContentReference(query.ContentId)) as ListingBlock;

            var findQuery = this.Client.Search<ISearchableContent>();

            if (!string.IsNullOrWhiteSpace(queryContext.SearchText))
            {
                findQuery = findQuery.For(queryContext.SearchText);
            }

            if (!ContentReference.IsNullOrEmpty(queryContext.RootSearch))
            {
                findQuery = findQuery.Filter(m => m.ParentLink.ID.Match(queryContext.RootSearch.ID));
            }

            return findQuery.Filter(m => m.IsDeleted.Match(false))
                                 .Skip((queryContext.CurrentPage - 1) * queryContext.PageSize)
                                 .Take(content.PageSize)
                                 .OrderBy(m => m.Keywords);
        }
    }
}
