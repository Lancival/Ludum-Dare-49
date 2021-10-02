using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsChanger : MonoBehaviour
{
    public delegate void OnMasterVolumeChangedDelegate();
    public event OnMasterVolumeChangedDelegate masterVolumeChangedDelegate;
    public void ChangeMasterVolume(float volume)
    {
    	Settings.MASTER_VOLUME = volume;
    	masterVolumeChangedDelegate?.Invoke();
    }

    public delegate void OnMusicVolumeChangedDelegate();
    public event OnMusicVolumeChangedDelegate musicVolumeChangedDelegate;
    public void ChangeMusicVolume(float volume)
    {
    	Settings.MUSIC_VOLUME = volume;
    	musicVolumeChangedDelegate?.Invoke();
    }

    public delegate void OnSFXVolumeChangedDelegate();
    public event OnSFXVolumeChangedDelegate SFXVolumeChangedDelegate;
    public void ChangeSFXVolume(float volume)
    {
    	Settings.SFX_VOLUME = volume;
    	SFXVolumeChangedDelegate?.Invoke();
    }

    public delegate void OnTextDelayChangedDelegate();
    public event OnTextDelayChangedDelegate textDelayChangedDelegate;
    public void ChangeTextDelay(float delay)
    {
    	Settings.TEXT_DELAY = delay;
    	textDelayChangedDelegate?.Invoke();
    }

    public delegate void OnTextSizeChangedDelegate();
    public event OnTextSizeChangedDelegate textSizeChangedDelegate;
    public void ChangeTextSize(int size)
    {
    	Settings.TEXT_SIZE = size;
    	textSizeChangedDelegate?.Invoke();
    }
}
