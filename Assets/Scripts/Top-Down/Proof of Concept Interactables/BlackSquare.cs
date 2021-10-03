using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackSquare : Interactable
{

    [SerializeField] private GameObject destination;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private GameObject target;
    [SerializeField] private float duration;

    private float delX;
    private float delY;

    void Start()
    {
        if (mainCamera == null || target == null || destination == null){
      			Debug.Log("Error: One or more of: camera, target, destination not provided to Teleport scipt.");
      			Destroy(this);
        }
        if (duration <= 0){
            Debug.Log("Error: Teleport duration must be greater than 0.");
            Destroy(this);
        }
    }

    public override void interact()
    {
        Debug.Log("TPing target...");
        delX = (float)(destination.transform.position.x - mainCamera.transform.position.x) / duration;
        delY = (float)(destination.transform.position.y - mainCamera.transform.position.y) / duration;

        // Disables player while camera is panning
          // TODO: Maybe don't disable the player all together? but definitely player input
        target.SetActive(false);
        StartCoroutine(moveCamera());
    }

    // Pans camera, interpolated by `duration` seconds
    private IEnumerator moveCamera(){
        float time = 0f;
        float temp;
        while (time < duration)
        {
          temp = Time.deltaTime;
          time += temp;
          mainCamera.transform.position = new Vector3(mainCamera.transform.position.x + delX * Time.deltaTime , mainCamera.transform.position.y + delY * Time.deltaTime, mainCamera.transform.position.z);
          yield return null;
        }
        Debug.Log("TP complete.");
        target.transform.position = new Vector3(destination.transform.position.x, destination.transform.position.y, target.transform.position.z);
        destination.GetComponent<Interactable>().interact();

    }
}
