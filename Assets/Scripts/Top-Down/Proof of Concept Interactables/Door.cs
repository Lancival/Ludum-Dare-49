using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interactable
{
    [SerializeField] private GameObject loader; 
    public override void interact()
    {
        loader.GetComponent<SceneLoader>().LoadNextScene();
    }
}