using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class PlayAnimationOnSceneLoad : MonoBehaviour
{
    private Animator animator;

	// Find the CanvasGroupFade script
	void Awake()
	{
		animator = transform.GetComponent<Animator>();
		if (animator == null)
		{
			Debug.Log("PlayAnimationOnSceneLoad script unable to locate Animator component.");
			Destroy(this);
		}
	}

	// Add the FadeIn() function to the sceneLoadDelegate
    void Start()
    {
        SceneLoader.SceneLoaderInstance.sceneLoadDelegate += TriggerAnimation;
    }

    private void TriggerAnimation(float duration)
    {
    	animator.SetTrigger("End Scene");
    }
}

// Note to Self: Check if SceneLoader.SceneLoaderInstance is null!!!
