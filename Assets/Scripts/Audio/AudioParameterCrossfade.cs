using System.Collections;
using UnityEngine;

public class AudioParameterCrossfade : MonoBehaviour
{
    [SerializeField] private AudioSource[] audioSource;
    [Range(0f, 1f)] public float crossfade;
    private bool changeValue = false;

    private float duration = 3f;

    private void Start()
    {
        audioSource[0].volume = 1;
        audioSource[1].volume = 0;
    }

    void LateUpdate()
    {
        //if(changeValue)
        CrossfadeAudioWithParameter();
    }

    private void CrossfadeAudioWithParameter()
    {
        audioSource[0].volume = 1 - crossfade;
        audioSource[1].volume = crossfade;
    }

    public void FadeCrossfadeValue(float targetValue)
    {
        StartCoroutine(LerpCrossfade(targetValue));
    }

    private IEnumerator LerpCrossfade(float targetValue) //, float duration)
    {
        float startingValue = crossfade;
        float currentTime = 0;
        changeValue = true;

        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            crossfade = Mathf.Lerp(startingValue, targetValue, currentTime / duration);

            yield return null;
        }

        changeValue = false;
        yield break;
    }
}