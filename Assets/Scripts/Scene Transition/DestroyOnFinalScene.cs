using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DestroyOnFinalScene : MonoBehaviour
{
    void Start()
    {
    	Debug.Log("Start of scene");
    	Debug.Log(SceneManager.GetActiveScene().name);

        if (SceneManager.GetActiveScene().name == "FinalScene")
        {
        	Debug.Log("attempting to destroy player");
        	Destroy(this.gameObject);
        }
    }
}
