using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CanvasGroupFade))]

public class FadeOnSceneStart : MonoBehaviour
{
    private CanvasGroupFade canvasGroupFade;
    public float transitionDurationDefault = 1.0f;

	// Find the CanvasGroupFade script
	void Awake()
	{
		canvasGroupFade = transform.GetComponent<CanvasGroupFade>();
		if (canvasGroupFade == null)
		{
			Debug.Log("FadeOnSceneStart script unable to locate CanvasGroupFade script component.");
			Destroy(this);
		}
	}

	// FadeOut() at the start of the scene
    void Start()
    {
        canvasGroupFade.FadeOut(transitionDurationDefault);
    }
}
