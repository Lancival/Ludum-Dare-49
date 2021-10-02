using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public static class AudioMixerVolume
{
    // Converts volume (0 to 1) to decibels
	private static float VolumeToDecibels(float volume)
	{
		return Mathf.Log10(Mathf.Clamp(volume, 0.00001f, 1)) * 20;
	}

	// Converts decibels to volume (0 to 1)
	private static float DecibelsToVolume(float decibels)
	{
		return Mathf.Pow(10, decibels / 20);
	}

	public static void SetAudioMixerGroupVolume(AudioMixer audioMixer, string exposedParam, float volume)
	{
		audioMixer.SetFloat(exposedParam, VolumeToDecibels(volume));
	}
}
