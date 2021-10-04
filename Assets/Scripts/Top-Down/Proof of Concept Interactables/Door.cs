using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D hit){
      if (hit.name == "Player"){
        if (SceneManager.GetActiveScene().name == "House"){
          Debug.Log("should pan");
          StartCoroutine(hit.GetComponent<CameraMove>().CamPan(hit.transform.position.x, hit.transform.position.y, 2f));
        }
        hit.GetComponent<CameraMove>().CamZooming = true;
        StartCoroutine(hit.GetComponent<CameraMove>().CamZoom());
        transport(hit.gameObject);
      }
    }

    public void transport(GameObject player){
      player.GetComponent<PlayerInput>().enabled = false;
      SceneLoader.SceneLoaderInstance.LoadNextScene();
    }
}
