using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class AudioOptionsManager : MonoBehaviour
{
    public static float musicVolume  { get; private set; }
    public static float SFXVolume { get; private set; }
    [SerializeField] private Slider musicVolumeSlider;
    [SerializeField] private Slider SFXVolumeSlider;

    [SerializeField] private TextMeshProUGUI musicSliderText;
    [SerializeField] private TextMeshProUGUI soundEffectsSliderText;

    private void Start() {
        
        
        OnMusicSliderValueChange(PlayerPrefs.GetFloat("MusicVolume"));
        OnSoundEffectsSliderValueChange(PlayerPrefs.GetFloat("SFXVolume"));
    }

   

    public void OnMusicSliderValueChange(float value)
    {
        musicVolume = value;
        
        musicSliderText.text = ((int)(value * 100) + "%").ToString();
        musicVolumeSlider.value = value;
        PlayerPrefs.SetFloat("MusicVolume", musicVolume);
        SoundManager.instance.UpdateMixerVolume();
    }

    public void OnSoundEffectsSliderValueChange(float value)
    {
        SFXVolume = value;

        soundEffectsSliderText.text = ((int)(value * 100) + "%").ToString();
        SFXVolumeSlider.value = value;
        PlayerPrefs.SetFloat("SFXVolume", SFXVolume);
        SoundManager.instance.UpdateMixerVolume();
    }




}