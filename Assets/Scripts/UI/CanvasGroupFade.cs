using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]

public class CanvasGroupFade : MonoBehaviour
{

	private CanvasGroup canvasGroup;	// Canvas Group component attached to the game object this script is attached to
	private IEnumerator fadeInProgress;	// Current fading coroutine being run

	public float fadeInDurationDefault = 1.0f;	// Default amount of time the FadeIn() function should take
	public float fadeOutDurationDefault = 1.0f;	// Default amount of time the FadeOut() function should take

    // Find the canvasGroup when this script is initialized
    void Awake()
    {
        canvasGroup = gameObject.GetComponent<CanvasGroup>();

        // If the canvasGroup is missing, destroy this script
        if (canvasGroup == null)
        {
        	Debug.Log("Error: CanvasGroupFade script on " + gameObject.name + " unable to find CanvasGroup component.");
        	Destroy(this);
        }
    }

    /* Changes the alpha value of the CanvasGroup over time and enables/disables the GameObject the CanvasGroup is attached to
     * Parameters:
     * CanvasGroup cg: The Canvas Group that will have its alpha value changed
     * float start: Starting value of alpha to fade from, should be between 0 and 1 inclusive
     * float end: Ending value of alpha to fade to, should be between 0 and 1 inclusive
     * float duration: Duration of fade (in seconds), should be a non-negative number
     * bool active: Whether the gameObject should end active or not
     */
    private static IEnumerator FadeCanvasGroup(CanvasGroup cg, float start, float end, float duration, bool interactable) {
    	// Check for valid parameters
    	if (start < 0 || start > 1 || end < 0 || end > 1)
    	{
    		Debug.Log("Error: Alpha value for FadeCanvasGroup must be between 0 and 1.");
    		yield break;
    	}
    	else if (duration < 0)
    	{
    		Debug.Log("Error: Fade duration for FadeCanvasGroup must be a non-negative number of seconds.");
    		yield break;
    	}
    	else if (cg == null)
    	{
    		Debug.Log("Error: FadeCanvasGroup provided a null CanvasGroup.");
    		yield break;
    	}

    	// Handle instantaneous "fades"
    	if (duration == 0)
    		cg.alpha = end;
    	// Handle fades over time
    	else
    	{
    		// Set the alpha value to the starting value and enable the GameObject
    		cg.alpha = start;
    		cg.gameObject.SetActive(true);

	    	// Lerp alpha value of CanvasGroup between start and end values
	    	float startTime = Time.time;	// Time at which lerp started
	    	float fraction = 0;				// Fraction of duration elapsed so far

	    	while (true) {
	    		fraction = (Time.time - startTime) / duration;	// Update fraction of duration elapsed

	    		// If the duration is not finished, update the alpha value of CanvasGroup
	    		if (fraction < 1)
	    			cg.alpha = Mathf.Lerp(start, end, fraction);
	    		// If the duration has finished, change the alpha value to the end value and break out of while loop
	    		else
	    		{
	    			cg.alpha = end;
	    			break;
	    		}

	    		// Wait until the next frame to update alpha values again
	    		yield return new WaitForEndOfFrame();
	    	}
	    }

        if (interactable)
        {
            cg.interactable = true;
            cg.blocksRaycasts = true;
        }
        else
        {
            cg.interactable = false;
            cg.blocksRaycasts = false;
        }
    }

    // Stops any ongoing fade coroutine
    private void StopFade()
    {
    	if (fadeInProgress != null)
    		StopCoroutine(fadeInProgress);
    }

    // Wrapper function for FadeCanvasGroup
    public void Fade(float start, float end, float duration, bool interactable)
    {
    	StopFade();
    	fadeInProgress = FadeCanvasGroup(canvasGroup, start, end, duration, interactable);
        StartCoroutine(fadeInProgress);
    }

    // Wrapper function for Fade(), fades CanvasGroup alpha from 0 to 1 over the duration parameter
    public void FadeIn(float duration)
    {
    	Fade(0, 1, duration, true);
    }

    // Overloaded function, fades CanvasGroup alpha from 0 to 1 over the default duration
    public void FadeIn()
    {
    	Fade(0, 1, fadeInDurationDefault, true);
    }

    // Wrapper function for Fade(), fades CanvasGroup alpha from 1 to 0
    public void FadeOut(float duration)
    {
    	Fade(1, 0, duration, false);
    }

    // Overloaded function, fades CanvasGroup alpha from 1 to 0 over the default duration
    public void FadeOut()
    {
    	Fade(1, 0, fadeOutDurationDefault, false);
    }
}
