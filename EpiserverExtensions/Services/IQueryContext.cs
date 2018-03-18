using EPiServer.Core;
using System.Globalization;

namespace EpiserverExtensions.Services
{
    public interface IQueryContext
    {
        CultureInfo CurrentCulture { get; }

        int ContentId { get; set; }
    }

    public interface IPaginableQueryContext
    {
        int CurrentPage { get; }
        
        int PageSize { get; }
    }

    public interface IScopedQueryContext
    {
        ContentReference RootSearch { get; }
    }
}
