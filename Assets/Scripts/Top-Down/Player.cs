using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]

public class Player : MonoBehaviour
{
	[SerializeField] private Camera mainCamera;

	private Vector3 moveVector = Vector3.zero;

    public void OnMove(InputValue input)
	{
    	Vector2 inputVec = input.Get<Vector2>();
    	moveVector = new Vector3(inputVec.x, inputVec.y, 0);
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
		transform.position += (moveVector.normalized * 0.1f);
		mainCamera.transform.position = new Vector3(transform.position.x, transform.position.y, mainCamera.transform.position.z);
	}
}
