using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSetVolumeBasedOnLayerValues : MonoBehaviour
{
    public enum LayerNumber { Layer1, Layer2, Layer3, Layer4 };

    [SerializeField] private AudioSource audioSourceSpooky, audioSourceNormal;
    [SerializeField] private LayerNumber layerNumber;
    [SerializeField] private bool updateValue;

    // Update is called once per frame
    void Update()
    {
        if(updateValue)
            SetAudioSourceVolume();
    }

    private void SetAudioSourceVolume()
    {

        switch (layerNumber)
        {
            case LayerNumber.Layer1:
                audioSourceSpooky.volume = 1 - AudioLayerValues.layer1;
                audioSourceNormal.volume = AudioLayerValues.layer1;
                break;
            case LayerNumber.Layer2:
                audioSourceSpooky.volume = 1 - AudioLayerValues.layer2;
                audioSourceNormal.volume = AudioLayerValues.layer2;
                break;
            case LayerNumber.Layer3:
                audioSourceSpooky.volume = 1 - AudioLayerValues.layer3;
                audioSourceNormal.volume = AudioLayerValues.layer3;
                break;
            case LayerNumber.Layer4:
                audioSourceSpooky.volume = 1 - AudioLayerValues.layer4;
                audioSourceNormal.volume = AudioLayerValues.layer4;
                break;
        }
    }
}
