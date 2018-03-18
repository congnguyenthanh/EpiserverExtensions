using EpiserverExtensions.Services;

namespace EpiserverExtensions.ContentTypes.Listing
{
    public class ListingQueryContext : PaginableScopedQueryContext
    {
        public string SearchText { get; set; }
    }
}
