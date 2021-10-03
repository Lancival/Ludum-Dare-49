using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraMove : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;

    public void ZoomIn() {
        if(mainCamera.orthographicSize > 1)
            mainCamera.orthographicSize -= 0.01f;
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
		      {
			         Debug.Log("Error: Main camera not provided to CameraMove script.");
			         Destroy(this.gameObject);
		      }
    }

    // Update is called once per frame
    void Update()
    {
       	mainCamera.transform.position = new Vector3(transform.position.x, transform.position.y, mainCamera.transform.position.z);
        //ZoomIn();
    }
}
