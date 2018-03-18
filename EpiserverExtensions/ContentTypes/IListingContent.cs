using EPiServer.Core;

namespace EpiserverExtensions.ContentTypes
{
    public interface IListingContent : IContentData
    {

    }

    public interface IScopedSearchContent : IListingContent
    {
        ContentReference Root { get; }
    }

    public interface IPaginableContent : IListingContent
    {
        int PageSize { get; }
    }
}
