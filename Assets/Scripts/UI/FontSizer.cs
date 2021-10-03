using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
[DisallowMultipleComponent]

public class FontSizer : MonoBehaviour
{

	private TextMeshProUGUI text;
	private float defaultFontSize;

	void Awake()
	{
		text = GetComponent<TextMeshProUGUI>();
		if (text == null)
		{
			Debug.Log("Error: FontSizer script unable to find TextMeshPro component.");
			Destroy(this);
		}

		defaultFontSize = text.fontSize;
	}

    void Start()
    {
    	text.fontSize = defaultFontSize * Settings.TEXT_SCALE;
    	if (SettingsChanger.SettingsChangerInstance != null)
    	{
    		SettingsChanger.SettingsChangerInstance.textScaleChangedDelegate += ChangeTextSize;
    	}
    }

    void ChangeTextSize()
    {
    	text.fontSize = Settings.TEXT_SCALE * defaultFontSize;
    }
}
