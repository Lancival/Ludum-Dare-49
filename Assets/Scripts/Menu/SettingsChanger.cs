using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[RequireComponent(typeof(CanvasGroupFade))]

public class SettingsChanger : MonoBehaviour
{
    public static SettingsChanger SettingsChangerInstance {get; private set;}
    [SerializeField] private AudioMixer mixer;
    private CanvasGroupFade fader;
    private bool open = false;

    void Awake()
    {
        SettingsChangerInstance = this;
        fader = GetComponent<CanvasGroupFade>();
    }

    void OnDestroy()
    {
        SettingsChangerInstance = null;
    }

    //public delegate void OnMasterVolumeChangedDelegate();
    //public event OnMasterVolumeChangedDelegate masterVolumeChangedDelegate;
    public void ChangeMasterVolume(float volume)
    {
    	Settings.MASTER_VOLUME = volume;
        AudioMixerVolume.SetAudioMixerGroupVolume(mixer, "Master", volume);
    	//masterVolumeChangedDelegate?.Invoke();
    }

    //public delegate void OnMusicVolumeChangedDelegate();
    //public event OnMusicVolumeChangedDelegate musicVolumeChangedDelegate;
    public void ChangeMusicVolume(float volume)
    {
    	Settings.MUSIC_VOLUME = volume;
        AudioMixerVolume.SetAudioMixerGroupVolume(mixer, "MX", volume);
    	//musicVolumeChangedDelegate?.Invoke();
    }

    //public delegate void OnSFXVolumeChangedDelegate();
    //public event OnSFXVolumeChangedDelegate SFXVolumeChangedDelegate;
    public void ChangeSFXVolume(float volume)
    {
    	Settings.SFX_VOLUME = volume;
        AudioMixerVolume.SetAudioMixerGroupVolume(mixer, "SX", volume);
    	//SFXVolumeChangedDelegate?.Invoke();
    }

    public delegate void OnTextDelayChangedDelegate();
    public event OnTextDelayChangedDelegate textDelayChangedDelegate;
    public void ChangeTextDelay(float delay)
    {
    	Settings.TEXT_DELAY = delay;
    	textDelayChangedDelegate?.Invoke();
    }

    public delegate void OnTextScaleChangedDelegate();
    public event OnTextScaleChangedDelegate textScaleChangedDelegate;
    public void ChangeTextScale(float scale)
    {
    	Settings.TEXT_SCALE = scale;
    	textScaleChangedDelegate?.Invoke();
    }

    public void OpenSettings()
    {
        if (!open)
        {
            open = true;
            Settings.PAUSED = true;
            fader.FadeIn();
        }
    }

    public void CloseSettings()
    {
        if (open)
        {
        	open = false;
        	Settings.PAUSED = false;
            fader.FadeOut();
        }
    }
}
