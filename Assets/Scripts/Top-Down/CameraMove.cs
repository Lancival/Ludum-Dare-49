using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraMove : MonoBehaviour
{
    [SerializeField] public Camera mainCamera;
    [SerializeField] private float duration;
    [SerializeField] private float zoomFactor;

    public bool CamZooming;
    public bool CamPanning;

    public IEnumerator CamZoom(){
        float time = 0f;
        float temp;
        float delSize = (zoomFactor - mainCamera.orthographicSize)/duration;
        while (time < duration)
        {
          temp = Time.deltaTime;
          time += temp;
          mainCamera.orthographicSize += delSize * Time.deltaTime;
          yield return null;
        }
        Debug.Log("Zoom Complete");
    }

    public IEnumerator CamPan(float delX, float delY, float PanDuration){
        float time = 0f;
        float temp;
        while (time < PanDuration)
        {
          temp = Time.deltaTime;
          time += temp;
          mainCamera.transform.position = new Vector3(mainCamera.transform.position.x + delX * Time.deltaTime , mainCamera.transform.position.y + delY * Time.deltaTime, mainCamera.transform.position.z);
          yield return null;
        }
        CamPanning = false;
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
