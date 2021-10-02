using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]

// TODO: Change OverlapBoxAll to fit whatever type of collider we end up using.
//						Also change the type of collider to fit the model
// TODO: Tell interactable object to perform its action

public class Player : MonoBehaviour
{
	[SerializeField] private Camera mainCamera;
	[SerializeField] private LayerMask m_LayerMask;
	[SerializeField] private float speed = 5f;

	private Rigidbody2D rb;

  public void OnMove(InputValue input)
	{
		rb.velocity = input.Get<Vector2>() * speed;
	}

	/*void OnTriggerEnter2D(Collider2D other)
	{
     	if (Input.GetKeyDown(KeyCode.F)){
		 	Debug.Log("Do something");
	 	}
		Debug.Log("Do something");
	}*/

	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		if (mainCamera == null)
		{
			Debug.Log("Error: Main camera not provided to Player scipt.");
			Destroy(this);
		}
	}

	void FixedUpdate()
	{
    //Use the OverlapBox to detect if there are any other colliders within this box area.
    Collider2D[] hitColliders = Physics2D.OverlapBoxAll(gameObject.transform.position, transform.localScale / 2, 0, m_LayerMask);
		/*if (hitColliders.size())
		{
			 Tell the hitColliders[0] to do its action on keypress
		}*/
	}

	void Update(){
		mainCamera.transform.position = new Vector3(transform.position.x, transform.position.y, mainCamera.transform.position.z);
	}
}
