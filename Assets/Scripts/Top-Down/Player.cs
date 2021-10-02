using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]

public class Player : MonoBehaviour
{
	[SerializeField] private Camera mainCamera;

	private Vector3 moveVector = Vector3.zero;
	[SerializeField] private LayerMask m_LayerMask;

    public void OnMove(InputValue input)
	{
    	Vector2 inputVec = input.Get<Vector2>();
    	moveVector = new Vector3(inputVec.x, inputVec.y, 0);
	}

	/*void OnTriggerEnter2D(Collider2D other)
	{
     	if (Input.GetKeyDown(KeyCode.F)){
		 	Debug.Log("Do something");
	 	}
		Debug.Log("Do something");
	}*/

	void MyCollisions()
    {
        //Use the OverlapBox to detect if there are any other colliders within this box area.
        //Use the GameObject's centre, half the size (as a radius) and rotation. This creates an invisible box around your GameObject.
        Collider2D[] hitColliders = Physics2D.OverlapBoxAll(gameObject.transform.position, transform.localScale / 2, 0, m_LayerMask);
        int i = 0;
        //Check when there is a new collider coming into contact with the box
        while (i < hitColliders.Length)
        {
            //Output all of the collider names
            Debug.Log("Hit : " + hitColliders[i].name + i);
            //Increase the number of Colliders in the array
            i++;
        }
    }

	void Start()
	{
		if (mainCamera == null)
		{
			Debug.Log("Error: Main camera not provided to Player scipt.");
			Destroy(this);
		}
	}

	void FixedUpdate()
	{
		MyCollisions();
		transform.position += (moveVector.normalized * 0.1f);
		mainCamera.transform.position = new Vector3(transform.position.x, transform.position.y, mainCamera.transform.position.z);
	}
}
