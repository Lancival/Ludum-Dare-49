using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]

public class InitializeSlider : MonoBehaviour
{

	private Slider slider;
	[SerializeField] private int setting;

	void Awake()
	{
		slider = GetComponent<Slider>();
		if (slider == null)
		{
			Debug.Log("InitializeSlider script unable to find Slider component.");
			Destroy(this);
		}
	}

    void Start()
    {
    	switch (setting)
    	{
    		case 0:
    			slider.value = Settings.MASTER_VOLUME;
    			break;
    		case 1:
    			slider.value = Settings.MUSIC_VOLUME;
    			break;
    		case 2:
    			slider.value = Settings.SFX_VOLUME;
    			break;
    		case 3:
    			slider.value = Settings.TEXT_DELAY;
    			break;
    		default:
    			slider.value = Settings.TEXT_SCALE;
    			break;
    	}
    }
}
