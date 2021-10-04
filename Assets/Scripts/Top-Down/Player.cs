using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]

// TODO: Change OverlapBoxAll to fit whatever type of collider we end up using.
//						Also change the type of collider to fit the model

public class Player : MonoBehaviour
{
	
	[SerializeField] private LayerMask m_LayerMask;
	[SerializeField] private float speed = 5f;
	[SerializeField] private UI_Inventory uiInventory;

	private Collider2D closest;
	private Rigidbody2D rb;
	private Vector3 facing;
	private Inventory inventory;
	private Animator anim;
	private SpriteRenderer sprite;
	private bool controllable;

  	public void OnMove(InputValue input)
	{
		if (controllable && !Settings.PAUSED)
		{
			Vector2 inputVec = input.Get<Vector2>();

			// I found that releasing the movement key sends an input value of vector2.zero, which messes with the code saving which direction the player is facing
			if (inputVec != Vector2.zero)
			{
				facing = new Vector3 (inputVec.x, inputVec.y, 0);

				if (inputVec.y > 0)
					anim.Play("PlayerWalkBack");
				else
				{
					sprite.flipX = inputVec.x > 0;
					anim.Play("PlayerWalkFront");
				}
			}
			else
				anim.Play("PlayerIdle");

			rb.velocity = inputVec * speed;
		}
		else
			Debug.Log("Player has no control");
	}

	// Ran when player presses `Interact` key (currently set to SPACE)
	public void OnInteract(InputValue input)
	{
		Debug.Log("Attempting to interact with nearby objects...");
		if (closest != null)
		{

				Interactable other = closest.gameObject.GetComponent<Interactable>();
				if (other == null)
					Debug.Log("Colliding object is either uninteractable or has no script inheriting from `Interactable`");
				else
					other.interact();
		}
		else
			Debug.Log("Not near any interactable objects!");
	}


	void Start()
	{
		inventory = new Inventory();
		if (uiInventory != null)
			uiInventory.SetInventory(inventory);
	}
	
	void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
		facing = new Vector3(0,1,0);
		anim = GetComponent<Animator>();
		sprite = GetComponent<SpriteRenderer>();
		controllable = true;
	}

	void Update()
	{
		// Checks what objects are in front of the player (in the direction the player is facing
		if (Settings.PAUSED)
			rb.velocity = Vector2.zero;

		Vector2 curPos = new Vector2(transform.position.x, transform.position.y);
		closest = Physics2D.OverlapArea(curPos + new Vector2 (-1.5f, -2f), curPos + new Vector2 (1.5f, 2f), m_LayerMask);
	}

	public void EnablePlayerControls()
	{
		controllable = true;
	}

	public void DisablePlayerControls()
	{
		rb.velocity = Vector2.zero;
		anim.Play("PlayerIdle");
		controllable = false;
	}

	public Inventory GetInventory()
	{
		return inventory;
	}
}
