using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class CameraMove : MonoBehaviour
{
    public Camera mainCamera;
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
        this.GetComponent<PlayerInput>().enabled = false;
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
        this.GetComponent<PlayerInput>().enabled = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
        SceneManager.sceneLoaded += OnSceneLoaded;
        if (SceneManager.GetActiveScene().name == "House"){
          UpdateEnabled = false;
        }else{
          UpdateEnabled = true;
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode){
      mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
      if (scene.name == "House"){
        UpdateEnabled = false;
      }else{
        UpdateEnabled = true;
      }
    }

    // Update is called once per frame
    void Update()
    {
        // if (mainCamera == null)
        //     mainCamera = Camera.main;
        if(UpdateEnabled){
            if(Mathf.Abs(transform.position.x) <= 17.2f && Mathf.Abs(transform.position.y) <= 11.6){
       	        mainCamera.transform.position = new Vector3(transform.position.x, transform.position.y, mainCamera.transform.position.z);
            }
            else if(Mathf.Abs(transform.position.x) <= 17.2f && !(Mathf.Abs(transform.position.y) <= 11.6)){
                mainCamera.transform.position = new Vector3(transform.position.x, mainCamera.transform.position.y, mainCamera.transform.position.z);
            }
            else if(!(Mathf.Abs(transform.position.x) <= 17.2f) && Mathf.Abs(transform.position.y) <= 11.6){
                mainCamera.transform.position = new Vector3(mainCamera.transform.position.x, transform.position.y, mainCamera.transform.position.z);
            }
        }
    }
}
