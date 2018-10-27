using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour {

    [SerializeField] Slider sFXVolumeSlider;
    [SerializeField] Slider musicVolumeSlider;

    public void SetSFXVolume()
    {
        SoundManager.Instance.SetSFXVolume(sFXVolumeSlider.value);
    }

    public void GetSFXVolume()
    {
        sFXVolumeSlider.value = SoundManager.Instance.GetSFXVolume();
    }

    public void SetMusicVolume()
    {
        MusicPlayer.Instance.SetMusicVolume(musicVolumeSlider.value);
    }

    public void GetMusicVolume()
    {
        musicVolumeSlider.value = MusicPlayer.Instance.GetMusicVolume();
    }
}
