using System.ComponentModel.DataAnnotations;

namespace EpiserverExtensions.ContentTypes
{
    public abstract class QueryViewModel
    {
        [Required]
        [Range(1, int.MaxValue)]
        public virtual int ContentId { get; set; }
    }

    public class PaginableQueryViewModel : QueryViewModel
    {
        [Required]
        [Range(1, int.MaxValue)]
        public virtual int Page { get; set; }
    }
}
