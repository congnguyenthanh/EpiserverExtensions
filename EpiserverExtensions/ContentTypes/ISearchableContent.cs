using EPiServer.Core;

namespace EpiserverExtensions.ContentTypes
{
    public interface ISearchableContent : IContent
    {
        string Keywords { get; }
    }
}
