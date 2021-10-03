using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioLayerManager : MonoBehaviour
{

    [SerializeField] private AudioSource[] sourceLayer1;
    [SerializeField] private AudioSource[] sourceLayer2;
    [SerializeField] private AudioSource[] sourceLayer3;
    [SerializeField] private AudioSource[] sourceLayer4;

    public static float parameterLayer1 = 0;
    public static float parameterLayer2 = 0;
    public static float parameterLayer3 = 0;
    public static float parameterLayer4 = 0;

    private static bool isLayer1Crossfaded = false;
    private static bool isLayer2Crossfaded = false;
    private static bool isLayer3Crossfaded = false;
    private static bool isLayer4Crossfaded = false;

    private float crossfadeTime = 4f;

    // Update is called once per frame
    void Update()
    {
        SetLayer1();
        SetLayer2();
        SetLayer3();
        SetLayer4();
    }

    public void CrossfadeLayer1()
    {
        if (!isLayer1Crossfaded)
        {
            StartCoroutine(LerpLayer1());
            isLayer1Crossfaded = true;
        }
    }

    public void CrossfadeLayer2()
    {
        if (!isLayer2Crossfaded)
        {
            StartCoroutine(LerpLayer2());
            isLayer2Crossfaded = true;
        }

    }

    public void CrossfadeLayer3()
    {
        if (!isLayer3Crossfaded)
        {
            StartCoroutine(LerpLayer3());
            isLayer3Crossfaded = true;
        }
    }

    public void CrossfadeLayer4()
    {
        if (!isLayer4Crossfaded)
        {
            StartCoroutine(LerpLayer4());
            isLayer4Crossfaded = true;
        }
    }

    private void SetLayer1()
    {
        sourceLayer1[0].volume = 1 - parameterLayer1;
        sourceLayer1[1].volume = parameterLayer1;
    }

    private void SetLayer2()
    {
        sourceLayer2[0].volume = 1 - parameterLayer2;
        sourceLayer2[1].volume = parameterLayer2;
    }

    private void SetLayer3()
    {
        sourceLayer3[0].volume = 1 - parameterLayer3;
        sourceLayer3[1].volume = parameterLayer3;
    }

    private void SetLayer4()
    {
        sourceLayer4[0].volume = 1 - parameterLayer4;
        sourceLayer4[1].volume = parameterLayer4;
    }

    #region COROUTINES
    private IEnumerator LerpLayer1()
    {
        float currentTime = 0;

        while (currentTime < crossfadeTime)
        {
            currentTime += Time.deltaTime;
            parameterLayer1 = Mathf.Lerp(0, 1, currentTime / crossfadeTime);
            yield return null;
        }
        yield break;
    }

    private IEnumerator LerpLayer2()
    {
        float currentTime = 0;

        while (currentTime < crossfadeTime)
        {
            currentTime += Time.deltaTime;
            parameterLayer2 = Mathf.Lerp(0, 1, currentTime / crossfadeTime);
            yield return null;
        }
        yield break;
    }

    private IEnumerator LerpLayer3()
    {
        float currentTime = 0;

        while (currentTime < crossfadeTime)
        {
            currentTime += Time.deltaTime;
            parameterLayer3 = Mathf.Lerp(0, 1, currentTime / crossfadeTime);
            yield return null;
        }
        yield break;
    }

    private IEnumerator LerpLayer4()
    {
        float currentTime = 0;

        while (currentTime < crossfadeTime)
        {
            currentTime += Time.deltaTime;
            parameterLayer4 = Mathf.Lerp(0, 1, currentTime / crossfadeTime);
            yield return null;
        }
        yield break;
    }

    #endregion
}
