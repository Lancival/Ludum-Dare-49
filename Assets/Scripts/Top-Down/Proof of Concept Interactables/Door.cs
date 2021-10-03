using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interactable
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
    public override void interact()
    {
        loader.GetComponent<SceneLoader>().LoadNextScene();
    }
}
