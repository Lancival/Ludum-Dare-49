using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioLayerManager : MonoBehaviour
{
    private static bool isLayer1Crossfaded = false;
    private static bool isLayer2Crossfaded = false;
    private static bool isLayer3Crossfaded = false;
    private static bool isLayer4Crossfaded = false;

    public static AudioLayerManager instance = null;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    public void CrossfadeLayer1()
    {
        if (!isLayer1Crossfaded)
        {
            StartCoroutine(AudioLayerValues.LerpLayer1());
            isLayer1Crossfaded = true;
        }
    }

    public void CrossfadeLayer2()
    {
        if (!isLayer2Crossfaded)
        {
            StartCoroutine(AudioLayerValues.LerpLayer2());
            isLayer2Crossfaded = true;
        }
    }

    public void CrossfadeLayer3()
    {
        if (!isLayer3Crossfaded)
        {
            StartCoroutine(AudioLayerValues.LerpLayer3());
            isLayer3Crossfaded = true;
        }
    }

    public void CrossfadeLayer4()
    {
        if (!isLayer4Crossfaded)
        {
            StartCoroutine(AudioLayerValues.LerpLayer4());
            isLayer4Crossfaded = true;
        }
    }
}