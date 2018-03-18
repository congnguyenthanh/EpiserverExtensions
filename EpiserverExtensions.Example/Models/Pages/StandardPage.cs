using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using EpiserverExtensions.ContentTypes;

namespace EpiserverExtensions.Example.Models.Pages
{
    [ContentType(DisplayName = "StandardPage", GUID = "640352af-e267-4d20-a1e2-9fe9ab49a86d", Description = "")]
    public class StandardPage : PageData, ISearchableContent
    {

        [CultureSpecific]
        [Display(
            Name = "Main body",
            Description = "The main body will be shown in the main content area of the page, using the XHTML-editor you can insert for example text, images and tables.",
            GroupName = SystemTabNames.Content,
            Order = 1)]
        public virtual XhtmlString MainBody { get; set; }

        [CultureSpecific]
        [Display(Name = "Title", Order = 10)]
        public virtual string Title { get; set; }

        [CultureSpecific]
        [Display(Name = "Content", Order = 20)]
        public virtual ContentArea Content { get; set; }

        public string Keywords => this.Title;
    }
}