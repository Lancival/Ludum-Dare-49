using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]

// TODO: Change OverlapBoxAll to fit whatever type of collider we end up using.
//						Also change the type of collider to fit the model

public class Player : MonoBehaviour
{	[SerializeField] private LayerMask m_LayerMask;
	[SerializeField] private float speed = 5f;
	[SerializeField] private UI_Inventory uiInventory;
	[SerializeField] private Vector2 interactLim;

	private Collider2D[] hits;
	private Rigidbody2D rb;
	private Vector3 facing;
	private Inventory inventory;
	private Animator anim;
	private SpriteRenderer sprite;
	private Rigidbody2D hitter;

  	public void OnMove(InputValue input)
	{
		Vector2 inputVec = input.Get<Vector2>();
		// I found that releasing the movement key sends an input value of vector2.zero, which messes with the code saving which direction the player is facing
		if (inputVec != Vector2.zero){
			facing = new Vector3 (inputVec.x, inputVec.y, 0);
			if (inputVec.y > 0){
				anim.Play("PlayerWalkBack");
			}else{
				sprite.flipX = inputVec.x > 0;
				anim.Play("PlayerWalkFront");
			}
		}else{
				anim.Play("PlayerIdle");
		}
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

	void Awake()
	{
		inventory = new Inventory();
		if (uiInventory != null)
			uiInventory.SetInventory(inventory);
		rb = GetComponent<Rigidbody2D>();
		facing = new Vector3(0,1,0);
		anim = GetComponent<Animator>();
		sprite = GetComponent<SpriteRenderer>();
		//inventory = new Inventory();
		//uiInventory.SetInventory(inventory);
	}

	void Start()
	{
		return;
	}

	void Update(){
		// Checks what objects are in front of the player (in the direction the player is facing
		// and snaps camera to the player
		hits = Physics2D.OverlapAreaAll( transform.position + new Vector3 (0f, .66f, 0), transform.position + new Vector3 (1f, -.66f, 0), 0, m_LayerMask);
	}
}
