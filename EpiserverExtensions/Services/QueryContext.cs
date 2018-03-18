using System.Globalization;
using EPiServer.Core;

namespace EpiserverExtensions.Services
{
    public class QueryContext : IQueryContext
    {
        public CultureInfo CurrentCulture => EPiServer.Globalization.ContentLanguage.PreferredCulture;

        public int ContentId { get; set; }
    }

    public class PaginableQueryContext : QueryContext, IPaginableQueryContext
    {
        public int CurrentPage { get; set; }

        public int PageSize { get; set; }
    }

    public class PaginableScopedQueryContext : PaginableQueryContext, IScopedQueryContext
    {
        public ContentReference RootSearch { get; set; }
    }
}
