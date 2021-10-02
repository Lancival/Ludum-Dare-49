using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]

// TODO: Change OverlapBoxAll to fit whatever type of collider we end up using.
//						Also change the type of collider to fit the model

public class Player : MonoBehaviour
{
	[SerializeField] private Camera mainCamera;
	[SerializeField] private LayerMask m_LayerMask;
	[SerializeField] private float speed = 5f;

	private Collider2D[] hits;
	private Rigidbody2D rb;
	private Vector3 facing;

  public void OnMove(InputValue input)
	{
		Vector2 inputVec = input.Get<Vector2>();
		// I found that releasing the movement key sends an input value of vector2.zero, which messes with the code saving which direction the player is facing
		if (inputVec != Vector2.zero)
			facing = new Vector3 (inputVec.x, inputVec.y, 0);
		rb.velocity = inputVec * speed;
	}

	// Ran when player presses `Interact` key (currently set to SPACE)
	public void OnInteract(InputValue input)
	{
		Debug.Log("Attempting to interact with nearby objects...");
		if (hits.Length != 0){
				Interactable other = hits[0].gameObject.GetComponent<Interactable>();
				if (other == null){
					Debug.Log("Colliding object is either uniteractable or has no script inheriting from `Interactable`");
				}else{
						other.interact();
				}
		}else{
			Debug.Log("Not facing any nearby objects!");
		}
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
		facing = new Vector3(0,1,0);
		if (mainCamera == null)
		{
			Debug.Log("Error: Main camera not provided to Player scipt.");
			Destroy(this);
		}
	}

	/*void FixedUpdate()
	{
	}*/

	void Update(){
		// Checks what objects are in front of the player (in the direction the player is facing
		// and snaps camera to the player
		hits = Physics2D.OverlapBoxAll( transform.position + facing / 2f, transform.localScale / 2, 0, m_LayerMask);
		mainCamera.transform.position = new Vector3(transform.position.x, transform.position.y, mainCamera.transform.position.z);
	}

	public Camera getCamera(){ return mainCamera; }
}
