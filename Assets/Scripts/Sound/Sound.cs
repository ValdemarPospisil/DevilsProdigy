using UnityEngine;
using UnityEngine.Audio;
    [System.Serializable]


    public class Sound
{
    public string name;
    public enum AudioType { SFX, Music }
    public AudioType audioType;

    public AudioClip clip;


    [Range(.1f, 3f)]
    public float pitch = 1f;
    [Range(0f, 1f)]
  public float volume = 1f;

    public bool isLoop;
    public bool isMute;
    public bool hasCooldown;
    public AudioSource source;
}