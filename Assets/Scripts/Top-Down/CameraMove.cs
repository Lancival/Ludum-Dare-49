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
    private bool UpdateEnabled = true;

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
        CamZooming = false;
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
      
      if (scene.name == "House"){
          UpdateEnabled = false;
        }
        
    }

    // Start is called before the first frame update
    void Start()
    {
        if (mainCamera == null)
		{
			Debug.Log("Error: Main camera not provided to CameraMove scipt."); //hi
			Destroy(this);  
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(UpdateEnabled){
            if(Mathf.Abs(transform.position.x) <= 28.7f && Mathf.Abs(transform.position.y) <= 16.6){
       	        mainCamera.transform.position = new Vector3(transform.position.x, transform.position.y, mainCamera.transform.position.z);
            }
            else if(Mathf.Abs(transform.position.x) <= 28.7f && !(Mathf.Abs(transform.position.y) <= 16.6)){
                mainCamera.transform.position = new Vector3(transform.position.x, mainCamera.transform.position.y, mainCamera.transform.position.z);
            }
            else if(!(Mathf.Abs(transform.position.x) <= 28.7f) && Mathf.Abs(transform.position.y) <= 16.6){
                mainCamera.transform.position = new Vector3(mainCamera.transform.position.x, transform.position.y, mainCamera.transform.position.z);
            }
        }
    }
}
