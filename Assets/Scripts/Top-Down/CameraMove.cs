using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraMove : MonoBehaviour
{
    [SerializeField] public Camera mainCamera;
    [SerializeField] private float duration;

    [SerializeField] private float zoomFactor;

    public IEnumerator ZoomIn(){
        float time = 0f;
        float temp;
        while (time < duration)
        {
          temp = Time.deltaTime;
          time += temp;
          if (mainCamera.orthographicSize > 1) {
              mainCamera.orthographicSize -= zoomFactor * Time.deltaTime;
          }
          yield return null;
        }
        Debug.Log("Zoom Complete");
    }

    void Awake(){
      Scene scene = SceneManager.GetActiveScene();
      
      if (scene.name == "House")
      {
        gameObject.SetActive(false);
      }
    }


    // Start is called before the first frame update
    void Start()
    {
        if (mainCamera == null)
		{
			Debug.Log("Error: Main camera not provided to CameraMove scipt.");
			Destroy(this);  
		}
    }

    // Update is called once per frame
    void Update()
    {
       	mainCamera.transform.position = new Vector3(transform.position.x, transform.position.y, mainCamera.transform.position.z);
    }
}
