using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CanvasGroupFade))]

public class FadeOnSceneLoad : MonoBehaviour
{
	private CanvasGroupFade canvasGroupFade;

	// Find the CanvasGroupFade script
	void Awake()
	{
		canvasGroupFade = transform.GetComponent<CanvasGroupFade>();
		if (canvasGroupFade == null)
		{
			Debug.Log("FadeOnSceneLoad script unable to locate CanvasGroupFade script component.");
			Destroy(this);
		}
	}

	// Add the FadeIn() function to the sceneLoadDelegate
    void Start()
    {
        SceneLoader.SceneLoaderInstance.sceneLoadDelegate += canvasGroupFade.FadeIn;
    }
}
