using EPiServer.Core;
using System.Collections.Generic;

namespace EpiserverExtensions.Services
{
    public interface IPagedList
    {
        int Page { get; }

        int PageSize { get; }

        int TotalItems { get; }

        int TotalPage { get; }
    }
    
    public interface IPagedList<TContent> : IPagedList, IEnumerable<TContent> where TContent : IContentData
    {

    }
}
