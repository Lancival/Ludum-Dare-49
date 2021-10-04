using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioQuestComplete : MonoBehaviour
{
    [SerializeField] private AudioPlayOneShot[] stingers;
    private int index;


    public void DoAudioStuff()
    {
        PlayMusicStinger();
        CrossfadeLayer();
    }

    private void PlayMusicStinger()
    {
        stingers[index].Play();
        index++;
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
                break;
            case 3:
                AudioLayerManager.instance.CrossfadeLayer4();
                break;
        }
    }
}
