using EPiServer.ServiceLocation;
using EpiserverExtensions.ContentTypes.CustomizedListing;
using EpiserverExtensions.ContentTypes.Listing;
using EpiserverExtensions.Find;
using EpiserverExtensions.Services;

namespace EpiserverExtensions.Extensions
{
    public static class EpiserverExtensions
    {
        public static void UserDefaultService(this IServiceConfigurationProvider serviceConfigurationProvider)
        {
            serviceConfigurationProvider.AddHttpContextOrThreadScoped<ISearchService, EpiserverFindService>();
            serviceConfigurationProvider.AddSingleton<IQueryComposerResolver, DefaultQueryComposerResolver>();
            serviceConfigurationProvider.AddHttpContextOrThreadScoped<IQueryComposer, ListingComposer>();
            serviceConfigurationProvider.AddHttpContextOrThreadScoped<IQueryComposer, CustomizedListingComposer>();
        }
    }
}
