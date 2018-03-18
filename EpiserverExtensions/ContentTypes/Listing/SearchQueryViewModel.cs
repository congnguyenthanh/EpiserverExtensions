using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpiserverExtensions.ContentTypes.Listing
{
    public class SearchQueryViewModel : PaginableQueryViewModel
    {
        public string SearchText { get; set; }
    }
}
