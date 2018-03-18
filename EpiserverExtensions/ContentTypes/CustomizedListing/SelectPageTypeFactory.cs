using EPiServer.DataAbstraction;
using EPiServer.ServiceLocation;
using EPiServer.Shell.ObjectEditing;
using System.Collections.Generic;
using System.Linq;

namespace EpiserverExtensions.ContentTypes.CustomizedListing
{
    public class SelectPageTypeFactory : ISelectionFactory
    {
        public IEnumerable<ISelectItem> GetSelections(ExtendedMetadata metadata)
        {
            var contentTypeRepository = ServiceLocator.Current.GetInstance<IContentTypeRepository>();

            var searchableContents = contentTypeRepository
                .List()
                .Where(c => typeof(ISearchableContent).IsAssignableFrom(c.ModelType));

            return searchableContents.Select(m => new SelectItem()
            {
                Text = m.DisplayName,
                Value = m.ID
            });
        }
    }
}
