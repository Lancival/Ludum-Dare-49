using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioQuestComplete : MonoBehaviour
{
    [SerializeField] private AudioPlayOneShot[] stingers;
    private static int index = 0;

    public static AudioQuestComplete instance = null;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    public void DoAudioStuff()
    {
        CrossfadeLayer();
        PlayMusicStinger();
        index++;
    }

    private void PlayMusicStinger()
    {
        stingers[index].Play();
    }

    private void CrossfadeLayer()
    {
        switch (index)
        {
            case 0:
                AudioLayerManager.instance.CrossfadeLayer1();
                break;
            case 1:
                AudioLayerManager.instance.CrossfadeLayer2();
                break;
            case 2:
                AudioLayerManager.instance.CrossfadeLayer3();
                AudioLayerManager.instance.CrossfadeLayer4();
                break;
            case 3:
                break;
        }
    }
}
