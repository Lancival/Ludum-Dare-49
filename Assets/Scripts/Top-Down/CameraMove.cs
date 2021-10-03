using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        if (mainCamera == null)
		{
			Debug.Log("Error: Main camera not provided to Player scipt.");
			Destroy(this);
		}
    }

    // Update is called once per frame
    void Update()
    {
       	mainCamera.transform.position = new Vector3(transform.position.x, transform.position.y, mainCamera.transform.position.z);
    }
}
