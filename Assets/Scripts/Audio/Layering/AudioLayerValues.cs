using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AudioLayerValues
{
    public static float layer1, layer2, layer3, layer4;
    public static float crossfadeTime = 4;

    #region LERP COROUTINES
    public static IEnumerator LerpLayer1()
    {
        float currentTime = 0;

        while (currentTime < crossfadeTime)
        {
            currentTime += Time.deltaTime;
            layer1 = Mathf.Lerp(0, 1, currentTime / crossfadeTime);
            yield return null;
        }
        yield break;
    }

    public static IEnumerator LerpLayer2()
    {
        float currentTime = 0;

        while (currentTime < crossfadeTime)
        {
            currentTime += Time.deltaTime;
            layer2 = Mathf.Lerp(0, 1, currentTime / crossfadeTime);
            yield return null;
        }
        yield break;
    }

    public static IEnumerator LerpLayer3()
    {
        float currentTime = 0;

        while (currentTime < crossfadeTime)
        {
            currentTime += Time.deltaTime;
            layer3 = Mathf.Lerp(0, 1, currentTime / crossfadeTime);
            yield return null;
        }
        yield break;
    }

    public static IEnumerator LerpLayer4()
    {
        float currentTime = 0;

        while (currentTime < crossfadeTime)
        {
            currentTime += Time.deltaTime;
            layer4 = Mathf.Lerp(0, 1, currentTime / crossfadeTime);
            yield return null;
        }
        yield break;
    }

    public static void ResetValues()
    {
        layer1 = 0;
        layer2 = 0;
        layer3 = 0;
        layer4 = 0;
    }
    #endregion
}
