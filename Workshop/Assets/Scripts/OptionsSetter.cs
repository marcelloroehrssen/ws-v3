using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class OptionsSetter : MonoBehaviour
{
    public Slider musicVolumeSlider;

    public Slider effectVolumeSlider;

    public AudioMixer mixer;

    public void MuteMusic(bool mute)
    {
        if (mute)
        {
            mixer.SetFloat("MusicVolume", -80f);
        } else
        {
            mixer.SetFloat("MusicVolume", Mathf.Log10(musicVolumeSlider.value) * 20);
        }
    }

    public void MuteEffect(bool mute)
    {
        if (mute)
        {
            mixer.SetFloat("EffectVolume", -80f);
        }
        else
        {
            mixer.SetFloat("EffectVolume", Mathf.Log10(effectVolumeSlider.value) * 20);
        }
    }

    public void SetMusicVolume(float volume)
    {
        mixer.SetFloat("MusicVolume", Mathf.Log10(volume) * 20);
    }

    public void SetEffectVolume(float volume)
    {
        mixer.SetFloat("EffectVolume", Mathf.Log10(volume) * 20);
    }
}
