using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
  private static SoundManager _instance;

  [SerializeField] private AudioMixerGroup SFXGroup;
  [SerializeField] private AudioMixerGroup MusicGroup;
  [SerializeField] private Sound[] sounds;
  private static Dictionary<string, float> soundTimerDictionary;

  [SerializeField] private Toggle muteMusicToggle;
  [SerializeField] private Toggle muteSFXToggle;  


  public static SoundManager instance
  {
    get
    {
      return _instance;
    }
  }

  private void Awake()
  {
    if (_instance != null)
    {
      Destroy(this.gameObject);
    }
    else
    {
      _instance = this;
    }

  //  DontDestroyOnLoad(this.gameObject);

    soundTimerDictionary = new Dictionary<string, float>();

    foreach (Sound sound in sounds)
    {
      sound.source = gameObject.AddComponent<AudioSource>();
      sound.source.clip = sound.clip;
      sound.source.pitch = sound.pitch;
      sound.source.loop = sound.isLoop;
      sound.source.volume = sound.volume;
      sound.source.mute = sound.isMute;

      switch (sound.audioType)
      {
        case Sound.AudioType.SFX:
        sound.source.outputAudioMixerGroup = SFXGroup;
        break;

        case Sound.AudioType.Music:
        sound.source.outputAudioMixerGroup = MusicGroup;
        break;
      }

      if (sound.hasCooldown)
      {
        Debug.Log(sound.name);
        soundTimerDictionary[sound.name] = 0f;
      }
    }
  }

  private void Start()
  {
    // Add this part after having a theme song
    if(SceneManager.GetActiveScene().buildIndex == 0)
        {
          Play("Menu");
        } else if (SceneManager.GetActiveScene().buildIndex == 1)
        {
          Play("Base");
        } else if (SceneManager.GetActiveScene().buildIndex == 2)
        {
          Play("Plains");
        } else if (SceneManager.GetActiveScene().buildIndex == 3)
        {
          Play("Cave");
        }

    MuteMusic(PlayerPrefs.GetInt("MuteMusic") != 0);
    MuteSFX(PlayerPrefs.GetInt("MuteSFX") != 0);
    muteMusicToggle.isOn = (PlayerPrefs.GetInt("MuteMusic") != 0);
    muteSFXToggle.isOn = (PlayerPrefs.GetInt("MuteSFX") != 0);
  }
  public void Play(string name)
  {
    Sound sound = Array.Find(sounds, s => s.name == name);

    if (sound == null)
    {
      Debug.LogError("Sound " + name + " Not Found!");
      return;
    }

    if (!CanPlaySound(sound))return;

    if(!sound.isMute)
    {
      sound.source.Play();
    }
  }

  public void Stop(string name)
  {
    Sound sound = Array.Find(sounds, s => s.name == name);

    if (sound == null)
    {
      Debug.LogError("Sound " + name + " Not Found!");
      return;
    }

    sound.source.Stop();
  }


    public void MuteMusic(bool isMuted)
    {
      
        for(int i = 0; i < sounds.Length; i++) {
        {
          if(sounds[i].audioType == Sound.AudioType.Music)
          {
         //   sounds[i].isMute = isMuted; 
            sounds[i].source.mute = isMuted;
          }
        }
        
        PlayerPrefs.SetInt("MuteMusic", (isMuted ? 1 : 0));
       //   Sound sound = Array.Find(sounds,  s => s.source.outputAudioMixerGroup == MusicGroup);
       //   sound.source.mute = isMuted;  
      }
    }

       public void MuteSFX(bool isMuted)
    {

        for(int i = 0; i < sounds.Length; i++) {
        {
          if(sounds[i].audioType == Sound.AudioType.SFX)
          {
        //    sounds[i].isMute = isMuted;
            sounds[i].source.mute = isMuted;
            
          }
        }
        }
    
     //   sound.source.mute = isMuted;  

        PlayerPrefs.SetInt("MuteSFX", (isMuted ? 1 : 0));
    }

   

  private static bool CanPlaySound(Sound sound)
  {
    if (soundTimerDictionary.ContainsKey(sound.name))
    {
      float lastTimePlayed = soundTimerDictionary[sound.name];

      if (lastTimePlayed + sound.clip.length < Time.time)
      {
        soundTimerDictionary[sound.name] = Time.time;
        return true;
      }

      return false;
    }

    return true;
  }


   public void UpdateMixerVolume()
    {
        MusicGroup.audioMixer.SetFloat("MusicVolume", Mathf.Log10(AudioOptionsManager.musicVolume) * 20);
        SFXGroup.audioMixer.SetFloat("SFXVolume", Mathf.Log10(AudioOptionsManager.SFXVolume) * 20);
    }
}