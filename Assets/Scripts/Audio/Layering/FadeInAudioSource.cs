using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInAudioSource : MonoBehaviour
{
    [SerializeField] private AudioSource[] audioSources;
    [SerializeField] private AudioSetVolumeBasedOnLayerValues[] layersSystem;
    private float fadeTime = 1f;
    private float targetVolume = 1f;

    public void FadeMusicLayers()
    {
        foreach(AudioSource aSource in audioSources)
        {
            StartCoroutine(AudioUtility.FadeAudioSource(aSource, fadeTime, targetVolume));
        }

        StartCoroutine(SetAudioSOurceVolumeUpdateToTrue());
    }

    private IEnumerator SetAudioSOurceVolumeUpdateToTrue()
    {
        yield return new WaitForSeconds(fadeTime);

        foreach(AudioSetVolumeBasedOnLayerValues layerS in layersSystem)
        {
            layerS.updateValue = true;
        }
    }
}
