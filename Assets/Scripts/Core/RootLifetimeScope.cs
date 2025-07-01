using UnityEngine;
using UnityEngine.Audio;
using VContainer;
using VContainer.Unity;

namespace Core
{
    public sealed class RootLifetimeScope : LifetimeScope
    {
        [SerializeField] private AudioMixer audioMixer1;
        private const string AudioMixerLoadKey = "Assets/Audio/AudioMixer.mixer";

        protected override void Configure(IContainerBuilder builder)
        {
            Debug.Log("RootLifetimeScope configured with AudioMixer instance.");

            // [Failure] Load AudioMixer from SerializedField
            builder.RegisterInstance(audioMixer1);

            // [Success] Load AudioMixer from Addressables
            // var audioMixer2 = Addressables.LoadAssetAsync<AudioMixer>(AudioMixerLoadKey).WaitForCompletion();
            // builder.RegisterInstance(audioMixer2);
        }
    }
}