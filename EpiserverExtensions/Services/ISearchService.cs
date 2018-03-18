using EPiServer.Core;

namespace EpiserverExtensions.Services
{
    public interface ISearchService
    {
        IPagedList<TContent> Fetch<TContent>(IQueryContext query) where TContent : IContentData;
    }
}
