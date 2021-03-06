using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioConcatenation : MonoBehaviour
{
    [Header("AUDIO REFERENCES")]
    [SerializeField] private AudioConfigurationSO config;
    [SerializeField] private AudioClipCueSO cue;
    [SerializeField] private AudioSource[] audioSources; //Array with 2 audio sources
    [SerializeField] private AudioSource audioSourceStop;
    [Space]
    [Header("CONCATENATION PROPERTIES")]
    [SerializeField] private PlayOnAwakeMethod playOnAwake = PlayOnAwakeMethod.No;

    private bool isPlaying;
    private int toggle;
    private double nextStartTime, dspTimeOffset = 0.1;

    private enum PlayOnAwakeMethod { No, PlayWithNoFade, PlayWithFade }

    private float maxTextSpeed = 0.15f;
    private float textSpeedMultiplier = 1.25f;

    // Start is called before the first frame update
    void Awake()
    {
        Initialize();

        if (playOnAwake == PlayOnAwakeMethod.PlayWithNoFade)
            Play(false);
        else if (playOnAwake == PlayOnAwakeMethod.PlayWithFade)
            Play(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlaying)
        {
            if (AudioSettings.dspTime > nextStartTime - dspTimeOffset)
                Concatenate();
        }
    }

    #region Concatenation

    private void Concatenate()
    {
        ScheduleAudioSource();
        IncrementNextStartTime();
    }

    private void ScheduleAudioSource()
    {
        toggle = 1 - toggle;

        audioSources[toggle].clip = cue.GetNextClip();
        audioSources[toggle].pitch = cue.RandomPitch();
        audioSources[toggle].PlayScheduled(nextStartTime);

        //print("CONCATENATE: " + audioSources[toggle].clip + " on " + gameObject.name);
    }

    private void IncrementNextStartTime()
    {
        float textSpeed = Settings.TEXT_DELAY * textSpeedMultiplier;
        nextStartTime += textSpeed < maxTextSpeed ? maxTextSpeed : textSpeed;
    }
    #endregion

    #region Start and Stop 
    private void Initialize()
    {
        foreach (AudioSource aSource in audioSources)
        {
            config.SetupAudioSource(aSource);
            cue.Initialize(aSource);
        }
    }

    public void Play(bool fadeIn)
    {
        if (isPlaying) { return; }

        Initialize();

        if (fadeIn)
            FadeIn();

        isPlaying = true;
        nextStartTime = AudioSettings.dspTime + dspTimeOffset;

        //print("PLAY " + audioSources[toggle].clip);
    }

    public void Stop(bool fadeOut)
    {
        if (!isPlaying) { return; }

        if (fadeOut)
        {
            FadeOut();
        }
        else
        {
            isPlaying = false;
            foreach (AudioSource aSource in audioSources)
                aSource.Stop();

            audioSourceStop.PlayOneShot(cue.GetNextClip());
        }

        //print("STOP: " + gameObject.name);
    }

    #endregion

    #region Fades
    public void FadeIn()
    {
        foreach (AudioSource aSource in audioSources)
        {
            aSource.volume = 0;
            StartCoroutine(AudioUtility.FadeAudioSource(aSource, cue.fadeInTime, cue.Volume));
        }

        //print("FADE IN: " + gameObject.name);
    }

    public void FadeOut()
    {
        StartCoroutine(StopLoopAfterFadeOut());
        foreach (AudioSource aSource in audioSources)
            StartCoroutine(AudioUtility.FadeOutAndStopAudioSource(aSource, cue.fadeOutTime));

        print("FADE OUT: " + gameObject.name);
    }

    private IEnumerator StopLoopAfterFadeOut()
    {
        yield return new WaitForSeconds(cue.fadeOutTime);
        isPlaying = false;
    }
    #endregion
}
