using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Shell.ObjectEditing;
using EpiserverExtensions.ContentTypes.Listing;
using System.ComponentModel.DataAnnotations;

namespace EpiserverExtensions.ContentTypes.CustomizedListing
{
    [ContentType(DisplayName = "Customized Listing Block", GUID = "9726e73a-a204-4edd-a4e8-c5d1b06d0a7b", Description = "")]
    public class CustomizedListingBlock : ListingBlock
    {
        [SelectMany(SelectionFactoryType = typeof(SelectPageTypeFactory))]
        [Display(Name = "Content types for listing", Order = 50)]
        public virtual string IncludedContents { get; set; }
    }
}