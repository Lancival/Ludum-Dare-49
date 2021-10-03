using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private GameObject loader;

    void Start()
    {
      if (loader == null)
      {
        Debug.Log("Error: loader not defined in door");
        Destroy(this);
      }
    }

    void OnTriggerEnter2D(Collider2D hit){
      if (hit.name == "Player")
        transport();
    }

    public void transport(){
      loader.GetComponent<SceneLoader>().LoadNextScene();
    }
}
