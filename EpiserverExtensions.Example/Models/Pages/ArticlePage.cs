using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EpiserverExtensions.ContentTypes;

namespace EpiserverExtensions.Example.Models.Pages
{
    [ContentType(DisplayName = "ArticlePage", GUID = "68232d3f-26bd-4238-94fd-40f59a1be93c", Description = "")]
    public class ArticlePage : StandardPage, ISearchableContent
    {
        public string Keywords => this.Title;
    }
}