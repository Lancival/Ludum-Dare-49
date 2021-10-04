using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
	public static SceneLoader SceneLoaderInstance {get; private set;}	// Current instance of SceneLoader, if one exists

	private bool loading = false;	// Whether this SceneLoader has started loading the next scene

	[SerializeField] private string nextScene;		// Name of the next scene
	public float transitionDurationDefault = 1.0f;	// Default duration of transitions that occur while loading the next scene

	// Delegate and event for functions to be called for the scene-ending transition
	public delegate void OnSceneLoadDelegate(float duration);
	public event OnSceneLoadDelegate sceneLoadDelegate;

	// Set this SceneLoader as the current instance in use at the start of the scene
	void Awake()
	{
		SceneLoaderInstance = this;
	}

    // Loads the nextScene scene asynchronously, waiting until at least duration seconds have passed to finish.
    private static IEnumerator LoadSceneAsync(string nextScene, float duration)
    {
        if (nextScene == null)
        {
            Debug.Log("Error: No name provided for next scene.");
            yield break;
        }
        else if (duration < 0)
        {
        	Debug.Log("Error: Duration of LoadSceneAsync must be non-negative.");
        	yield break;
        }

        float time = 0;

        // Start loading the next scene asynchronously.
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(nextScene);
        asyncOperation.allowSceneActivation = false;

        // Wait until the next scene has been loaded in the background.
        while (asyncOperation != null && !asyncOperation.isDone)
        {
            time += Time.deltaTime;
            // Don't allow the next scene to activate until the transition duration has finished.
            if (time > duration)
                asyncOperation.allowSceneActivation = true;

            yield return null;
        }
    }

    // Load the next scene
    public void LoadNextScene() {
    	if (nextScene == null)
    		Debug.Log("Error: Next scene name not provided in SceneLoader script.");
    	else if (!loading)
    	{
    		loading = true;
    		sceneLoadDelegate?.Invoke(transitionDurationDefault);
    		StartCoroutine(LoadSceneAsync(nextScene, transitionDurationDefault));
	    }
    }

    public void LoadNextScene(string sceneName)
    {
        if (sceneName == null)
            Debug.Log("Error: Custom next scene name was null in SceneLoader script.");
        else if (!loading)
        {
            loading = true;
            sceneLoadDelegate?.Invoke(transitionDurationDefault);
            StartCoroutine(LoadSceneAsync(nextScene, transitionDurationDefault));
        }
    }
}
