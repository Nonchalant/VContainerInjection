using UnityEngine;
using UnityEngine.Audio;
using VContainer;

namespace Audio
{
    public interface IAudioSliderPresenter
    {
        void SetMasterVolume(float value);
        void SetAaaVolume(float value);
        void SetBbbVolume(float value);
    }

    public sealed class AudioSliderPresenter : IAudioSliderPresenter
    {
        private readonly AudioMixer _audioMixer;

        [Inject]
        public AudioSliderPresenter(AudioMixer audioMixer)
        {
            _audioMixer = audioMixer;
        }

        public void SetMasterVolume(float value)
        {
            var volume = CalcVolume(value);
            _audioMixer.SetFloat("Master", volume);
        }

        public void SetAaaVolume(float value)
        {
            var volume = CalcVolume(value);
            _audioMixer.SetFloat("AAA", volume);
        }

        public void SetBbbVolume(float value)
        {
            var volume = CalcVolume(value);
            _audioMixer.SetFloat("BBB", volume);
        }

        private static float CalcVolume(float volume)
        {
            return volume switch
            {
                <= 0.0f => -80.0f,
                >= 1.0f => 0.0f,
                _ => 20.0f * Mathf.Log10(Mathf.Min(volume, 1.0f))
            };
        }
    }
}