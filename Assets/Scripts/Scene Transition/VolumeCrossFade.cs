using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class VolumeCrossFade : MonoBehaviour
{

	[SerializeField] private AudioMixer mixer;
	[SerializeField] private float duration = 1.0f;

	private IEnumerator fadeInProgress;

    void Awake()
    {
		if (mixer == null)
		{
			Debug.Log("Error: AudioMixer not provided to VolumeCrossFade script.");
			Destroy(this);
		}
    }

    void Start()
    {
    	AudioMixerVolume.SetAudioMixerGroupVolume(mixer, "Master", 0.0f);
    	fadeInProgress = AudioMixerVolume.Fade(mixer, "Master", duration, Settings.MASTER_VOLUME);
    	StartCoroutine(fadeInProgress);
    	SceneLoader.SceneLoaderInstance.sceneLoadDelegate += FadeOut;
    }

    private void FadeOut(float time)
    {
    	StopCoroutine(fadeInProgress);
    	StartCoroutine(AudioMixerVolume.Fade(mixer, "Master", time, 0));
    }
}
