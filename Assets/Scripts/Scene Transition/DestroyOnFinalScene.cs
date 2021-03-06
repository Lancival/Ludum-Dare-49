using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DestroyOnFinalScene : MonoBehaviour
{
    void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("Start of scene");
        Debug.Log(SceneManager.GetActiveScene().name.ToLower());
        if (SceneManager.GetActiveScene().name.ToLower() == "finalscene")
        {
            Debug.Log("attempting to destroy sfx");
            Destroy(GameObject.Find("Sfx_ItemPickup"));
            Destroy(GameObject.Find("QuestCompleteAudio"));
            Destroy(GameObject.Find("AudioLayerManager"));
            Debug.Log("attempting to destroy UI");
            Destroy(GameObject.Find("UI"));
        	Debug.Log("attempting to destroy player");
        	Destroy(this.gameObject);
        }
        
    }
}
