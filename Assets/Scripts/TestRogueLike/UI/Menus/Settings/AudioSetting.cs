using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TestRogueLike.UI.Menus.Settings
{
    public class AudioSetting : MonoBehaviour
    {
        [SerializeField] private Slider slider;
        [SerializeField] private TextMeshProUGUI text;
        
        private void Start()
        {
            slider.onValueChanged.AddListener(delegate { UpdateAudio(); });
            slider.value = AudioListener.volume * slider.maxValue;
        }

        private void UpdateAudio()
        {
            var percent = (slider.value / slider.maxValue);
            AudioListener.volume = percent;
            percent *= 100;
            text.SetText($"Audio({percent:f0}%)");
        }
    }
}