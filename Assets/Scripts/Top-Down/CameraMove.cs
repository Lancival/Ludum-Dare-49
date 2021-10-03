using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraMove : MonoBehaviour
{
    [SerializeField] public Camera mainCamera;
    [SerializeField] private float duration;

<<<<<<< HEAD
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
=======
    public void ZoomIn() {
        if(mainCamera.orthographicSize > 1)
            mainCamera.orthographicSize -= 0.01f;
>>>>>>> ca192580498a06c130e14ea6d94e3375582f90a4
    }

    void Awake(){
      Scene scene = SceneManager.GetActiveScene();
      
      if (scene.name == "House")
        this.enabled = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        if (mainCamera == null)
<<<<<<< HEAD
		{
			Debug.Log("Error: Main camera not provided to CameraMove scipt.");
			Destroy(this);  
		}
=======
		      {
			         Debug.Log("Error: Main camera not provided to CameraMove script.");
			         Destroy(this.gameObject);
		      }
>>>>>>> ca192580498a06c130e14ea6d94e3375582f90a4
    }

    // Update is called once per frame
    void Update()
    {
       	mainCamera.transform.position = new Vector3(transform.position.x, transform.position.y, mainCamera.transform.position.z);
    }
}
