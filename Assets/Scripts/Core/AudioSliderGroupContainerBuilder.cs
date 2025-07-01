using Audio;
using VContainer;
using VContainer.Unity;

namespace Core
{
    public sealed class AudioSliderGroupContainerBuilder : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<IAudioSliderPresenter, AudioSliderPresenter>(Lifetime.Scoped);
        }
    }
}