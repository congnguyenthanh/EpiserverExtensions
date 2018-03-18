using EPiServer.Core;

namespace EpiserverExtensions.Services
{
    public class SearchResultViewModel<TContent> where TContent : IContentData
    {
        public IContent CurrentContent { get; }

        public IPagedList<TContent> Result { get; }

        public SearchResultViewModel(IPagedList<TContent> result, IContent currentContent)
        {
            this.CurrentContent = currentContent;
            this.Result = result;
        }
    }
}
