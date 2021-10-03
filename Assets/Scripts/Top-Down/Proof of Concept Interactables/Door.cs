using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Door : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D hit){
      if (hit.name == "Player"){
        StartCoroutine(hit.GetComponent<CameraMove>().CamZoom()); //should probably have some sort of delay after this
        transport(hit.gameObject);
      }
    }

    public void transport(GameObject player){
      player.GetComponent<PlayerInput>().enabled = false;
      SceneLoader.SceneLoaderInstance.LoadNextScene();
    }
}
