using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace Audio
{
    public sealed class AudioSliderGroup : MonoBehaviour
    {
        [SerializeField] private Slider masterSlider;
        [SerializeField] private Slider aaaSlider;
        [SerializeField] private Slider bbbSlider;

        private IAudioSliderPresenter _presenter;

        [Inject]
        public void Construct(IAudioSliderPresenter presenter)
        {
            _presenter = presenter;
        }

        private void Start()
        {
            masterSlider.onValueChanged.AddListener(OnMasterSliderValueChanged);
            aaaSlider.onValueChanged.AddListener(OnAaaSliderValueChanged);
            bbbSlider.onValueChanged.AddListener(OnBbbSliderValueChanged);
        }

        private void OnMasterSliderValueChanged(float value)
        {
            Debug.Log("Master slider value changed: " + value);
            _presenter.SetMasterVolume(value);
        }

        private void OnAaaSliderValueChanged(float value)
        {
            Debug.Log("AAA slider value changed: " + value);
            _presenter.SetAaaVolume(value);
        }

        private void OnBbbSliderValueChanged(float value)
        {
            Debug.Log("BBB slider value changed: " + value);
            _presenter.SetBbbVolume(value);
        }
    }
}