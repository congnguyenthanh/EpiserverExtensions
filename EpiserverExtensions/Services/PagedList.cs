using EPiServer.Core;
using EpiserverExtensions.ContentTypes;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace EpiserverExtensions.Services
{
    public class PagedList<TContent> : List<TContent>, IPagedList<TContent> where TContent : IContentData
    {
        public PagedList(IEnumerable<TContent> enumerable, int page, int pageSize, int totalItems)
        {
            this.AddRange(enumerable);
            this.Page = page;
            this.TotalItems = totalItems;
            this.PageSize = pageSize;
        }

        public int Page { get; }

        public int PageSize { get; }

        public int TotalItems { get; }

        public int TotalPage => (int)(Math.Ceiling((decimal)this.TotalItems / this.PageSize));
    }
}
