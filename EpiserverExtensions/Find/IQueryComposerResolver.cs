using EpiserverExtensions.Services;

namespace EpiserverExtensions.Find
{
    public interface IQueryComposerResolver
    {
        IQueryComposer Resolve(IQueryContext query);
    }
}
