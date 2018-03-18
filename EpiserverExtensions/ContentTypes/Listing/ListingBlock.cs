using EPiServer.Core;
using EPiServer.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpiserverExtensions.ContentTypes.Listing
{
    [ContentType(DisplayName = "Listing Block", GUID = "9e61447f-df0d-4610-b104-b616bce7fc43", Description = "")]
    public class ListingBlock : BlockData, IScopedSearchContent, IPaginableContent
    {
        [CultureSpecific]
        [Display(Name = "Title")]
        public virtual string Title { get; set; }

        [CultureSpecific]
        [Display(Name = "Configurable root for listing all result under it", Order = 10)]
        public virtual ContentReference Root { get; set; }

        [Display(Name = "Number of items will be returned per request", Order = 20)]
        public virtual int PageSize { get; set; }
    }
}
